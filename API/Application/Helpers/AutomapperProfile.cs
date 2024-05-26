using API.Models.DTO.Answers;
using API.Models.DTO.User;
using AutoMapper;
using DAL.Models.Entities.User;
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
            CreateMap<TestEntity, TestResponseDto>()
                .ForMember(e => e.Result, x => x.MapFrom(x => x.TestResultEntities.FirstOrDefault(r => r.TestId == x.Id).Result))
                .ReverseMap();

            CreateMap<TestRequestDto, TestEntity>()
                .ReverseMap();

            CreateMap<TestRequestDto, TestResponseDto>();


            CreateMap<QuestionEntity, QuestionRequestDto>()
                .ForMember(e => e.Answers, x => x.MapFrom(x => x.Answers))
                .ReverseMap();

            CreateMap<QuestionEntity, QuestionResponseDto>()
                .ForMember(e => e.Answers, x => x.MapFrom(x => x.Answers))
                .ReverseMap();

            CreateMap<QuestionResponseDto, QuestionRequestDto>();


            CreateMap<AnswerVariantEntity, AnswerVariantRequestDto>()
               .ReverseMap();

            CreateMap<AnswerVariantEntity, AnswerVariantResponseDto>()
                .ReverseMap();

            CreateMap<AnswerVariantRequestDto, AnswerVariantResponseDto>();


            CreateMap<AchievementEntity, AchievementDto>()
                .ReverseMap();

            CreateMap<FeedbackEntity, FeedbackDto> ()
                .ForMember(e => e.FullName, x => x.MapFrom(x => x.User.FirstName + " " + x.User.LastName))
                .ForMember(e => e.Date, x => x.MapFrom(x => x.Date))
                .ReverseMap();


            CreateMap<UserSettingsEntity, UserSettingsDto>()
                .ForMember(e => e.Email, x => x.MapFrom(x => x.User.Email))
                .ReverseMap();
        }
    }
}
