using AutoMapper;
using CRUDProducts.Entities;
using CRUDProducts.Models;
using CRUDProducts.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CRUDProducts.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductsRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var productsFromRepo = _productRepository.GetProducts();
            return Ok(productsFromRepo);
        }
        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var productFromRepo = _productRepository.GetProduct(productId);
            if(productFromRepo == null)
            {
                return NotFound();
            }
            return Ok(productFromRepo);
        }
        [HttpPost]
        public ActionResult<Product> CreateProduct(ProductForCreationDto product)
        {
            var productEntity = _mapper.Map<Entities.Product>(product);
            _productRepository.AddProduct(productEntity);
            _productRepository.Save();
            return CreatedAtRoute("GetProduct", new { productId = productEntity.Id }, productEntity);
        }
        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId,ProductForUpdateDto product)
        {
            if (!_productRepository.ProductExist(productId))
            {
                return NotFound();
            }
            var productFromRepo = _productRepository.GetProduct(productId);
            _mapper.Map(product, productFromRepo);

            _productRepository.UpdateProduct(productFromRepo);
            _productRepository.Save();

            return NoContent();
        }
        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            if (!_productRepository.ProductExist(productId))
            {
                return NotFound();
            }
            var productFromRepo = _productRepository.GetProduct(productId);
            _productRepository.DeleteProduct(productFromRepo);
            _productRepository.Save();
            return NoContent();
        }
    }
}
