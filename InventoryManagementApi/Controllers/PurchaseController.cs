using AutoMapper;
using Entities.Common;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Inteface;
using Service.Services;

namespace InventoryManagementApi.Controllers
{
 
    public class PurchaseController : BaseApi
    {
        private readonly IServiceWrapper _service;
        private readonly IMapper _mapper;
        public PurchaseController(IServiceWrapper purchaseService, IMapper mapper)
        {
            _service = purchaseService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var purchaseResponse = _service.PurchaseService.GetAll();

                var products = _service.ProductService.GetAll();

                foreach (var purchase in purchaseResponse)
                {
                    if (products.Count() > 0)
                    {

                        var p = products.Where(pa => pa.ProductId == purchase.ProductId).FirstOrDefault();
                        purchase.Product = p;
                    }


                }

                var purchases = _mapper.Map<List<PurchaseDto>>(purchaseResponse);

                return Ok(purchases);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetBy(string id)
        {

            try
            {
                var purchaseResponse = _service.PurchaseService.GetBy(p => p.PurchaseId == int.Parse(id));

                var products = _service.ProductService.GetAll();
                if (products.Count() > 0)
                {

                    var p = products.Where(pa => pa.ProductId == purchaseResponse.ProductId).FirstOrDefault();
                    purchaseResponse.Product = p;
                }

                var purchase = _mapper.Map<PurchaseDto>(purchaseResponse);
                return Ok(purchase);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }

        }
        


        [HttpPost]
        public IActionResult PurchaseProduct(int productId,int quantity)
        {

            try
            {


                if (productId == 0 || quantity <= 0)
                    return BadRequest(new { message = "Invalid data sent" });

                var product = _service.ProductService.GetBy(p => p.ProductId == productId);

                var purchaseRequest = new Purchase { PurchaseDate = DateTime.Now, TotalAmount =quantity * product.Price,ProductId=productId ,Quantity = quantity};

                bool isSuccess = _service.PurchaseService.Create(purchaseRequest);
                if (isSuccess)
                {

                    product.Quantity += quantity;
                    isSuccess = _service.ProductService.Update(product);
                    if (isSuccess)
                    {
                        
                      return Ok(new {message="Product purchased successfully" });
                                              

                    }

                }                
               
                return BadRequest(new { message = "cannot purchase product" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }

        }

    }
}
