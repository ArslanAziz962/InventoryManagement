using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class PurchaseDto
    {
        //public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }        
        public decimal TotalAmount { get; set; }

        public Product? Product { get; set; }
        public int Quantity { get; set; }


    }
}
