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

        public string ProductType { get; set; }

        public string ProductDescription { get; set; }

        public string ImageUrl { get; set; } = "https://www.google.com/search?q=appel&sxsrf=ACYBGNRyGD456xTSlB6N9IV6kSpDyqlg8w:1573633183282&source=lnms&tbm=isch&sa=X&ved=0ahUKEwjdtpW34OblAhWwShUIHcNrDeQQ_AUIEigB&biw=1536&bih=706#imgrc=J8yVd5Pk7PfMqM:";
    }
}
