using OnlineStoreManagementSystem.Entities;

namespace OnlineStoreManagementSystem.Repositories.Implementations.Base;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Contracts.Generic;

internal class BaseCrudService<TBaseEntity, TEntityVM, TEntityIM, TEntityUM>
    : IGenericCrudRepository<TEntityVM, TEntityIM, TEntityUM>,
        IGenericCollectionRepository<TEntityVM>
    where TBaseEntity : class, IEntity
    where TEntityVM : class
{
    protected readonly DbContext DbContext;
    protected readonly DbSet<TBaseEntity> Entities;
    protected readonly IMapper Mapper;
    
    public BaseCrudService(DbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
        Entities = DbContext.Set<TBaseEntity>();
    }
    
    // required mappings:
    // TEntityIM -> TBaseEntity
    // TBaseEntity -> TEntityVM
    public virtual async Task<TEntityVM> CreateAsync(TEntityIM im, CancellationToken cf = default)
    {
        var entity = await Entities.AddAsync(Mapper.Map<TBaseEntity>(im), cf);

        await DbContext.SaveChangesAsync(cf);

        return Mapper.Map<TEntityVM>(entity.Entity);
    }

    protected async Task<TEntityVM?> UpdateEntityByIdAsync(Guid id, Func<TBaseEntity, TBaseEntity> pred,
        CancellationToken cf = default)
    {
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id, cf);

        if (entity == null)
            return null;

        entity = pred(entity);
        DbContext.Entry(entity).State = EntityState.Modified;
        await DbContext.SaveChangesAsync(cf);

        return Mapper.Map<TEntityVM>(entity);
    }

    // required mappings:
    // TEntityUM -> TBaseEntity
    // TBaseEntity -> TEntityVM
    public virtual Task<TEntityVM?> UpdateByIdAsync(Guid id, TEntityUM um, CancellationToken cf = default)
    {
        return UpdateEntityByIdAsync(id, entity =>
        {
            Mapper.Map(um, entity);
            return entity;
        }, cf);
    }

    // required mappings:
    // TBaseEntity -> TEntityVM
    public virtual async Task<TEntityVM?> GetByIdAsync(Guid id, CancellationToken cf = default)
    {
        var entity = await Entities.FirstOrDefaultAsync(e => e.Id == id, cf);
        
        return entity == null ? null : Mapper.Map<TEntityVM>(entity);
    }

    public virtual async Task<int> DeleteByIdAsync(Guid id, CancellationToken cf = default)
    {
        return await Entities.Where(e => e.Id == id).ExecuteDeleteAsync(cf);
    }
    
    protected static IQueryable<TBaseEntity> GetAllPaginatedQueryable(PaginationOptions pagination,
        IQueryable<TBaseEntity> queryable)
    {
        if (pagination.SortByColumn != null)
        {
            queryable = pagination.Order == SortOrder.Ascending
                ? queryable.OrderBy(x => EF.Property<TBaseEntity>(x, pagination.SortByColumn))
                : queryable.OrderByDescending(x => EF.Property<TBaseEntity>(x, pagination.SortByColumn));
        }
        else
        {
            queryable = pagination.Order == SortOrder.Ascending
                ? queryable.OrderBy(x => x.Id)
                : queryable.OrderByDescending(x => x.Id);
        }
        
        queryable = queryable
            .Skip(((int)pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize);
        
        return queryable;
    }

    // required mappings:
    // TBaseEntity -> TEntityVM
    public virtual async Task<BaseCollectionVM<TEntityVM>> GetAllPaginatedAsync(PaginationOptions pagination,
        CancellationToken cf = default)
    {
        var queryable = GetAllPaginatedQueryable(pagination, Entities);

        return new BaseCollectionVM<TEntityVM>()
        {
            Items = queryable.AsEnumerable().Select(Mapper.Map<TEntityVM>).AsQueryable(),
            Count = await Entities.CountAsync(cf)
        };
    }
}