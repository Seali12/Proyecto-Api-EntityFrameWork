using DataAccess.Generic;
using DB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProyectoFinalContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProyectoFinalConnection"));

});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof (GenericRepository<>));
builder.Services.AddScoped<ILicenciaService, LicenciaService>();

var app = builder.Build();

/*
using (var scope = app.Services.CreateScope()) //permite acceder a ciertas props de la app
{
    var contextDB = scope.ServiceProvider.GetRequiredService<ProyectoFinalContext>();
    contextDB.Database.Migrate();
}
*/

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
