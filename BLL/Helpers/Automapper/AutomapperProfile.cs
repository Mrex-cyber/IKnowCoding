using AutoMapper;
using BLL.Models.MainPage;
using BLL.Models.Tests.Answers;
using BLL.Models.Tests.Questions;
using BLL.Models.Tests.Tests;
using BLL.Models.User;
using DAL.Models.Entities.MainPage;
using DAL.Models.Entities.Tests;
using DAL.Models.Entities.User;
using Shared.Models.DTO.Answers;
using Shared.Models.DTO.MainPage;
using Shared.Models.DTO.Questions;
using Shared.Models.DTO.Tests;
using Shared.Models.DTO.User;

namespace BLL.Helpers.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            MainPageDTOtoModelMaps();
            MainPageModeltoEntity();

            UserDTOToModelMaps();
            UserModelToEntityMaps();

            //TestsSimpleMaps();
        }


        public void MainPageDTOtoModelMaps()
        {
            CreateMap<AchievementDto, AchievementModel>()
                .ReverseMap();

            CreateMap<FeedbackDto, FeedbackModel>()
                .ForMember(m => m.UserId, dto => dto.Ignore())
                .ReverseMap();
        }

        public void MainPageModeltoEntity()
        {
            CreateMap<AchievementModel, AchievementEntity>()
                .ReverseMap();

            CreateMap<FeedbackModel, FeedbackEntity>()
                .ForMember(e => e.UserId, m => m.MapFrom(x => x.UserId))
                .AfterMap((src, dest) =>
                {
                    if (dest.User != null && dest.User.Person != null)
                    {
                        src.FullName = $"{dest.User.Person.FirstName} {dest.User.Person.LastName}";
                    }
                })
                .ReverseMap()
                .ForMember(m => m.FullName, opt => opt.Ignore());
        }

        public void UserDTOToModelMaps()
        {
            CreateMap<UserLoginDto, UserModel>()
                .ReverseMap();

            CreateMap<UserRegistrationDto, UserModel>()
                .ReverseMap();

            CreateMap<UserSettingsDto, UserSettingsModel>()
                .ReverseMap();
        }

        public void UserModelToEntityMaps()
        {
            CreateMap<UserModel, UserEntity>()
                .ForPath(e => e.Person.FirstName, m => m.MapFrom(x => x.FirstName))
                .ForPath(e => e.Person.LastName, m => m.MapFrom(x => x.LastName))
                .ReverseMap();

            CreateMap<PersonModel, PersonEntity>()
                .ReverseMap();

            CreateMap<UserSettingsModel, UserSettingsEntity>()
                .ForPath(e => e.User.Id, m => m.MapFrom(x => x.UserId))
                .ReverseMap();
        }

        public void TestsSimpleMaps()
        {
            CreateMap<TestRequestDto, TestResponseDto>();
            CreateMap<QuestionResponseDto, QuestionRequestDto>();
            CreateMap<AnswerVariantRequestDto, AnswerVariantResponseDto>();
        }

        public void TestsDTOtoModelMaps()
        {
            CreateMap<TestRequestDto, TestBaseModel>()
                .ReverseMap();

            CreateMap<TestResponseDto, TestBaseModel>()
                .ReverseMap();

            CreateMap<QuestionRequestDto, QuestionModel>()
                .ReverseMap();

            CreateMap<QuestionResponseDto, QuestionModel>()
                .ReverseMap();

            CreateMap<AnswerVariantRequestDto, AnswerVariantModel>()
               .ReverseMap();

            CreateMap<AnswerVariantResponseDto, AnswerVariantModel>()
                .ReverseMap();
        }

        public void TestsModelToEntityMaps()
        {
            CreateMap<TestBaseModel, TestEntity>()
                .ReverseMap()
                .ForMember(m => m.Result, e => e.MapFrom(x => x.TestResultEntities.FirstOrDefault(y => y.TestId == x.Id)))
                .ForMember(m => m.QuestionIds, e => e.MapFrom(x => x.Questions.Select(q => q.Id)));

            CreateMap<QuestionModel, QuestionEntity>()
                .ForMember(e => e.Answers.Select(a => a.Id), m => m.MapFrom(x => x.AnswerIds))
                .ReverseMap();

            CreateMap<AnswerVariantModel, AnswerVariantEntity>();
        }
    }
}
