using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasyTrip.Data;
using EasyTrip.Models.Siniflar;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EasyTripContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyTripContext") ?? throw new InvalidOperationException("Connection string 'EasyTripContext' not found.")));

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EasyTripContext") ?? throw new InvalidOperationException("Connection string 'EasyTripContext' not found.")));

// Add authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.LoginPath = "/GirisYap/Login"; // Specify the login path
	});

// Add session
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();


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

app.UseAuthentication();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
	//pattern: "{controller=GirisYap}/{action=Login}");
    pattern: "{controller=GirisYap}/{action=Login}/{id?}");

app.Run();
