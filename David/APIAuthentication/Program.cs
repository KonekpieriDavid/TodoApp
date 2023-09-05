using APIAuthentication.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    }
    ).AddJwtBearer(o =>
    {
        var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]);
        o.SaveToken = true;
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:issuer"],
            ValidAudience = builder.Configuration["JWt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateLifetime =true,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
  builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
   builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen(c =>
   {

    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title= "APIAuthentication", Version="v1"});
       c.AddSecurityDefinition("token", new OpenApiSecurityScheme
       {
           Name = "Authorization",
           Type = SecuritySchemeType.Http,
           Scheme = "Bearer",
           BearerFormat = "JWT",
           In = ParameterLocation.Header,
           Description = "JSON Web Token based security"
       });
         c.AddSecurityRequirement(new OpenApiSecurityRequirement
         {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "token"
                },
            },
            Array.Empty<string>()
        }
        });
  });
   
 builder.Services.AddSingleton<IPayManagerRepository, PayManagerRepository>();
builder.Services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();
var app = builder.Build();
  

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","APIAuthentication v1"));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
