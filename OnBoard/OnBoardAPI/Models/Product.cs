using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OnBoardAPI.Models.Enums;
using System.Collections.Generic;

namespace OnBoardAPI.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public double Sale { get; set; }

        public double SalePrice { get; set; }
    
        public string ImageUrl { get; set; }
        // Convert the enum to a string, instead of the numeric value
        [JsonConverter(typeof(StringEnumConverter))]
        public ProductType ProductType { get; set; }

        public string ProductDescription { get; set; }

        [JsonIgnore]
        public IEnumerable<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Calculates the product price when there is a sale
        /// </summary>
        /// <param name="salePercentage"></param>
        /// <returns></returns>
        public double SetProductSale(double salePercentage)
        {
            Sale = salePercentage;
            SalePrice = ProductPrice * (1 - (Sale / 100));
            return SalePrice;
        }
    }
}
