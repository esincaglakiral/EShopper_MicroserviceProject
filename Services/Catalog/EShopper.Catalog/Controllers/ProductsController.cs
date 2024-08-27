﻿using AutoMapper;
using EShopper.Catalog.Dtos.CategoryDtos;
using EShopper.Catalog.Dtos.ProductDtos;
using EShopper.Catalog.Entities;
using EShopper.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Catalog.Controllers
{
    [AllowAnonymous]  //token olmadan da işlem yapabileceğimizi belirttik
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetAllAsync();
            var mappedValues = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(mappedValues);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productService.CreateAsync(value);
            return Ok("Yeni Ürün Başarıyla Eklendi.");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdAsync(id);
            var mappedValue = _mapper.Map<GetProductByIdDto>(value);
            return Ok(mappedValue);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productService.UpdateAsync(values);
            return Ok("Ürün Başarıyla Güncellendi.");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Ürün Başarıyla Silinmiştir.");
        }


        [HttpGet("GetProductsByCategory/{categoryName}")]  //istek atarken soru işareti vermemesi için böyle yapılması daha uygun
        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            var values = await _productService.GetFilteredListAsync(x => x.CategoryName == categoryName); //CategoryName'i dışardan gönderdiğimiz categoryName 'e eşit olan değerleri getirir
            return Ok(values);
        }
    }
}


//Repositorymizin içini ne kadar zenginleştirirsek entitiye özgü metotlara ihtiyaç oranı azalır, tabi bazı istatistik verileri için yine gerekebilir entitye özgü metot