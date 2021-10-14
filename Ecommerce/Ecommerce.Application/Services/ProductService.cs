using AutoMapper;
using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Models;
using Ecommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
     public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateProduct(CreateProductDto dto)
        {
            Product product = _mapper.Map<CreateProductDto, Product>(dto);
            return await _repository.AddAsync(product);
        }

        public async Task DeleteProduct(Guid id)
        {
            //TODO: return value olarak bool döndürülebilir
            await _repository.DeleteAsync(id);
            return;
        }

        public async Task<ProductDto> GetProduct(Guid id)
        {
            Product product = await _repository.FindByIdAsync(id);
            //TODO: repository layerda validation yapılmalı
            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            List<Product> products = await _repository.GetAllAsync();

            return _mapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public async Task UpdateProduct(Guid id, UpdateProductDto dto)
        {
            if (id != dto.Id)
                throw new ApplicationException(id + "does not match the dto");

            //TODO: Check if exists
            /*bool exists = await _repository.FindByIdAsync(id)
            if (!exists)
                throw new ApplicationException(id + "product not found");*/

            Product product = await _repository.FindByIdAsync(id);
            product = _mapper.Map(dto, product);
            await _repository.UpdateAsync(product);
        }
    }
}
