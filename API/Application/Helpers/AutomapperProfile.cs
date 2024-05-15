using API.Models.DTO.User;
using AutoMapper;
using IKnowCoding.API.Models;
using IKnowCoding.API.Models.DTO.Answers;
using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.API.Models.DTO.Questions;
using IKnowCoding.API.Models.DTO.Tests;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Entities.Relationships;

namespace API.Application.Helpers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TestEntity, TestDto>()
                .ForMember(e => e.Result, x => x.MapFrom(x => x.TestResultEntities.FirstOrDefault(r => r.TestId == x.Id).Result))
                .ReverseMap();

            CreateMap<QuestionEntity, QuestionDto>()
                .ForMember(e => e.Answers, x => x.MapFrom(x => x.Answers))
                .ReverseMap();

            CreateMap<AnswerVariantEntity, AnswerVariantDto>()
                .ReverseMap();

            CreateMap<AchievementEntity, AchievementDto>()
                .ReverseMap();

            CreateMap<FeedbackEntity, FeedbackDto > ()
                .ForMember(e => e.FullName, x => x.MapFrom(x => x.User.FirstName + x.User.LastName))
                .ReverseMap();

            CreateMap<UserEntity, UserSettingsDto>()
                .ReverseMap();
        }
    }
}
