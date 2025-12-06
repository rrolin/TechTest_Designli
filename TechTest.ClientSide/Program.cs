using TechTest.ClientSide.Components;
using TechTest.ClientSide.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient for WebApi calls
builder.Services.AddHttpClient("TechTestApi", client =>
{
    //TODO Replace with actual
    client.BaseAddress = new Uri("https://apilocaltest"); // WebApi base URL
});

// JWT Store
builder.Services.AddSingleton<AuthenticationState>();

builder.Services.AddScoped<AuthenticationService>();

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

app.Run();
