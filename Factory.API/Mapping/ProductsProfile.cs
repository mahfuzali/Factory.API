using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Mapping
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {


            CreateMap<Product, ProductDTO>()
                   //.ForMember(dest => dest.Supplier, opt => opt.MapFrom(src =>
                   //$"{src.Supplier.CompanyName}"))
                   //.ForMember(dest => dest.Supplier, opt => opt)
                   .ReverseMap()
               ;

        }
    }
}
