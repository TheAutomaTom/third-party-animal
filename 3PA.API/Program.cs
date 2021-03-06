using _3PA.API.Controllers;
using _3PA.API.OpenApiConfiguration;
using _3PA.API.Services.PublicRecords.CountyNames.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Cors Policy
builder.Services.AddCors(o => {
  o.AddDefaultPolicy( builder => {    
    builder.WithOrigins( "*"
      //List 3pa.ui address(es):      
      //"https://localhost:8080",
      //"http://localhost:8080/public-records/consumer"
      ); 
  });
});

// Add services to the container
builder.Services.AddControllers().AddJsonOptions(x =>
              x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// MediatR enabled projects
builder.Services.AddMediatR(typeof(PublicRecordController).GetTypeInfo().Assembly)
                .AddMediatR(typeof(CountyNamesHandler).GetTypeInfo().Assembly);

//acceptable file sizes
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
app.UseCors();
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
