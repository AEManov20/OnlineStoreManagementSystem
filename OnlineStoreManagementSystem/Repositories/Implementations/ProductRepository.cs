using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Entities;
using OnlineStoreManagementSystem.Models;
using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts;
using OnlineStoreManagementSystem.Repositories.Implementations.Base;

namespace OnlineStoreManagementSystem.Repositories.Implementations;

public class ProductRepository(
    DbContext dbContext,
    IMapper mapper) : IProductRepository
{
    private readonly DbContext _dbContext = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductVM> CreateAsync(ProductIM im,
        CancellationToken cf = default)
    {
        if (im.AvailableQuantity != null)
        {
            // product is physical
            var entity = new PhysicalProduct
            {
                Name = im.Name,
                Price = im.Price,
                AvailableQuantity = (uint)im.AvailableQuantity
            };

            var createdEntity = _dbContext.Set<PhysicalProduct>()
                .Add(entity);
            await _dbContext.SaveChangesAsync(cf);

            return mapper.Map<ProductVM>(createdEntity);
        }
        else
        {
            // product is digital
            var entity = new DigitalProduct
            {
                Name = im.Name,
                Price = im.Price
            };

            var createdEntity = _dbContext.Set<DigitalProduct>()
                .Add(entity);
            await _dbContext.SaveChangesAsync(cf);

            return mapper.Map<ProductVM>(createdEntity);
        }
    }

    public async Task<ProductVM?> GetByIdAsync(Guid id,
        CancellationToken cf = default)
    {
        var physicalProduct = await _dbContext.Set<PhysicalProduct>()
            .FirstOrDefaultAsync(e => e.Id == id, cf);
        if (physicalProduct != null)
        {
            return mapper.Map<ProductVM>(physicalProduct);
        }
        
        var digitalProduct = await _dbContext.Set<DigitalProduct>()
            .FirstOrDefaultAsync(e => e.Id == id, cf);
        if (digitalProduct != null)
        {
            return mapper.Map<ProductVM>(digitalProduct);
        }

        return null;
    }

    public async Task<BaseCollectionVM<ProductVM>> GetAllPaginatedAsync(PaginationOptions pagination,
        CancellationToken cf = default)
    {
        var physicalProducts = _dbContext.Set<PhysicalProduct>().AsQueryable();
        var digitalProducts = _dbContext.Set<DigitalProduct>().AsQueryable();

        var physicalProductsVM = physicalProducts
            .Select(p => mapper.Map<ProductVM>(p));
        
        var digitalProductsVM = digitalProducts
            .Select(p => mapper.Map<ProductVM>(p));

        var allProductsVM = physicalProductsVM.Concat(digitalProductsVM)
            .Skip(((int)pagination.Page - 1) * pagination.PageSize)
            .Take(pagination.PageSize);

        return new BaseCollectionVM<ProductVM>
        {
            Items = allProductsVM,
            Count = await allProductsVM.CountAsync(cf)
        };
    }

    public async Task<ProductVM?> UpdateByIdAsync(Guid id,
        ProductUM um,
        CancellationToken cf = default)
    {
         var physicalProduct = await _dbContext.Set<PhysicalProduct>()
             .FirstOrDefaultAsync(e => e.Id == id, cf);
         if (physicalProduct != null)
         {
             if (um.AvailableQuantity != null)
             {
                 physicalProduct.AvailableQuantity = (uint)um.AvailableQuantity;
             }
                 
             physicalProduct.Name = um.Name;
             physicalProduct.Price = um.Price;

             _dbContext.Entry(physicalProduct).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync(cf);
             
             return mapper.Map<ProductVM>(physicalProduct);
         }
         
         var digitalProduct = await _dbContext.Set<DigitalProduct>()
             .FirstOrDefaultAsync(e => e.Id == id, cf);
         if (digitalProduct != null)
         {
             digitalProduct.Name = um.Name;
             digitalProduct.Price = um.Price;

             _dbContext.Entry(digitalProduct).State = EntityState.Modified;
             await _dbContext.SaveChangesAsync(cf);
              
             return mapper.Map<ProductVM>(digitalProduct);
         }

         return null;
    }

    public async Task<int> DeleteByIdAsync(Guid id,
        CancellationToken cf = default)
    {
        var physicalProduct = await _dbContext.Set<PhysicalProduct>()
            .FirstOrDefaultAsync(e => e.Id == id, cf);
        if (physicalProduct != null)
        {
            _dbContext.Set<PhysicalProduct>().Remove(physicalProduct);
            return await _dbContext.SaveChangesAsync(cf);
        }
        
        var digitalProduct = await _dbContext.Set<DigitalProduct>()
            .FirstOrDefaultAsync(e => e.Id == id, cf);
        if (digitalProduct != null)
        {
            _dbContext.Set<DigitalProduct>().Remove(digitalProduct);
            return await _dbContext.SaveChangesAsync(cf);
        }

        return 0;
    }
}