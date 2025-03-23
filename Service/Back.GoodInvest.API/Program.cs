using System.Reflection;
using Back.GoodInvest.Application.Services;
using Back.GoodInvest.Application.Services.Interfaces;
using Back.GoodInvest.Domain.Core.Interfaces.Service;
using Back.GoodInvest.Domain.Service.Service;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region SWAGGER

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GoodInvest API",
        Version = "v1",
        Description = "API principal GoodInvest",
        Contact = new OpenApiContact
        {
            Name = "Morais Lendengue",
            Email = "moraislenf@gmail.com",
            Url = new Uri("http://github.com/moraislen")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

#endregion

#region Services

builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

builder.Services.AddOpenApi();

builder.Services.AddSingleton<ICDBApplicationService, CDBApplicationService>();
builder.Services.AddSingleton<ISimulacaoService, SimulacaoService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GoodInvest API");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
