using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.DTO
{
    public class OrderDetailDTO
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderedAmount { get; set; }
    }
}
