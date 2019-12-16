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


        /// <summary>
        /// Get all products and return it with a 200 status code
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return new OkObjectResult(_productRepository.GetAll());
        }

        /// <summary>
        /// Places a product with given ID on sale, can also be used to remove the sale, using salePercentage = 0
        /// The new prices is returned so the existing object in the front end can be updated with minimal data transfer
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="salePercentage"></param>
        /// <returns> The new price </returns>
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

        /// <summary>
        /// Deletes a product from the database
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
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