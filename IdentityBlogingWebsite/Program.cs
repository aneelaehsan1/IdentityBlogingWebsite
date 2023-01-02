using IdentityBlogingWebsite.Data;
using IdentityBlogingWebsite.Helpers;
using IdentityBlogingWebsite.Interfaces;
using IdentityBlogingWebsite.Models;
using IdentityBlogingWebsite.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ISendGridEmail, SendGridEmail>();

builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration.GetSection("SendGrid"));

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredLength = 5;
    opt.Password.RequireLowercase= true;
    opt.Lockout.DefaultLockoutTimeSpan= TimeSpan.FromSeconds(10);
    opt.Lockout.MaxFailedAccessAttempts = 5;
    //opt.SignIn.RequireConfirmedAccount = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();