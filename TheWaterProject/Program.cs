using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TheWaterProject.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WaterProjectContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("WaterConnection"));
});

builder.Services.AddScoped<IWaterRepository, EFWaterRepository>();

builder.Services.AddRazorPages();

//These two lines enable us to use sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

//Improving the URLs (they are implemented in the order you put them
app.MapControllerRoute("pagenumandtype", "{projectType}/{pageNum}", new {controller = "Home", action = "Index"});
app.MapControllerRoute("pagination", "{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });
//THis is what happens when we get a project type without the page number
app.MapControllerRoute("projectType", "{projectType}", new { Controller = "Home", action = "Index", pageNum = 1 });
app.MapDefaultControllerRoute();

app.MapRazorPages();

app.Run();
