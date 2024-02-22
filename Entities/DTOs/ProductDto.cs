using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDto
    {
        public int ProductId { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
