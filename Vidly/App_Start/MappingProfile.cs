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
        public static IMapper mapperCustomerToDto;
        public static IMapper mapperDtoToCustomer;

        public static IMapper mapperMovieToDto;
        public static IMapper mapperDtoToMovie;

        public MappingProfile()
        {

            var configCustomerToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
            });

            mapperCustomerToDto = configCustomerToDto.CreateMapper();

            var configDtoToCustomer = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            });

            mapperDtoToCustomer = configDtoToCustomer.CreateMapper();

            var configMovieToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Movie, MovieDto>();
            });

            mapperMovieToDto = configMovieToDto.CreateMapper();

            var configDtoToMovie = new MapperConfiguration(cfg => {
                cfg.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            });

            mapperDtoToMovie = configDtoToMovie.CreateMapper();
            
        }
    }
}