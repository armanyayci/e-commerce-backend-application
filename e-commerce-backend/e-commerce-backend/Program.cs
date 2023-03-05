using e_commerce_backend.Models.EntityFramework;
using e_commerce_backend.Models.EntityFramework.Abstract;
using e_commerce_backend.Models.EntityFramework.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using e_commerce_backend.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<JsonSerializerOptions>(new JsonSerializerOptions() { });

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddRazorPages();
builder.Services.AddMvc();

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);



builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetSection(key: "ConnectionStrings:DefaultConnection").Value));

builder.Services.AddDbContext<IdentityDataContext>(options =>
       options.UseSqlServer(builder.Configuration.GetSection(key: "ConnectionStrings:DefaultConnection").Value));


builder.Services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<IdentityDataContext>();


//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options => {

//        options.LoginPath = "/Account/Login";

//    });



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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
