using Matemagicas.Api.DataTransfer.Profiles;
using Matemagicas.Api.Domain.Services;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
    
builder.Services.AddDbContext<MatemagicasDbContext>(options =>
{
    options.UseMongoDB("mongodb://localhost:27017/", "matemagicasdb");
});

#region Injeção de dependência - Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IGamesRepository, GamesRepository>();
builder.Services.AddScoped<IQuestionsRepository, QuestionsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

#endregion
#region Injeção de dependência - Services

builder.Services.AddScoped<IGamesService, GamesService>();
builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<IUsersService, UsersService>();

#endregion
#region Injeção de dependência - AutoMapper

builder.Services.AddAutoMapper(typeof(GamesProfile));
builder.Services.AddAutoMapper(typeof(QuestionsProfile));
builder.Services.AddAutoMapper(typeof(UsersProfile));

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();