using BlazorSchedulerCrud.Server.Models;
using BlazorSchedulerCrud.Shared;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Batch;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ScheduleDataContext>(options => options.UseInMemoryDatabase("Events"));
builder.Services.AddControllersWithViews().AddOData(options => options
    .Select().Filter().Expand().OrderBy()
    .AddRouteComponents(
        routePrefix: "odata",
        model: GetEdmModel(),
        configureServices: services => services.AddSingleton<ODataBatchHandler, DefaultODataBatchHandler>()));
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

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Appointment>("Appointment");
    return odataBuilder.GetEdmModel();
}