using Inventory.Models;
using Inventory.Repository;
using Inventory.Repository.BillTypeService;
using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.InvoiceServices;
using Inventory.Repository.PaymentTypes;
using Inventory.Repository.Purchase;
using Inventory.Repository.SalesTypeService;
using Inventory.Repository.VendorTypeService;
using Inventory.Utility.HelperClass;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));
builder.Services.AddDbContext<Inventory.Repository.ApplicationDbContext>(options => 
options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<Inventory.Repository.ApplicationDbContext>();
//builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<Inventory.Repository.ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBillTypeRepo, BillTypeRepo>();
builder.Services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();
builder.Services.AddScoped<IVendorTypeRepo, VendorTypeRepo>();
builder.Services.AddScoped<ISalesTypeService, SalesTypeService>();
builder.Services.AddScoped<IInvoiceTypeRepo, InvoiceTypeRepo>();
builder.Services.AddScoped<IPaymentTypeRepo, PaymentTypeRepo>();
builder.Services.AddScoped<IPurchaseTypeRepo, PurchaseTypeRepo>();
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
