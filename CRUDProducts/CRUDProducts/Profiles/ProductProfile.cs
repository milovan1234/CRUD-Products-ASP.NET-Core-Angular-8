using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDProducts.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.ProductForCreationDto, Entities.Product>();
            CreateMap<Models.ProductForUpdateDto, Entities.Product>();
        }
    }
}
