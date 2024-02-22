using Entities.Models;
using Repository.Interface;
using Service.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PurchaseService : ServiceBase<Purchase>, IPurchaseService
    {
        public PurchaseService(IPurchaseRepository repository) : base(repository)
        {
        }
    }
}
