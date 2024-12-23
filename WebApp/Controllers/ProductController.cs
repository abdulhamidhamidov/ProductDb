using System.Diagnostics.Contracts;
using Domain.Models;
using Infrostruckture.Responses;
using Infrostruckture.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<bool>> Create(Product product)
    {
        return await productService.Create(product);
    }
    [HttpGet]
    public async Task<Response<List<Product>>> GetAll()
    {
        
        return await productService.GetAll();
    }
    [HttpGet("/get-By-Id")]
    public async Task<Response<Product>> GetById(int id)
    {
        return await productService.GetById(id);
    }
    [HttpPut]
    public async Task<Response<bool>> Update(Product product)
    {
        return await productService.Update(product);
    }
    [HttpDelete]
    public async Task<Response<bool>> Delete(int id)
    {
        return await productService.Delete(id);
    }

    [HttpGet("/get-By-File")]
    public async Task<Response<bool>> GetAllAndPutInFile()
    {
        return await productService.GetAllAndPutInFile();
    }
}