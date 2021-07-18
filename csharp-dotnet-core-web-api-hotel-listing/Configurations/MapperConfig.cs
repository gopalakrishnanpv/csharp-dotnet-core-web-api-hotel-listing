using AutoMapper;
using csharp_dotnet_core_web_api_hotel_listing.DTOs;
using csharp_dotnet_core_web_api_hotel_listing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace csharp_dotnet_core_web_api_hotel_listing.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
        }

    }
}
