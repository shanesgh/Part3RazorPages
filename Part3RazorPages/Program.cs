using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Part3RazorPages.Data;
using Part3RazorPages.Models;
var builder = WebApplication.CreateBuilder(args);

// Add framework services.
builder.Services
	.AddRazorPages().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Add Kendo UI services to the services container
builder.Services.AddKendo();

// Add services to the container.
builder.Services.AddDbContext<Part3RazorPagesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Part3RazorPagesContext") ?? throw new InvalidOperationException("Connection string 'Part3RazorPagesContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
