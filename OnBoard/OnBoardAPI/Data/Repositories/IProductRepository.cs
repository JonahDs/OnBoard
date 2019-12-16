using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetProductById(int productId);
        double SetSaleOnProduct(Product product, double salePercentage);
    }
}
