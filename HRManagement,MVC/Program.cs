using HRManagement.MVC.Contracts;
using HRManagement.MVC.Services;
using HRManagement.MVC.Services.Base;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<IClient, Client>(p => p.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<ILocalStorageService,LocalStorageService>();

builder.Services.AddTransient<ILeaveTypeService, LeaveTypeService>();

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
