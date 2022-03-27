using AutoMapper;
using mvcWithMosh.DTOs;
using mvcWithMosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcWithMosh.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //domain model to DTOs
            Mapper.CreateMap<Customers, CustomerDTO>();
            Mapper.CreateMap<Movies, MoviesDTO>();
            Mapper.CreateMap<MembershipType, MembershipTypesDTO>();
            Mapper.CreateMap<Genre, GenreDTO>();

            //DTOs to domain model
            Mapper.CreateMap<CustomerDTO, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MoviesDTO, Movies>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}