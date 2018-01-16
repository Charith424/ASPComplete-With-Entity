using ASPComplete.Dtos;
using ASPComplete.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPComplete.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            //Domain to DTO(Data Table Object)
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MoviesDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Generes, GenereDto>();

            //Dto to domain
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<MoviesDto,Movie>();

        }


    }
}