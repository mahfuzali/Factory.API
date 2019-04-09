using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src =>
                   $"{src.FirstName} {src.LastName}")); 

            CreateMap<CustomerForCreation, Customer>();
        }
    }
}
