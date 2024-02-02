using BalkonyApi.Middleware;
using BalkonyBusiness.Abstract;
using BalkonyBusiness.Concrete;
using BalkonyDAL.Abstract.DataManagement;
using BalkonyDAL.Concrete.EntityFramework.Context;
using BalkonyDAL.Concrete.EntityFramework.DataManagement;
using BalkonyHelper.Globals;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<BalconyDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("BalkonyString"));
});
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IStockService, StockManager>();
builder.Services.AddScoped<IStockDetailService, StockDetailManager>();
builder.Services.AddScoped<ISupplierService, SupplierManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUnitService, UnitManager>();
builder.Services.AddScoped<IProductUnitService, ProductUnitManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));
//builder.Services.AddAuthorization(opt =>
//{
//    opt.AddPolicy("Admin", policy => policy.RequireRole());

//});




var app = builder.Build();
app.UseGlobalExceptionMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();


app.UseApiAuthorizationMiddlerware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();
