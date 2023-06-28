using AutoMapper;
using FidelityCard.Application.Common;
using FidelityCard.Application.Dtos.Request;
using FidelityCard.Application.Dtos.Response;
using FidelityCard.Application.Interfaces;
using FidelityCard.Domain.Entities;
using FidelityCard.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace FidelityCard.Application.Services;

public class ProductService : IProductService
{
    private const string ProductsContainer = "products";
    private readonly IStorage _blobStorage;
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IStorage blobStorage, IProductRepository repository, IMapper mapper)
    {
        _blobStorage = blobStorage;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Guid> Create(ProductRequestDto dto, IFormFile? file)
    {
        var product = _mapper.Map<Product>(dto);

        if (file is not null)
            product.PictureFileName = await _blobStorage.UploadFile(ProductsContainer, file.OpenReadStream(), file.FileName);

        _repository.Insert(product);
        _repository.SaveChanges();

        return product.Id;
    }

    public void DeleteById(Guid id)
    {
        var product = _repository.Read(id);
        if (product is null)
            throw new ResourceNotFoundException($"Product {id} not found.");

        if (!string.IsNullOrWhiteSpace(product.PictureFileName))
            _blobStorage.DeleteFile(ProductsContainer, product.PictureFileName);

        _repository.Delete(id);
        _repository.SaveChanges();
    }

    public async Task Edit(Guid id, ProductRequestDto dto, IFormFile? file)
    {
        var product = _repository.Read(id);
        if (product is null)
            throw new ResourceNotFoundException($"Product {id} not found.");

        if (file is not null)
        {
            if (!string.IsNullOrWhiteSpace(product.PictureFileName))
                _blobStorage.DeleteFile(ProductsContainer, product.PictureFileName);

            var newFileName = await _blobStorage.UploadFile(ProductsContainer, file.OpenReadStream(), file.FileName);
            product.PictureFileName = newFileName;
        }

        product.Description = dto.Description;
        product.Price = dto.Price;

        _repository.Update(product);
        _repository.SaveChanges();
    }

    public IEnumerable<ProductResponseDto> GetAll()
    {
        foreach (var product in _repository.List())
            yield return _mapper.Map<ProductResponseDto>(product);
    }

	public ProductResponseDto GetById(Guid id)
	{
		var product = _repository.Read(id);
		if (product is null)
			throw new ResourceNotFoundException($"Product {id} not found.");

		var productDto = _mapper.Map<ProductResponseDto>(product);

		if (!string.IsNullOrWhiteSpace(product.PictureFileName))
			productDto.PictureContent = _blobStorage.DownloadBase64FileContent(ProductsContainer, product.PictureFileName);

		return productDto;
	}
}