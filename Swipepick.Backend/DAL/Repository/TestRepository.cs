using DAL.AppDBContext;
using DAL.Entities.Dto;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class TestRepository : ITestRepository
    {
        private readonly UserContext _userContext;

        public TestRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public TestDto? GetTest(string uri)
        {
            var test = _userContext.Tests.Where(x => x.Url == uri).Include(x => x.Questions).FirstOrDefault();
            if (test == null)
                return null;
            var result = new TestDto() { Questions = test.Questions };
            return result;
        }
    }
}
