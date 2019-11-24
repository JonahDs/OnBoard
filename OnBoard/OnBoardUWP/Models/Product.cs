using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public double Sale { get; set; }

        public double SalePrice { get; set; }

        public string ProductType { get; set; }

        public string ProductDescription { get; set; }

        public string ImageUrl { get; set; }
    }
}
