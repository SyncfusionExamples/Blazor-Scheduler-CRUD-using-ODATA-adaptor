using BlazorSchedulerCrud.Server.Models;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ScheduleDataContext>(options => options.UseInMemoryDatabase("Events"));
builder.Services.AddOData();
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:7279", "http://localhost:5179")
          .AllowAnyHeader()
          .AllowAnyMethod()));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseODataBatching();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Appointment>("Appointment");
    return odataBuilder.GetEdmModel();
}

app.MapControllers();
app.Select().Filter().Expand().OrderBy();
app.MapODataRoute(
    routeName: "odata",
    routePrefix: "odata",
    model: GetEdmModel(),
    batchHandler: new DefaultODataBatchHandler());

app.Run();
