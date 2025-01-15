using Microsoft.EntityFrameworkCore;
using Sim.BL.Profiles;
using Sim.BL.Services.Abstractions;
using Sim.BL.Services.Implementations;
using Sim.DAL.Contexts;
using Sim.DAL.Repositories.Abstractions;
using Sim.DAL.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<INewsService,NewsService>();
builder.Services.AddScoped<ICategoryService,CategoryService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<INewsRepository,NewsRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddAutoMapper(typeof(NewsRepository)); 
builder.Services.AddAutoMapper(typeof(CategoryRepository));
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
});
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
