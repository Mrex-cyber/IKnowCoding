using IKnowCoding.API.Models.DTO.MainPage;
using IKnowCoding.DAL.Models.DTO.Main_Page;
using IKnowCoding.DAL.Models.Entities;
using IKnowCoding.DAL.Models.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using IKnowCoding.DAL;
using DAL.Providers;
using DAL.Models.Entities.User;

namespace IKnowCoding.DAL
{
#pragma warning disable CS1591
    public class PlatformContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<UserSettingsEntity> UserSettings { get; set; } = null!;
        public DbSet<TestEntity> Tests { get; set; } = null!;
        public DbSet<QuestionEntity> Questions { get; set; } = null!;
        public DbSet<AnswerVariantEntity> Answers { get; set; } = null!;
        public DbSet<UserTestResultEntity> UserTestResults { get; set; } = null!;
        public DbSet<FeedbackEntity> Feedbacks { get; set; } = null!;
        public DbSet<AchievementEntity> Achievements { get; set; } = null!;

        public PlatformContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IKnowCodingDB;Trusted_Connection=True;", builder =>
            {
                builder.MigrationsAssembly("API");
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestEntity>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

            builder.Entity<QuestionEntity>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserTestResultEntity>()
                .HasOne(r => r.User)
                .WithMany(u => u.TestResultEntities)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserSettingsEntity>()
                .HasOne(s => s.User)
                .WithOne(u => u.UserSettings)
                .HasForeignKey<UserSettingsEntity>(u => u.UserId);

            builder.Entity<UserTestResultEntity>()
                .HasOne(r => r.Test)
                .WithMany(u => u.TestResultEntities)
                .HasForeignKey(r => r.TestId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<FeedbackEntity>()
                .HasOne(f => f.User)
                .WithOne(u => u.Feedback);

            // Test DATA
            builder.Entity<UserEntity>()
                .HasData(GenerateTestDataToDB.Users);

            builder.Entity<UserSettingsEntity>()
                .HasData(GenerateTestDataToDB.UserSettings);

            builder.Entity<TestEntity>()
                .HasData(GenerateTestDataToDB.Tests);

            builder.Entity<QuestionEntity>()
                .HasData(GenerateTestDataToDB.Questions);

            builder.Entity<UserTestResultEntity>()
                .HasData(GenerateTestDataToDB.UserTestResults);

            builder.Entity<AnswerVariantEntity>()
                .HasData(GenerateTestDataToDB.Answers);

            builder.Entity<FeedbackEntity>()
                .HasData(GenerateTestDataToDB.Feedbacks);

            builder.Entity<AchievementEntity>()
                .HasData(GenerateTestDataToDB.Achievements);
        }
    }
#pragma warning restore CS1591

}
