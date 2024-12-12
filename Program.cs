var builder = WebApplication.CreateBuilder(args);

//No te preocupes por las dependencias, las acabo de instalar, los pasos a seguir son
//[] Crear los modelos
/*
[] Configurar la base de datos para este proyecto
[] Configurar la conexion a la base de datos
[] Configurar el DBContext
[] Crear los DTO de Login y usuario
*/
//[] Crear las funcionalidades 
/*
[] Controlador para registrar usuario e iniciar sesion
[] Controlador para Aplicar autenticacion
[] Activar Cross Origin Request
*/
//[] Crear el Front End en React

//Los paquetes instalados
//dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
//dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
