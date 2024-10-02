using OnlineStoreManagementSystem.Models.DiscountCode;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface IDiscountCodeRepository : 
    IGenericCrudRepository<DiscountCodeVM, DiscountCodeIM, DiscountCodeUM>,
    IGenericCollectionRepository<DiscountCodeVM>;
    