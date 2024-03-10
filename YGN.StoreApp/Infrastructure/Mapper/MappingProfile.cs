using AutoMapper;
using YGN.StoreApp.Entities.Dtos;
using YGN.StoreApp.Entities.Models;

namespace YGN.StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion, Product>();
        }
    }
}
