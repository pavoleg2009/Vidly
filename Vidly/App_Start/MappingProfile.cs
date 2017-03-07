using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public static IMapper mapper;

        public MappingProfile()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());

                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            });
            mapper = config.CreateMapper();

            //Mapper.Initialize(cfg =>
            //{

            //    cfg.CreateMap<Customer, CustomerDto>();
            //    cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            //    cfg.CreateMap<Movie, MovieDto>();
            //    cfg.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            //    cfg.CreateMap<MembershipType, MembershipTypeDto>();
            //    cfg.CreateMap<MembershipTypeDto, MembershipType>().ForMember(m => m.Id, opt => opt.Ignore());

            //});
        }
    }
}