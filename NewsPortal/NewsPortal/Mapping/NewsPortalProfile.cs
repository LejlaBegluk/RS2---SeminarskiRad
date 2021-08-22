using AutoMapper;
using NewsPortal.Model.Models.Request;
using NewsPortal.WebAPI.Database;
using NewsPortal.WebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Mapping
{
    public class NewsPortalProfile : Profile
    {
        public NewsPortalProfile() { 
        CreateMap<Category, MCategory>();
        CreateMap<Category, CategorySearchRequest>().ReverseMap();
        CreateMap<Category, CategoryUpsertRequest>().ReverseMap();
        }
    }
}
