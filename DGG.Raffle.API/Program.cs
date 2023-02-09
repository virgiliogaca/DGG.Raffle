using DGG.Raffle.Business.Abstract.Services;
using DGG.Raffle.Business.Services;
using DGG.Raffle.Infrastructure.Abstract.Repositories;
using DGG.Raffle.Infrastructure.Abstract.UnitOfWork;
using DGG.Raffle.Infrastructure.Database;
using DGG.Raffle.Infrastructure.Repositories;
using DGG.Raffle.Infrastructure.Repositories.Base;
using DGG.Raffle.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRaffleService, RaffleService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICharitiesRepository, CharitiesRepository>();
builder.Services.AddScoped<IRaffleEntriesRepository, RaffleEntriesRepository>();
builder.Services.AddScoped<IRaffleSessionsRepository, RaffleSessionsRepository>();

builder.Services.AddDbContext<DggRaffleDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DggDbConnection"));
});

var app = builder.Build();

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
