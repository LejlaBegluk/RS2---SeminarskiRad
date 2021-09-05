using AutoMapper;
using NewsPortal.Model.Request;
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

        CreateMap<Poll, MPoll>();
        CreateMap<Poll, PollSearchRequest>().ReverseMap();
        CreateMap<Poll, PollUpsertRequest>().ReverseMap();

        CreateMap<PollAnswer, MPollAnswer>();
        CreateMap<PollAnswer, PollAnswerSearchRequest>().ReverseMap();
        CreateMap<PollAnswer, PollAnswerUpsertRequest>().ReverseMap();

        CreateMap<Comment, MComment>();
        CreateMap<Comment, CommentSearchRequest>().ReverseMap();
        CreateMap<Comment, CommentUpsertRequest>().ReverseMap();

        CreateMap<User, MUser>();
        CreateMap<User, UserSearchRequest>().ReverseMap();
        CreateMap<User, UserUpsertRequest>().ReverseMap();

        CreateMap<UserRole, MUserRole>();
        CreateMap<Role, MRole>();
            // CreateMap<User, UserSearchRequest>().ReverseMap();
            //  CreateMap<User, UserUpsertRequest>().ReverseMap();
        }
    }
}
