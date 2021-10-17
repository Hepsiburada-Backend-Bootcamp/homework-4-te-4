using AutoMapper;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Dtos
{
    class DtoMapping : Profile
    {
        public DtoMapping()
        {
            AllowNullCollections = true;
            
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

            CreateMap<OrderItem, OrderItemDto>().ForMember(oi=>oi.ProductDto,opt=>opt.MapFrom(o=>o.Product));
            CreateMap<CreateOrderItemDto, OrderItem>();

            CreateMap<Order, OrderDto>();
            CreateMap<CreateOrderDto, Order>();

        }
    }
}
