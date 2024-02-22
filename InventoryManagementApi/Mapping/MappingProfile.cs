using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace InventoryManagementApi.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Sale, SaleDto>().ReverseMap();
            
        }
    }
}
