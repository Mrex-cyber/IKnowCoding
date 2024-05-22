using Microsoft.EntityFrameworkCore;
using System;
using AutoMapper;
using IKnowCoding.DAL;
using API.Application.Helpers;

namespace PlatformTests.TestHelpers
{
    internal static class UnitTestHelper
    {
        public static DbContextOptions<PlatformContext> GetUnitTestDbOptions()
        {
            var options = new DbContextOptionsBuilder<PlatformContext>()
                //.UseInMemoryDatabase()
                .Options;

            using (var context = new PlatformContext(options))
            {
                SeedData(context);
            }

            return options;
        }

        public static IMapper CreateMapperProfile()
        {
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));

            return new Mapper(configuration);
        }

        public static void SeedData(PlatformContext context)
        {
            


            context.SaveChanges();
        }
    }
}
