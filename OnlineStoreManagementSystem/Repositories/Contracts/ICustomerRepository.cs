using OnlineStoreManagementSystem.Models.Customer;
using OnlineStoreManagementSystem.Repositories.Contracts.Generic;

namespace OnlineStoreManagementSystem.Repositories.Contracts;

public interface ICustomerRepository : 
    IGenericCrudRepository<CustomerVM, CustomerIM, CustomerUM>,
    IGenericCollectionRepository<CustomerVM>;
    