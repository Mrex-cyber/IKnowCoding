using API.Models.DTO.Answers;
using API.Models.DTO.MainPage;
using API.Models.DTO.Questions;
using API.Models.DTO.Tests;
using API.Models.DTO.User;
using AutoMapper;
using DAL.Models.Entities.MainPage;
using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;

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

            CreateMap<FeedbackEntity, FeedbackDto>()
                .ForMember(e => e.FullName, x => x.MapFrom(x => x.User.Person.FirstName + " " + x.User.Person.LastName))
                .ForMember(e => e.Date, x => x.MapFrom(x => x.Date))
                .ReverseMap();


            CreateMap<UserSettingsEntity, UserSettingsDto>()
                .ForMember(e => e.Email, x => x.MapFrom(x => x.User.Email))
                .ReverseMap();
        }
    }
}
