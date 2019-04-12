using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Mapping
{
    public class OrderItemsProfile: Profile
    {
        public OrderItemsProfile()
        {
            CreateMap<OrderItem, OrderItemDTO>()
                //.ReverseMap()
                //.ForMember(o => o.Order.Customer, dest => dest.Ignore())
                ;

            CreateMap<OrderItemForCreation, OrderItem>();

        }
    }
}
