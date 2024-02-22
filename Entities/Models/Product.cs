using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }        
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public ICollection<Sale> Sales{ get; set;}= new List<Sale>();
        public ICollection<Purchase> Purchases{ get; set;}= new List<Purchase>();
        
        //public ICollection<SaleProduct> SaleProducts { get; set; } = new List<SaleProduct>();
        //public ICollection<PurchaseItem> PurchaseItems { get; set; } = new List<PurchaseItem>();
    }
}
