using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OnBoardAPI.Models.Enums;

namespace OnBoardAPI.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public double Sale { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductType ProductType { get; set; }

        public string ProductDescription { get; set; }

        public double SetProductSale(double salePercentage)
        {
            Sale = salePercentage;
            return ProductPrice *= (1 - (Sale / 100));
        }
    }
}
