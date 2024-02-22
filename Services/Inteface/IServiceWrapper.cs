using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inteface
{
    public interface IServiceWrapper
    {
        IProductService ProductService { get; }
        IPurchaseService PurchaseService { get; }
        ISaleService SaleService { get; }

    }
}
