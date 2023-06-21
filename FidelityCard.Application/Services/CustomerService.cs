using AutoMapper;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;

namespace FidelityCard.Application.Services;
public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;
    private readonly IMapper _mapper;

    public CustomerService(ICustomerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Guid Create(CustomerRequestDto dto)
    {
        var customer = _mapper.Map<Customer>(dto);

        _repository.Insert(customer);
        _repository.SaveChanges();

        return customer.Id;
    }

    public void DeleteById(Guid id)
    {
        var customer = _repository.Read(id);
        if (customer is null)
            throw new ResourceNotFoundException($"User {id} not found.");

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public void Edit(Guid id, CustomerRequestDto dto)
    {
        var customer = _repository.Read(id);
        if (customer is null)
            throw new ResourceNotFoundException($"Customer {id} not found.");

        customer.Name = dto.Name;
        customer.Email = dto.Email;
        customer.Birthdate = dto.Birthdate;
        customer.ContactPhone = dto.ContactPhone;

        _repository.Update(customer);
        _repository.SaveChanges();
    }

    public IEnumerable<CustomerResponseDto> GetAll()
    {
        foreach (var company in _repository.List())
            yield return _mapper.Map<CustomerResponseDto>(company);
    }

    public CustomerResponseDto GetById(Guid id)
    {
        var company = _repository.Read(id);
        if (company is null)
            throw new ResourceNotFoundException($"Customer {id} not found.");

        return _mapper.Map<CustomerResponseDto>(company);
    }
}
