using  FormUI.Data;
using  FormUI.DBAccess;
using FormUI.Controllers;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
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
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapUserEndpoints();////

app.MapControllers();

app.Run();
