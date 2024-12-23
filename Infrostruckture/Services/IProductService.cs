using Domain.Models;
using Infrostruckture.Responses;

namespace Infrostruckture.Services;

public interface IProductService
{
    public Task<Response<bool>> Create(Product product);
    public Task<Response<List<Product>>> GetAll();
    public Task<Response<Product>> GetById(int id);
    public Task<Response<bool>> Update(Product product);
    public Task<Response<bool>> Delete(int id);
    public Task<Response<bool>> GetAllAndPutInFile();
}