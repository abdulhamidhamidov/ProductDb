using Infrostruckture.DataContext;
using Infrostruckture.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDapperContext,DapperContext>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json","ProductDb"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
