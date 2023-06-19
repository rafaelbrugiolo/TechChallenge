﻿using Microsoft.AspNetCore.Http;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;

namespace FidelityCard.Application.Interfaces;
public interface ICompanyService
{
    Task<Guid> Create(UserRequestDto dto, IFormFile? file);
    UserResponseDto GetById(Guid id);
    Task Edit(Guid id, UserResponseDto dto, IFormFile? file);
    void DeleteById(Guid id);
    IEnumerable<UserResponseDto> GetAll();
}
