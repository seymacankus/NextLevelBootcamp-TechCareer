using Microsoft.EntityFrameworkCore;
using Next_Level_Bootcamp_Task1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
