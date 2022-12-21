using DAL.AppDBContext;
using DAL.Entities;
using DAL.Repository.Interfaces;


namespace DAL.Repository
{
    public class TestRepository
    {
        private readonly UserContext _userContext;

        public TestRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
    }
}
