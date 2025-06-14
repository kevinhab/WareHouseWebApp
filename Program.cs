using MudBlazor.Services;
using WareHouseProject.Domain.Services;
using WareHouseProject.Infrastructure.Database;
using WareHouseProject.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<InventoryService>();

builder.Services.AddMudServices(); // Bắt buộc khi dùng MudBlazor!

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
await DBContext.InitAsync(builder.Configuration);

app.Run();
