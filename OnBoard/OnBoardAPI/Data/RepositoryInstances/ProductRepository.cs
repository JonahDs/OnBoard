using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
            _products = context.Product;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns> Collection of products </returns>
        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }

        /// <summary>
        /// Returns product with a certain ID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns> Product object </returns>
        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(t => t.ProductId == productId);
        }

        /// <summary>
        /// Sets sale to a product 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="salePercentage"></param>
        /// <returns> The new product price </returns>
        public double SetSaleOnProduct(Product product, double salePercentage)
        {
            product.SetProductSale(salePercentage);
            _context.SaveChanges();
            return product.SalePrice;
        }
    }
}
