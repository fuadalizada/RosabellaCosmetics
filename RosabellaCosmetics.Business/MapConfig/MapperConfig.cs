using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RosabellaCosmetics.Business.DTOs;
using RosabellaCosmetics.Domain.Entities;

namespace RosabellaCosmetics.Business
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }
}
