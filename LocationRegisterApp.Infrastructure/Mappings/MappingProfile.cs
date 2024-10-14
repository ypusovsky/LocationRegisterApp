using AutoMapper;
using LocationRegisterApp.Domain.Models;
using LocationRegisterApp.Infrastructure.Entities;

namespace LocationRegisterApp.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryEntity, CountryDto>();
            CreateMap<CountryDto, CountryEntity>();
            CreateMap<ProvinceDto, ProvinceEntity>();
            CreateMap<ProvinceEntity, ProvinceDto>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserDto, UserEntity>();
        }
    }
}
