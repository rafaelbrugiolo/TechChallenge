using AutoMapper;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Domain.Entities;

namespace FidelityCard.Application.Common;

public class AutomapperConfig : Profile
{
	public AutomapperConfig()
	{
		CreateMap<User, UserRequestDto>().ReverseMap();
		CreateMap<User, UserResponseDto>().ReverseMap();

		CreateMap<Company, CompanyRequestDto>().ReverseMap();
		CreateMap<Company, CompanyResponseDto>().ReverseMap();
	}
}