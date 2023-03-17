using BlazorSchedulerCrud.Server.Models;
using BlazorSchedulerCrud.Shared;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ScheduleDataContext>(options => options.UseInMemoryDatabase("Events"));
builder.Services.AddOData();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseODataBatching();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Appointment>("Appointment");
    return odataBuilder.GetEdmModel();
}

app.MapRazorPages();
app.MapControllers();
app.Select().Filter().Expand().OrderBy();
app.MapODataRoute(
    routeName: "odata",
    routePrefix: "odata",
    model: GetEdmModel(),
    batchHandler: new DefaultODataBatchHandler());
app.MapFallbackToFile("index.html");

app.Run();
