using asp.net_razorPage.Data;
using asp.net_razorPage.Repositories;
using asp.net_razorPage.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

// Configure the database context
var connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FoodDB;Integrated Security=True;";
builder.Services.AddDbContext<FoodDbContext>(options =>
{
    options.UseSqlServer(connection);
});

// Configure dependency injection for repositories and services
builder.Services.AddScoped<IFoodRepository, EFFoodRepository>();
builder.Services.AddScoped<IFoodService, FoodService>();
var app = builder.Build();

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
