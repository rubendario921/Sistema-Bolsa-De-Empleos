using Microsoft.EntityFrameworkCore;
using selecciontalento_api.Data;
using selecciontalento_api.Repositories;
using selecciontalento_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Add Policys CORs
builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyLocal", builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Construir los servicios
builder.Services.AddScoped<IServicesAuthentication, ServicesAuthentication>();
builder.Services.AddScoped<IServicesUsuarios, ServicesUsuarios>();
builder.Services.AddScoped<IServicesProvincias, ServicesProvincias>();
builder.Services.AddScoped<IServicesRoles, ServicesRoles>();
builder.Services.AddScoped<IServiceEstados, ServicesEstados>();
builder.Services.AddScoped<IServicesEmpresas, ServicesEmpresas>();
builder.Services.AddScoped<IServicesModalidades, ServicesModalidades>();
builder.Services.AddScoped<IServicesIdiomas, ServicesIdiomas>();
builder.Services.AddScoped<IServicesIndustrias, ServicesIndustrias>();
builder.Services.AddScoped<IServicesCantidadEmpleados, ServicesCantidadEmpleados>();
builder.Services.AddScoped<IServicesOfertaEmpleo, ServicesOfertaEmpleo>();

var app = builder.Build();

//Create Databas if not exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dataContext = services.GetRequiredService<DataContext>();
        DataInitial.Initialize(dataContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error en crear la Base de Datos");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura la aplicación para usar la política CORS
app.UseCors("PolicyLocal");

app.UseAuthorization();

app.MapControllers();

app.Run();