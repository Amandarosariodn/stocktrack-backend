using Microsoft.EntityFrameworkCore;
using PIE_Stock_Track.Data;
using PIE_Stock_Track.Repository;
using PIE_Stock_Track.Service;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Configura o banco de dados MySQL
builder.Services.AddDbContext<EstoqueContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34)) // ajuste conforme sua versão do MySQL
    ));

// 🧩 Injeta os serviços e repositórios
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ProdutoService>();

// 🚀 Adiciona suporte a controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🌐 Middleware para Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔒 Middleware padrão
app.UseHttpsRedirection();
app.UseAuthorization();

// 🚀 Mapeia os endpoints dos controllers
app.MapControllers();

app.Run();
