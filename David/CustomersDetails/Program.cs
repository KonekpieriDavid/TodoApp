using CustomersDetails.Data;
using CustomersDetails.DBAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICustomerData, CustomerData>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();


builder.Services.AddControllers();


var app = builder.Build();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
