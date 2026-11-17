using BlazorSchedulerCrud.Components;
using BlazorSchedulerCrud.Models;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddDbContext<ScheduleDataContext>(options => options.UseInMemoryDatabase("Events"));
builder.Services.AddOData();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseODataBatching();
app.UseHttpsRedirection();

app.UseRouting();
app.UseAntiforgery();

IEdmModel GetEdmModel()
{
    var odataBuilder = new ODataConventionModelBuilder();
    odataBuilder.EntitySet<Appointment>("Appointment");
    return odataBuilder.GetEdmModel();
}

app.MapStaticAssets();
app.MapControllers();
app.Select().Filter().Expand().OrderBy();
app.MapODataRoute(
    routeName: "odata",
    routePrefix: "odata",
    model: GetEdmModel(),
    batchHandler: new DefaultODataBatchHandler());
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
