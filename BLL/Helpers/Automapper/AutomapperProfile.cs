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
using Shared.Models.DTO.Questions.Create;
using Shared.Models.DTO.Tests;
using Shared.Models.DTO.Tests.Create;
using Shared.Models.DTO.User;

namespace BLL.Helpers.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            TestsModelToEntityMaps();

            MainPageDTOtoModelMaps();
            MainPageModeltoEntity();

            UserDTOToModelMaps();
            UserModelToEntityMaps();

            TestsSimpleMaps();
            TestsDTOtoModelMaps();
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
                .ForMember(m => m.QuestionIds, dto => dto.MapFrom(x => x.Questions.Select(q => q.Id)))
                .ReverseMap();

            CreateMap<TestResponseDto, TestBaseModel>()
                .ForMember(m => m.QuestionIds, dto => dto.MapFrom(x => x.Questions.Select(q => q.Id)))
                .ReverseMap();

            CreateMap<TestResponseDto, TestDetailModel>()
                .ReverseMap();

            CreateMap<TestCreateRequestDto, TestDetailModel>()
                .ReverseMap();

            CreateMap<QuestionRequestDto, QuestionModel>()
                .ReverseMap();

            CreateMap<QuestionResponseDto, QuestionModel>()
                .ReverseMap();

            CreateMap<QuestionResponseDto, QuestionDetailModel>()
                .ReverseMap();

            CreateMap<BaseQuestionCreateDto, QuestionDetailModel>()
                .ReverseMap();

            CreateMap<AnswerVariantRequestDto, AnswerVariantModel>()
               .ReverseMap();

            CreateMap<AnswerVariantResponseDto, AnswerVariantModel>()
                .ReverseMap();
        }

        public void TestsModelToEntityMaps()
        {
            CreateMap<TestDetailModel, TestEntity>()
                .ForMember(e => e.Questions, m => m.MapFrom(x => x.Questions))    
                .ReverseMap();

            CreateMap<QuestionDetailModel, QuestionEntity>()
                .ForMember(e => e.Answers, m => m.MapFrom(x => x.Answers))
                .ReverseMap();

            CreateMap<AnswerVariantModel, AnswerVariantEntity>()
                .ReverseMap();
        }
    }
}
