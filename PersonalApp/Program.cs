using Dataaccess;
using Dataaccess.Entites;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using PersonalApp.Configuration;
using PersonalApp.Controllers;
using PersonalApp.Utilites;
using PersonalModel.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RestaurantContext>(opetion=>opetion.UseSqlServer(builder.Configuration.GetConnectionString("StudentDb")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IAppSettings, AppSettings>();
builder.Services.AddTransient<IFileManager, FileManager>();
builder.Services.AddTransient<ICookiesHelper, CookiesHelper>();


builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

//hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(builder.Configuration.GetConnectionString("StudentDb")));
builder.Services.AddHangfireServer();

//signalR


builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.s
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//signalR

//app.UseEndpoints(enpoints =>
//{
//    enpoints.MapHub<ChatHub>("/chat");
//});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseHangfireDashboard();
app.MapHangfireDashboard();
//BackgroundJob

RecurringJob.AddOrUpdate<StudentController>(x => x.SendNotofy("Weolcome"), "0 * * ? * *");



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

