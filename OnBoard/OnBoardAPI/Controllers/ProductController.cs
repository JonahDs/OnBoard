using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;

namespace OnBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository repository)
        {
            _productRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return new OkObjectResult(_productRepository.GetAll());
        }

        [HttpPut("products/{productId}/sale{salePercentage}")]
        public ActionResult SetProductSale(int productId, double salePercentage)
        {
            Product product = _productRepository.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return new OkObjectResult(_productRepository.SetSaleOnProduct(product, salePercentage));
        }

        [HttpPut("products/{productId}/delete")]
        public ActionResult DeleteProduct(int productId)
        {
            Product product = _productRepository.GetProductById(productId);
            if(product == null)
            {
                return NotFound();
            }
            _productRepository.DeleteProduct(productId);
            return Ok();
        }
    }
}