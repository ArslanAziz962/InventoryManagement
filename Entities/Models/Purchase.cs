using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }        
        public decimal TotalAmount { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        // public ICollection<PurchaseItem> PurchaseItems { get; set; }= new List<PurchaseItem>();
    }
}
