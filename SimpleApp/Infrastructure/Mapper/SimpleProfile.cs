using AutoMapper;
using SimpleApp.BLL.Product.Command.AddProduct;
using SimpleApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApp.Infrastructure.Mapper
{
    public class SimpleProfile : Profile
    {
        public SimpleProfile()
        {
            CreateMap<AddProductCommand, ProductEntity>();
            CreateMap<ProductEntity, AddProductCommandResult>();
        }
    }
}
