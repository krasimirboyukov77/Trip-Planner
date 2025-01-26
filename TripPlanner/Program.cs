using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using TripPlanner.Data;
using TripPlanner.Data.Models;
using TripPlanner.Repository;
using TripPlanner.Repository.Contracts;
using TripPlanner.Services;
using TripPlanner.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
{
    options.Password.RequireDigit = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddRoles<IdentityRole<Guid>>()
               .AddSignInManager<SignInManager<ApplicationUser>>()
               .AddUserManager<UserManager<ApplicationUser>>()
               .AddDefaultUI()
               .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddHttpClient();
builder.Services.Configure<GooglePlacesOptions>(builder.Configuration.GetSection("API Token:Mapbox:Places"));


builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
