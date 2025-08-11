using System.Reflection;
using Matemagicas.Infrastructure.Configs.Connections;
using Matemagicas.Ioc;
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
    
builder.Services.AddConnection(builder.Configuration.GetConnectionString("MongoDbConnection"), "matemagicas");

#region IOC configuration
builder.Services.AddAbstractions();
builder.Services.AddInfrastructureRepositories();
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
#endregion

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });

});

var app = builder.Build();

app.UseCors(myAllowSpecificOrigins);

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();