﻿using Azure;
using Mango.Service.ProductAPI.Models;
using Mango.Service.ProductAPI.Models.Dto;
using Mango.Service.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.CompilerServices;

namespace Mango.Service.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : Controller
    {
        private IProductRepository _productRepository;
        protected ResponseDto _response;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();

        }
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDto = await _productRepository.GetProducts();
                _response.Result = productDto;


            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorsMessage = new List<string> { ex.ToString() };

            }
            return _response;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductById(id);
                _response.Result = productDto;


            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.ErrorsMessage = new List<string> { ex.ToString() };

            }
            return _response;

        }


    }
}