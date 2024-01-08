using BalkonyBusiness.Abstract;
using BalkonyBusiness.Concrete;
using BalkonyDAL.Abstract.DataManagement;
using BalkonyDAL.Concrete.EntityFramework.Context;
using BalkonyDAL.Concrete.EntityFramework.DataManagement;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<BalconyDbContext>();
builder.Services.AddScoped<IUnitOfWork,EfUnitOfWork >();
builder.Services.AddScoped<ICustomerService,CustomerManager >();
builder.Services.AddScoped<IOrderService,OrderManager >();
builder.Services.AddScoped<IProductService,ProductManager >();
builder.Services.AddScoped<IStockService,StockManager >();
builder.Services.AddScoped<IStockDetailService,StockDetailManager >();
builder.Services.AddScoped<ISupplierService,SupplierManager >();
builder.Services.AddScoped<IUserService,UserManager >();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
