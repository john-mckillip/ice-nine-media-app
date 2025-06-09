using IceNineMedia.Core.Features.Shared.Abstractions;
using IceNineMedia.Core.Services;
using System.Net.Http.Headers;
using UContentMapper.Umbraco15.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddUContentMapper();
builder.Services.AddScoped<IUmbracoHelperService, UmbracoHelperService>();
builder.Services.AddScoped<IUmbracoMapper, UmbracoContentMappingService>();
builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()    
    .Build();

// Configure HttpClient with BaseAddress
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseAddress"] ?? "https://localhost:44319/"),
    DefaultRequestHeaders =
       {
           Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
       }
});

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseBlazorRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();