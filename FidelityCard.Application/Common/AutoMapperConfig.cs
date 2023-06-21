using AutoMapper;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Domain.Entities;

namespace FidelityCard.Application.Common;

public class AutoMapperConfig : Profile
{
	public AutoMapperConfig()
    {
        CreateMap<Company, CompanyRequestDto>().ReverseMap();
        CreateMap<Company, CompanyResponseDto>().ReverseMap();
        
        CreateMap<User, UserRequestDto>().ReverseMap();
		CreateMap<User, UserResponseDto>().ReverseMap();

        CreateMap<Customer, CustomerRequestDto>().ReverseMap();
        CreateMap<Customer, CustomerResponseDto>().ReverseMap();

        CreateMap<Product, ProductRequestDto>().ReverseMap();
        CreateMap<Product, ProductResponseDto>().ReverseMap();

        CreateMap<Promo, PromoRequestDto>().ReverseMap();
        CreateMap<Promo, PromoResponseDto>().ReverseMap();
    }
}