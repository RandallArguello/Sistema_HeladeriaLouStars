using HeladeriaLouStars_API.DAO.Interfaces;
using HeladeriaLouStars_API.DAO;
using HeladeriaLouStars_API.Data;
using HeladeriaLouStars_API.Middleware;
using HeladeriaLouStars_API.Services.Interfaces;
using HeladeriaLouStars_API.Services;
using HeladeriaLouStars_API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using HeladeriaLouStars_API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Solo para desarrollo
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true, //  Impide que tokens expirados sean aceptados
        ValidateIssuerSigningKey = true, // Verifica que el token fue firmado por ti
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero // sin margen extra de expiración
    };
});

builder.Services.AddSingleton<ConexionDB>();
builder.Services.AddScoped<UsuarioDAO>();
builder.Services.AddScoped<EmpleadoDAO>();
builder.Services.AddScoped<ContratoDAO>();
builder.Services.AddScoped<NominaDAO>();
builder.Services.AddScoped<TurnoDAO>();
builder.Services.AddScoped<AdminDAO>();
builder.Services.AddScoped<ReportesDAO>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<EmpleadoService>();
builder.Services.AddScoped<NominaService>();
builder.Services.AddScoped<ContratoService>();
builder.Services.AddScoped<TurnoService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRepository<Empleado>, EmpleadoDAO>();
builder.Services.AddScoped<IRepository<Nomina>, NominaDAO>();
builder.Services.AddScoped<IRepository<Contrato>, ContratoDAO>();
builder.Services.AddScoped<IRepository<Turno>, TurnoDAO>();
builder.Services.AddScoped<IRepository<Administrador>, AdminDAO>();

builder.Services.AddScoped<IService<Empleado>, EmpleadoService>();
builder.Services.AddScoped<IService<Nomina>, NominaService>();
builder.Services.AddScoped<IService<Contrato>, ContratoService>();
builder.Services.AddScoped<IService<Turno>, TurnoService>();
builder.Services.AddScoped<IService<Administrador>, AdminService>();
builder.Services.AddScoped<IReporteService, ReporteService>();

builder.Services.AddAutoMapper(typeof(MappingConfig));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sistema Heladeria LouStars API",
        Version = "v1",
        Description = "API para la gestión del Sistema Heladeria Lou Stars con autenticación JWT."
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticación JWT usando el esquema Bearer. Ejemplo: 'Bearer {token}'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Administrador", policy => policy.RequireRole("Administrador"))
    .AddPolicy("Contratista", policy => policy.RequireRole("Contratista"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Usar el middleware de excepciones
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
