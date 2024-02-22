using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Inteface;
using System.Net;
using Entities.Common;
using AutoMapper;
using Entities.DTOs;
using Entities.Models;

namespace InventoryManagementApi.Controllers
{

    public class ProductController : BaseApi
    {

        private readonly IServiceWrapper _service;
        private readonly IMapper _mapper;

        public ProductController(IServiceWrapper productService,IMapper mapper)
        {
            _service = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll() {

            try
            {
                var productsResponse = _service.ProductService.GetAll();

                var sales = _service.SaleService.GetAll();
                var purchases = _service.PurchaseService.GetAll();

                foreach (var p in productsResponse)
                {
                    if (sales.Count() > 0)
                    {
                        var sale = sales.Where(s => s.ProductId == p.ProductId).FirstOrDefault();
                        if (sale != null)
                        {
                            p.Sales.Add(sale);
                        }

                    }

                    if (purchases.Count() > 0)
                    {

                        var purchase = purchases.Where(pur => pur.ProductId == p.ProductId).FirstOrDefault();
                        if (purchase != null)
                        {
                            p.Purchases.Add(purchase);
                        }
                    }

                }              

                var products = _mapper.Map<List<ProductDto>>(productsResponse);

                return Ok(products);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }           
        }
        
        
        [HttpGet("{id}")]
        public IActionResult GetBy(string id) {

            try
            {
                var productsResponse = _service.ProductService.GetBy(p=>p.ProductId == int.Parse(id));

                var sales = _service.SaleService.GetAll();
                var purchases = _service.PurchaseService.GetAll();

                if (productsResponse is not null)
                {
                    if (sales.Count() > 0)
                    {
                        var sale = sales.Where(s => s.ProductId == productsResponse.ProductId).FirstOrDefault();
                        if (sale != null)
                        {
                            productsResponse.Sales.Add(sale);
                        }

                    }

                    if (purchases.Count() > 0)
                    {

                        var purchase = purchases.Where(pur => pur.ProductId == productsResponse.ProductId).FirstOrDefault();
                        if (purchase != null)
                        {
                            productsResponse.Purchases.Add(purchase);
                        }
                    }

                }



                var product = _mapper.Map<ProductDto>(productsResponse);
                return Ok(product);                

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
           
        }
        
        
        [HttpPost]
        public IActionResult Create(ProductDto product) {

            try
            {
                var productRequest = _mapper.Map<Product>(product);
                productRequest.ProductId = 0;
                bool isSuccess = _service.ProductService.Create(productRequest);
                if (isSuccess)
                {
                    return Ok(product);                

                }
                return BadRequest(new { message = "cannot add product" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
           
        }
        
        
        [HttpPut("{id}")]
        public IActionResult Update(string id,ProductDto product) {

            try
            {

                var searchedProduct = _service.ProductService.GetBy(p => p.ProductId == int.Parse(id));
                searchedProduct.Quantity = product.Quantity;
                searchedProduct.Name = product.Name;
                searchedProduct.Description = product.Description;
                searchedProduct.Price = product.Price;

                bool isSuccess = _service.ProductService.Update(searchedProduct);
                if (isSuccess)
                {
                    return Ok(product);                

                }
                return BadRequest(new { message = "cannot update product" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
           
        }
        
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id) {

            try
            {

                var searchedProduct = _service.ProductService.GetBy(p => p.ProductId == int.Parse(id));
             

                var  response = _service.ProductService.Delete(searchedProduct);
                return Ok(response);                               

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", message = ex.Message });
            }
           
        }

        

    }
}
