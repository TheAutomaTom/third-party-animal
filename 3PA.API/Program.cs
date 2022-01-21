using _3PA.API.Controllers.PublicRecords;
using _3PA.API.OpenApiConfiguration;
using _3PA.API.Services.PublicRecords.Conventions.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//   3PA.API's IMediatR _mediatr...
builder.Services.AddMediatR(typeof(ConventionsController).GetTypeInfo().Assembly);
//   3PA.API.Services' MediatR components...
builder.Services.AddMediatR(typeof(GetCountyNameFromCodeHandler).GetTypeInfo().Assembly);

builder.Services.Configure<FormOptions>(options =>
{
  options.ValueLengthLimit = 300_000_000;
  options.MultipartBodyLengthLimit = 300_000_000;
  options.MemoryBufferThreshold = 300_000_000;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Version = "v0",
    Title = "Third Party Animal",
    Description = "Our open source voter data agrigator",
    Contact = new OpenApiContact
    {
      Name = "Thomas Grossi",
      Url = new Uri("https://SurrealityCheck.org"),
      Email = "TheAutomaTom@gmail.com"
    },
    License = new OpenApiLicense
    {
      Name = "Example License",
      Url = new Uri("https://example.com/license")
    }
  });
  var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
  options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
  options.SchemaFilter<EnumSchemaFilter>();
  
  
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
