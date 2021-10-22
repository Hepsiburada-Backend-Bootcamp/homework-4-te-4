using Ecommerce.Application.Dtos;
using Ecommerce.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services
{
    public interface IProductService
    {
        Task<Guid> CreateProduct(CreateProductDto dto);
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(Guid id);
        Task DeleteProduct(Guid id);
        Task UpdateProduct(Guid id, UpdateProductDto dto);
    }
}
