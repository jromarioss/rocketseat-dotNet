using CashFlow.Api.Filters;
using CashFlow.Api.Middleware;
using CashFlow.Infrastructure;
using CashFlow.Application;
using CashFlow.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(option => option.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await MigrateDateBase();

app.Run();

async Task MigrateDateBase()
{
    await using var scope = app.Services.CreateAsyncScope();
    await DataBaseMigration.MigrateDataBase(scope.ServiceProvider);
}
