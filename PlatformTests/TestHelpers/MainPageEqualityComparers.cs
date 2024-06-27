using Shared.Models.DTO.MainPage;
using System.Diagnostics.CodeAnalysis;

namespace PlatformTests.TestHelpers
{
    public class AchievementComparer : IEqualityComparer<AchievementDto>
    {
        public bool Equals([AllowNull] AchievementDto x, [AllowNull] AchievementDto y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.ImagePath == y.ImagePath
                && x.Title == y.Title
                && x.Source == y.Source;
        }

        public int GetHashCode([DisallowNull] AchievementDto obj)
        {
            return obj.GetHashCode();
        }
    }

    public class FeedbackComparer : IEqualityComparer<FeedbackDto>
    {
        public bool Equals([AllowNull] FeedbackDto x, [AllowNull] FeedbackDto y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.ImagePath == y.ImagePath
                && x.FullName == y.FullName;
        }

        public int GetHashCode([DisallowNull] FeedbackDto obj)
        {
            return obj.GetHashCode();
        }
    }
}
