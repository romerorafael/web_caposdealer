using CD.Web.Context;
using Microsoft.EntityFrameworkCore;
using static CD.Web.Context.ApiDbContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(option =>
{
    option.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApiDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerCnnStr"));
});
builder.Services.AddInfra();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("MyPolicy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
