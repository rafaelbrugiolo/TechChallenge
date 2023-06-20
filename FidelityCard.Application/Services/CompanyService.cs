using AutoMapper;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Interfaces;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _repository;
    private readonly IMapper _mapper;

	public CompanyService(ICompanyRepository repository, IMapper mapper)
	{
		_repository = repository;
		_mapper = mapper;
	}

	public Guid Create(CompanyRequestDto dto)
    {
        var company = _mapper.Map<Company>(dto);

		_repository.Insert(company);
        _repository.SaveChanges();

        return company.Id;
    }

    public CompanyResponseDto GetById(Guid id)
    {
        var company = _repository.Read(id);
        if (company is null)
            throw new ResourceNotFoundException($"Company {id} not found.");

        return _mapper.Map<CompanyResponseDto>(company);
    }

    public void Edit(Guid id, CompanyRequestDto dto)
    {
        var company = _repository.Read(id);
        if (company is null)
            throw new ResourceNotFoundException($"Company {id} not found.");

        company.Cnpj = dto.Cnpj;
        company.CompanyName = dto.CompanyName;
        company.TradeName = dto.TradeName;

		_repository.Update(company);
        _repository.SaveChanges();
    }

    public void DeleteById(Guid id)
    {
        var company = _repository.Read(id);
        if (company is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        company.IsRemoved = true;

		_repository.Update(company);
		_repository.SaveChanges();
    }

    public IEnumerable<CompanyResponseDto> GetAll()
    {
        foreach (var company in _repository.List())
            yield return _mapper.Map<CompanyResponseDto>(company);
    }
}