
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RegistrationLogin;
using RegistrationLogin.Controllers;
using RegistrationLogin.Data;
using RegistrationLogin.DBAccess;
using Microsoft.Extensions.DependencyInjection;


using System.Text;
using Microsoft.OpenApi.Models;
`using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

string policyName = "AllOrigins";

var builder = WebApplication.CreateBuilder(args);

IWebHostEnvironment environment = builder.Environment;





// Add services to the container.
builder.Services.AddScoped<IUserData, UserData>();
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();



//builder.Services.AddDbContext<ApplicationDbContext>(options => options.SqlConnection(Configuration.GetConnectionString("SqlDatabase")));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy(name:policyName,builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
    
});

 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiAuthentication", Version = "v1" });

        options.AddSecurityDefinition("token", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JSON Web Token based security"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
       // IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Constants.JWT_SECURITY_KEY)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidAudience = "JWT:ValidAudience",
        ValidIssuer = " David",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWT:Secet")),
        ValidateLifetime= true,

    };
});

builder.Services.AddAuthorization(options => options.FallbackPolicy = new AuthorizationPolicyBuilder().
RequireAuthenticatedUser().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme).Build()
);







//string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
string MyAllowSpecificOrigins = "http://localhost:3000/";

var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policyName);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapUserEndpoints();
app.MapGetUserEndpoints();

app.Run();
