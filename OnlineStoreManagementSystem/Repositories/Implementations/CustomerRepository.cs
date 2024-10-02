using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineStoreManagementSystem.Entities;
using OnlineStoreManagementSystem.Models.Customer;
using OnlineStoreManagementSystem.Repositories.Contracts;
using OnlineStoreManagementSystem.Repositories.Implementations.Base;

namespace OnlineStoreManagementSystem.Repositories.Implementations;

internal class CustomerRepository(DbContext context, IMapper mapper)
    : BaseCrudService<Customer, CustomerVM, CustomerIM, CustomerUM>(context, mapper), ICustomerRepository;