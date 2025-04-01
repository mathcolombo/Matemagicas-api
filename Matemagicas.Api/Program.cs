using Matemagicas.Api.Dtos.Profiles;
using Matemagicas.Api.Services;
using Matemagicas.Api.Repositories;
using Matemagicas.Api.Repositories.Interfaces;
using Matemagicas.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Injeção de dependência - Repositories

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
app.Run();