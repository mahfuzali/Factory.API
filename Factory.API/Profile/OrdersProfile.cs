using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API
{
    public class OrdersProfile: Profile
    {
        public OrdersProfile()
        {
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src =>
                   $"£{src.TotalAmount}"))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src =>
                   $"{src.Customer.FirstName} {src.Customer.LastName}"));
                
        }
    }
}
