using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Entities;
using OnlineStoreManagementSystem.Models.DiscountCode;
using OnlineStoreManagementSystem.Repositories.Contracts;
using OnlineStoreManagementSystem.Repositories.Implementations.Base;

namespace OnlineStoreManagementSystem.Repositories.Implementations;

internal class DiscountCodeRepository(DbContext context, IMapper mapper)
    : BaseCrudService<DiscountCode, DiscountCodeVM, DiscountCodeIM, DiscountCodeUM>(context, mapper),
        IDiscountCodeRepository;