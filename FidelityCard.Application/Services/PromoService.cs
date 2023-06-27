using AutoMapper;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FidelityCard.Application.Services;
public class PromoService : IPromoService
{
    private const string PromosContainer = "promos";
    private readonly IStorage _blobStorage;
    private readonly IPromoRepository _repository;
    private readonly IMapper _mapper;

    public PromoService(IStorage blobStorage, IPromoRepository repository, IMapper mapper)
    {
        _blobStorage = blobStorage;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Create(PromoRequestDto dto, IFormFile? file)
    {
        var fileName = file is not null
            ? await _blobStorage.UploadFile(PromosContainer, file.OpenReadStream(), file.FileName)
            : null;

        var promo = _mapper.Map<Promo>(dto);
        promo.ImageFileName = fileName;

        _repository.Insert(promo);
        _repository.SaveChanges();

        return promo.Id;
    }

    public void DeleteById(Guid id)
    {
        var promo = _repository.Read(id);
        if (promo is null)
            throw new ResourceNotFoundException($"Promo {id} not found.");

        if (!string.IsNullOrWhiteSpace(promo.ImageFileName))
            _blobStorage.DeleteFile(PromosContainer, promo.ImageFileName);

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public async Task Edit(Guid id, PromoRequestDto dto, IFormFile? file)
    {
        var promo = _repository.Read(id);
        if (promo is null)
            throw new ResourceNotFoundException($"Product {id} not found.");

        if (!string.IsNullOrWhiteSpace(promo.ImageFileName))
            _blobStorage.DeleteFile(PromosContainer, promo.ImageFileName);

        var fileName = file is not null
            ? await _blobStorage.UploadFile(PromosContainer, file.OpenReadStream(), file.FileName)
            : null;

        promo.Name = dto.Name;
        promo.Description = dto.Description;
        promo.ImageFileName = fileName;
        promo.From = dto.From;
        promo.To = dto.To;

        _repository.Update(promo);
        _repository.SaveChanges();
    }

    public IEnumerable<PromoResponseDto> GetAll()
    {
        foreach (var promo in _repository.List())
            yield return _mapper.Map<PromoResponseDto>(promo);
    }

    public async Task<PromoResponseDto> GetById(Guid id)
    {
        var promo = await _repository.GetByIdWithCompanyUserProduct(id);
        if (promo is null)
            throw new ResourceNotFoundException($"Promo {id} not found.");

		var promoDto = _mapper.Map<PromoResponseDto>(promo);

		if (!string.IsNullOrWhiteSpace(promo.ImageFileName))
			promoDto.ImageContent = _blobStorage.DownloadBase64FileContent(PromosContainer, promo.ImageFileName);

		return promoDto;
	}
}
