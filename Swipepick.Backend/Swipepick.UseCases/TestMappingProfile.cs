using AutoMapper;
using Swipepick.Domain;
using Swipepick.DomainServices;

namespace Swipepick.UseCases;

public class TestMappingProfile : Profile
{
	public TestMappingProfile()
	{
		CreateMap<Test, TestDto>();
		CreateMap<Student, StudentDto>();
		CreateMap<Question, QuestionDto>()
			.ForMember(dto => dto.Question, dest => dest.MapFrom(q => q.QuestionContent));
	}
}
