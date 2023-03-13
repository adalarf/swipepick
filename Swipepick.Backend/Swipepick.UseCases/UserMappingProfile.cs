using AutoMapper;
using Swipepick.Domain;
using Swipepick.DomainServices;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;

namespace Swipepick.UseCases;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}
