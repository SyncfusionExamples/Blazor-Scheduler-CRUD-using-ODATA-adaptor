using BlazorSchedulerCrud.Models;
using Syncfusion.Blazor;
using BlazorSchedulerCrud.Client.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using Microsoft.AspNet.OData.Batch;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ScheduleDataContext>(options => options.UseInMemoryDatabase("Events"));
builder.Services.AddOData();
builder.Services.AddControllersWithViews();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

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

app.MapControllers();
app.Select().Filter().Expand().OrderBy();
app.MapODataRoute(
    routeName: "odata",
    routePrefix: "odata",
    model: GetEdmModel(),
    batchHandler: new DefaultODataBatchHandler());

app.MapStaticAssets();
app.MapRazorComponents<BlazorSchedulerCrud.Components.App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorSchedulerCrud.Client._Imports).Assembly);

app.Run();
