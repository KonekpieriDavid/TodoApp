using CustomerDetails2.Controllers;
using CustomerDetails2.Data;
using CustomerDetails2.DBAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerData, CustomerData>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors((options =>
{
    options.AddPolicy(name: "Orders",
                      builder =>
                      {
                          builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()

                            .AllowAnyHeader();// allowing any header to be sent
                      });
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseCors("Orders");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapCustomerEndpoints();

app.Run();
