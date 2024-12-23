using System.Net;
using System.Text;
using Dapper;
using Domain.Models;
using Infrostruckture.DataContext;
using Infrostruckture.Responses;

namespace Infrostruckture.Services;

public class ProductService(IDapperContext dapperContext) : IProductService
{

    public async Task<Response<bool>> Create(Product product)
    {
        try
        {
            using var connection = dapperContext.Connection();
            var sql = "insert into Products( Name, Description, Price, StockQuantity, CategoryName, CreatedDate) values ( @Name, @Description, @Price, @StockQuantity, @CategoryName, @CreatedDate);";
            var res = await connection.ExecuteAsync(sql,product);
            if (res == 0) return new Response<bool>(HttpStatusCode.NotFound,"not found");
            return new Response<bool>(res!=0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<List<Product>>> GetAll()
    {
        try
        {
            using var connection = dapperContext.Connection();
            var sql = "select * from Products;";
            var res = await connection.QueryAsync<Product>(sql);
            return new Response<List<Product>>(res.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<Product>> GetById(int id)
    {
        try
        {
            using var connection = dapperContext.Connection();
            var sql = "select * from Products where Id=@Id;";
            var res = await connection.QuerySingleAsync<Product>(sql,new {Id=id});
            if (res != null) return new Response<Product>(HttpStatusCode.NotFound,"not found");
            return new Response<Product>(res);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> Update(Product product)
    { try
        {
            using var connection = dapperContext.Connection();
            var sql = "update Products set Name=@Name, Description=@Description, Price=@Price, StockQuantity=@StockQuantity, CategoryName=@CategoryName, CreatedDate=@CreatedDate where Id=@Id;";
            var res = await connection.ExecuteAsync(sql,product);
            if (res != 0) return new Response<bool>(HttpStatusCode.NotFound,"not found");
            return new Response<bool>(res!=0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> Delete(int id)
    {
        try
        {
            using var connection = dapperContext.Connection();
            var sql = "delete from Products where Id=@Id;";
            var res = await connection.ExecuteAsync(sql,new {Id=id});
            if (res != 0) return new Response<bool>(HttpStatusCode.NotFound,"not found");
            return new Response<bool>(res!=0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> GetAllAndPutInFile()
    {
        try
        {
            using var connection = dapperContext.Connection();
            var sql = "select * from Products;";
            var res = await connection.QueryAsync<Product>(sql);
            List<string> list = new List<string>();
            foreach (var a in res)
            {
                string s = $"{a.Id}, {a.Name}, {a.Description}, {a.Price}, {a.StockQuantity}, {a.CategoryName}, {a.createdDate}";
                list.Add(s);
            }
            string path = "C:\\Users\\ASUS\\Desktop\\Product_db\\Infrostruckture\\Migrations\\product.txt";
            File.AppendAllLines(path,list);
            return new Response<bool>(res!=null);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}