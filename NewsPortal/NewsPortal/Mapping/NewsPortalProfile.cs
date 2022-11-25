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
        CreateMap<PollAnswer, PollResultsRequest>();

        CreateMap<Comment, MComment>();
        CreateMap<Comment, CommentSearchRequest>().ReverseMap();
        CreateMap<Comment, CommentUpsertRequest>().ReverseMap();

        CreateMap<User, MUser>();
        CreateMap<User, UserSearchRequest>().ReverseMap();
        CreateMap<User, UserUpsertRequest>().ReverseMap();


        CreateMap<Role, MRole>();
        CreateMap<Role, RoleSearchRequest>().ReverseMap();
        CreateMap<Role, RoleUpsertRequest>().ReverseMap();

            CreateMap<Article, MArticle>().ReverseMap();
            //.ForMember(
            //dest=>dest.Author, dest => dest.MapFrom(y => y.User.FirstName+' '+y.User.LastName)
            //  ).ReverseMap();
         CreateMap<Article, ArticleSearchRequest>().ReverseMap();
         CreateMap<Article, ArticleUpsertRequest>().ReverseMap();

        CreateMap<PaidArticle, MPaidArticle>();
        CreateMap<PaidArticle, PaidArticleSearchRequest>();
        CreateMap<PaidArticle, PaidArticleUpsertRequest>().ReverseMap();


         CreateMap<ArticlePayment, MArticlePayment>();
         CreateMap<ArticlePayment, ArticlePaymentSearchRequest>();
         CreateMap<ArticlePayment, ArticlePaymentUpsertRequest>().ReverseMap();

            CreateMap<PaidArticleStatus, MPaidArticleStatus>();
            CreateMap<PaidArticleStatus, PaidArticleStatusSearchRequest>();
            CreateMap<PaidArticleStatus, PaidArticleStatusUpsertRequest>().ReverseMap();
        }
    }
}
