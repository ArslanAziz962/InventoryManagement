using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Inteface;
using static Entities.Common.Constants.Route.Default;

namespace InventoryManagementApi.Controllers
{   
    public class SaleController : BaseApi
    {
        private readonly IServiceWrapper _service;
        private readonly IMapper _mapper;
        public SaleController(IServiceWrapper purchaseService, IMapper mapper)
        {
            _service = purchaseService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            try
            {
                var saleResponse = _service.SaleService.GetAll();
                var products = _service.ProductService.GetAll();

                foreach (var sale in saleResponse)
                {
                    if(products.Count() > 0)
                    {
                        var p = products.Where(pa=>pa.ProductId==sale.ProductId).FirstOrDefault();
                        sale.Product = p;

                    }

                }

                var sales = _mapper.Map<List<SaleDto>>(saleResponse);

                return Ok(sales);
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
                var saleResponse = _service.SaleService.GetBy(p => p.SaleId == int.Parse(id));

                var products = _service.ProductService.GetAll();
                if (products.Count() > 0)
                {
                    var p = products.Where(pa => pa.ProductId == saleResponse.ProductId).FirstOrDefault();
                    saleResponse.Product = p;

                }
               
                var sale = _mapper.Map<SaleDto>(saleResponse);
                return Ok(sale);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }

        }


        [HttpPost]
        public IActionResult SaleProduct(int productId,int quantity)
        {

            try
            {

                if (productId == 0 || quantity <= 0)
                    return BadRequest(new { message = "Invalid data sent" });

                var product = _service.ProductService.GetBy(p => p.ProductId == productId);

                if(quantity>product.Quantity)
                    return BadRequest(new { message = "Quantity not sufficient" });


                var saleRequest = new Sale { SaleDate = DateTime.Now, TotalAmount = quantity * product.Price,ProductId=productId, Quantity = quantity };

                bool isSuccess = _service.SaleService.Create(saleRequest);
                if (isSuccess)
                {

                    product.Quantity -= quantity;
                    isSuccess = _service.ProductService.Update(product);
                    if (isSuccess)
                    {
                        return Ok(new { message = "Product sold successfully" });


                    }

                }

                return BadRequest(new { message = "cannot sale product" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }

        }

    }
}
