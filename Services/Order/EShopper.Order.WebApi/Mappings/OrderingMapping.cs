﻿using AutoMapper;
using EShopper.Order.DtoLayer.Dtos.OrderingDtos;
using EShopper.Order.DtoLayer.Dtos.OrderItemDtos;
using EShopper.Order.EntityLayer.Entities;

namespace EShopper.Order.WebApi.Mappings
{
    public class OrderingMapping : Profile
    {
        public OrderingMapping()
        {
            CreateMap<Ordering, ResultOrderingDto>().ReverseMap();
            CreateMap<Ordering, CreateOrderingDto>().ReverseMap();
            CreateMap<Ordering, UpdateOrderingDto>().ReverseMap();

        }
    }
}
