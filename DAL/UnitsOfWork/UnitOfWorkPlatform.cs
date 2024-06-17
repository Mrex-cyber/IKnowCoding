using DAL.Repositories.MainPage;
using DAL.Repositories.Tests;
using DAL.Repositories.Users;

namespace DAL.UnitsOfWork
{
    public class UnitOfWorkPlatform : IUnitOfWork
    {
        private PlatformContext context = new PlatformContext();

        private TestRepository _testRepository;
        private MainPageRepository _mainPageRepository;
        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(context);
                }

                return _userRepository;
            }
        }
        public TestRepository TestRepository
        {
            get
            {
                if (_testRepository == null)
                {
                    _testRepository = new TestRepository(context);
                }

                return _testRepository;
            }
        }

        public MainPageRepository MainPageRepository
        {
            get
            {
                if (_mainPageRepository == null)
                {
                    _mainPageRepository = new MainPageRepository(context);
                }
                return _mainPageRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
