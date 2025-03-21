using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using SM.Application.Service;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using SM.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
         b => b.MigrationsAssembly("SM.Infra")));

builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<EnderecoRepository>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<TecnicoRepository>();
builder.Services.AddScoped<EnderecoComplementoRepository>();
builder.Services.AddScoped<IEnderecoComplementoRepository, EnderecoComplementoRepository>();
builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<TecnicoService>();
builder.Services.AddScoped<ITecnicoService, TecnicoService>();
builder.Services.AddAutoMapper(typeof(SM.Application.Mapping.Mapper));



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();
