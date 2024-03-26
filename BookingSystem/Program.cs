using BookingSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<BookingContext>(options => {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
                           .UseLazyLoadingProxies();
                    });


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequiredLength = 5;
                }).AddEntityFrameworkStores<BookingContext>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
