using Microsoft.EntityFrameworkCore;
using TicketScanner.Application.Handler;
using TicketScanner.Application.Repository;
using TicketScanner.Domain.IRepositories.LogsRepository;
using TicketScanner.Infrastructure;
using TicketScanner.Infrastructure.UnitOfWork;
using TicketScanner.Infrastructure.UnitOfWork.IUnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

string complete = builder.Configuration.GetConnectionString("Postgres");



builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(complete));

builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<DataHandler>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/", () => "dev");
app.Run();
