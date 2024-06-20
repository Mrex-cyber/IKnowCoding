using AutoMapper;
using DAL.Models.Entities.MainPage;
using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;
using Shared.Models.DTO.Answers;
using Shared.Models.DTO.MainPage;
using Shared.Models.DTO.Questions;
using Shared.Models.DTO.Tests;
using Shared.Models.DTO.User;

namespace API.Application.Helpers.Automapper
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
                .ReverseMap();
        }
    }
}
