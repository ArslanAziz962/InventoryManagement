using Repository.Context;
using Repository.Repositories;
using Service.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private DatabaseContext databaseContext= new DatabaseContext();
        private IProductService? _product;
        private IPurchaseService? _purchase;
        private ISaleService? _sale;


        public  IProductService ProductService { get { 
            if(_product == null)
                {
                    _product = new ProductService( new ProductRepository(databaseContext));
                }
                return _product;
            
            } }
        public IPurchaseService PurchaseService
        {
            get
            {
                if (_purchase == null)
                {
                    _purchase = new PurchaseService(new PurchaseRepository(databaseContext));
                }
                return _purchase;

            }
        }
        public  ISaleService SaleService
        {
            get
            {
                if (_sale == null)
                {
                    _sale = new SaleService(new SaleRepository(databaseContext));
                }
                return _sale;

            }
        }      
    }
}
