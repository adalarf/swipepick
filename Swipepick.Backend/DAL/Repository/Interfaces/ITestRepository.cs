using DAL.Entities.Dto;

namespace DAL.Repository.Interfaces
{
    public interface ITestRepository
    {
        TestDto GetTest(string uri);
    }
}
