using AutoMapper;
using OnlineStoreManagementSystem.Entities;
using OnlineStoreManagementSystem.Models.Customer;
using OnlineStoreManagementSystem.Models.DiscountCode;
using OnlineStoreManagementSystem.Models.Order;
using OnlineStoreManagementSystem.Models.Product;

namespace OnlineStoreManagementSystem.Models;

public class Mappings : Profile
{
    public Mappings()
    {
        CreateMap<CustomerIM, Entities.Customer>();
        CreateMap<Entities.Customer, CustomerVM>();
        CreateMap<CustomerUM, Entities.Customer>();
        
        CreateMap<DiscountCodeIM, Entities.DiscountCode>();
        CreateMap<Entities.DiscountCode, DiscountCodeVM>();
        CreateMap<DiscountCodeUM, Entities.DiscountCode>();
        
        CreateMap<Entities.Order, OrderVM>();

        CreateMap<PhysicalProduct, ProductVM>();
        CreateMap<DigitalProduct, ProductVM>();
    }
}