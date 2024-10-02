using OnlineStoreManagementSystem.Models.Product;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface IProductRepository :
    IGenericCrudRepository<ProductVM, ProductIM, ProductUM>,
    IGenericCollectionRepository<ProductVM>;
