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

        public void DeleteProduct(int productId)
        {
            _products.Remove(_products.FirstOrDefault(t => t.ProductId == productId));
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(t => t.ProductId == productId);
        }

        public double SetSaleOnProduct(Product product, double salePercentage)
        {
            product.SetProductSale(salePercentage);
            _context.SaveChanges();
            return product.ProductPrice;
        }
    }
}
