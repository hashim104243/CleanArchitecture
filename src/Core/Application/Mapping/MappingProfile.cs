using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Feature.Product.CreateProduct;
using Application.Feature.Product.UpdateProduct;
using AutoMapper;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductRequest, Domain.Entity.Product>();
            CreateMap<UpdateProductRequest, Domain.Entity.Product>();
        }
    }
}
