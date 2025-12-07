using TechTest.ClientSide.Data;
using TechTest.ClientSide.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient for API calls on authenticated endpoints (those use BaseService)
builder.Services.AddHttpClient("TechTestApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7129"); // WebApi base URL
});

// Services registration
builder.Services.AddSingleton<AuthenticationState>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<EmployeeService>();

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
