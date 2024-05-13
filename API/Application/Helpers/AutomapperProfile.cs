using AutoMapper;
using IKnowCoding.API.Models;
using IKnowCoding.API.Models.DTO.Answers;
using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.API.Models.DTO.Questions;
using IKnowCoding.API.Models.DTO.Tests;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Models.Entities;

namespace API.Application.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TestEntity, TestDto>()
                .ReverseMap();

            CreateMap<QuestionEntity, QuestionDto>()
                .ForMember(e => e.Answers, x => x.MapFrom(x => x.Answers))
                .ReverseMap();

            CreateMap<AnswerVariantEntity, AnswerVariantDto>()
                .ForMember(e => e.QuestionId, x => x.MapFrom(x => x.QuestionId))
                .ReverseMap();

            CreateMap<AchievementEntity, AchievementDto>()
                .ReverseMap();

            CreateMap<FeedbackEntity, FeedbackDto > ()
                .ForMember(e => e.FullName, x => x.MapFrom(x => x.User.FirstName + x.User.LastName))
                .ReverseMap();
        }
    }
}
