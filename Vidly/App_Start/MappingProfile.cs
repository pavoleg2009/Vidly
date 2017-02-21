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
        public MappingProfile()
        {

            var configCustomerToDto = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
            });

            mapperCustomerToDto = configCustomerToDto.CreateMapper();

            var configDtoToCustomer = new MapperConfiguration(cfg => {
                cfg.CreateMap<CustomerDto, Customer>();
            });

            mapperDtoToCustomer = configDtoToCustomer.CreateMapper();
            
        }
    }
}