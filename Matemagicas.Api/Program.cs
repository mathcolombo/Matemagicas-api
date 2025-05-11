using System.Reflection;
using Matemagicas.Api.Domain.Services;
using Matemagicas.Api.Domain.Services.Interfaces;
using Matemagicas.Api.Infrastructure.Context;
using Matemagicas.Api.Infrastructure.Repositories;
using Matemagicas.Api.Infrastructure.Repositories.Interfaces;
using Matemagicas.Api.Infrastructure.Utils.Repositories;
using Matemagicas.Api.Infrastructure.Utils.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Matemagicas-api", Version = "v1" });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
    
builder.Services.AddDbContext<MatemagicasDbContext>(options =>
{
    options.UseMongoDB(builder.Configuration.GetConnectionString("MongoDB")!, "matemagicas");
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

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();