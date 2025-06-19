using Project.Bll.DependencyResolvers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextService();
builder.Services.AddIdentityService();
builder.Services.AddRepositoryServices();
builder.Services.AddManagerServices();

builder.Services.AddHttpClient(); //API ile entegre etmek icin HttpClient ekliyoruz.

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromDays(1);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});


builder.Services.ConfigureApplicationCookie(x =>
{
    x.AccessDeniedPath = "/Home/SignIn";
    x.LoginPath = "/Home/SignIn";
});


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area}/{controller=Category}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shopping}/{action=Index}/{id?}");

app.Run();

