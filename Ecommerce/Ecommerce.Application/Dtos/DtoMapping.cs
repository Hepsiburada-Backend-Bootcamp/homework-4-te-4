using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Dtos;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDto = Ecommerce.Domain.Dtos.OrderDto;
using ProductDto = Ecommerce.Domain.Dtos.ProductDto;
using UserDto = Ecommerce.Domain.Dtos.UserDto;
using OrderItemDto = Ecommerce.Domain.Dtos.OrderItemDto;


namespace Ecommerce.Application
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

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(oiDto => oiDto.ProductDto, opt => opt.MapFrom(oi => oi.Product));
            CreateMap<CreateOrderItemDto, OrderItem>();

            CreateMap<Order, OrderDto>()
                .ForMember(oDto => oDto.UserDto, opt => opt.MapFrom(o => o.User));
            CreateMap<CreateOrderDto, Order>();

        }
    }
}
