using IKnowCoding.DAL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformTests.TestHelpers
{
    internal class TestEqualityComparer : IEqualityComparer<TestEntity>
    {
        public bool Equals([AllowNull] TestEntity x, [AllowNull] TestEntity y)
        {
            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;

            return x.Id == y.Id
                && x.ImagePath == y.ImagePath
                && x.Title == y.Title
                && x.Description == y.Description
                && x.IsFree == y.IsFree;
        }

        public int GetHashCode([DisallowNull] TestEntity obj)
        {
            return obj.GetHashCode();
        }
    }
}
