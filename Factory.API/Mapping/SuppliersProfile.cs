using AutoMapper;
using Factory.API.Entities;
using Factory.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Factory.API.Mapping
{
    public class SuppliersProfile: Profile
    {
        public SuppliersProfile()
        {
       
            CreateMap<Supplier, SupplierDTO>()
                .ReverseMap();
     





        }
    }
}
