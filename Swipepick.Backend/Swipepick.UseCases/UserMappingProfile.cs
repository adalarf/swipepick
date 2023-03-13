using AutoMapper;
using Swipepick.Domain;
using Swipepick.DomainServices;

namespace Swipepick.UseCases;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserDto, User>();
    }
}
