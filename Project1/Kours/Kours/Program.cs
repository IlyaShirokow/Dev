using Kours.DAL;
using Kours.DAL.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MVCProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration
    .GetConnectionString("MvcFlowersConnectionString")));

builder.Services.AddScoped<AutosDAL>();
builder.Services.AddScoped<DriversDAL>();
builder.Services.AddScoped<InvoicesDAL>();
builder.Services.AddScoped<OrderDAL>();
builder.Services.AddScoped<OrganizationsDAL>();
builder.Services.AddScoped<ProductsDAL>();

builder.Services.AddSwaggerGen(page =>
{
    page.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    page.SwaggerDoc("autos", new OpenApiInfo { Title = "autos", Version = "v1" });
    page.SwaggerDoc("drivers", new OpenApiInfo { Title = "drivers", Version = "v1" });
    page.SwaggerDoc("invoices", new OpenApiInfo { Title = "invoices", Version = "v1" });
    page.SwaggerDoc("order", new OpenApiInfo { Title = "order", Version = "v1" });

    page.SwaggerDoc("organizations", new OpenApiInfo { Title = "organizations", Version = "v1" });
    page.SwaggerDoc("products", new OpenApiInfo { Title = "products", Version = "v1" });

});

var app = builder.Build();

app.UseSession();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(page =>
    {
        page.SwaggerEndpoint("/swagger/autos/swagger.json", "client");
        page.SwaggerEndpoint("/swagger/drivers/swagger.json", "employee");
        page.SwaggerEndpoint("/swagger/invoices/swagger.json", "post");
        page.SwaggerEndpoint("/swagger/order/swagger.json", "product");
        page.SwaggerEndpoint("/swagger/organizations/swagger.json", "service");
        page.SwaggerEndpoint("/swagger/products/swagger.json", "sklad");
        page.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
