using Inventory.Models;
using Inventory.Repository;
using Inventory.Repository.BillTypeService;
using Inventory.Repository.Currency;
using Inventory.Repository.CustomerService;
using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.InvoiceServices;
using Inventory.Repository.PaymentTypes;
using Inventory.Repository.ProductTypeService;
using Inventory.Repository.Purchase;
using Inventory.Repository.SalesTypeService;
using Inventory.Repository.Shipment;
using Inventory.Repository.VendorTypeService;
using Inventory.Utility.HelperClass;
using Inventory.Web.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(connectionString));

IConfigurationSection IdentityDefaultOptionsSection = builder.Configuration.GetSection("IdentityDefaultOptions");
builder.Services.Configure<IdentityDefaultOptions>(IdentityDefaultOptionsSection);
var identityDefaultOptions = IdentityDefaultOptionsSection.Get<IdentityDefaultOptions>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options=>
{
    //password settings
    options.Password.RequireDigit = identityDefaultOptions.PasswordRequiredDigit;
    options.Password.RequireLowercase = identityDefaultOptions.PasswordRequiredLowercase;
    options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequiredNonAlphanumeric;
    options.Password.RequireUppercase = identityDefaultOptions.PasswordRequiredUppercase;
    options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
    options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

    //lockout settings
    options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
    options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;

    //user settings
    options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequiredConfirmedEmail;
}
    ).AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddHealthChecks();

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
builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
builder.Services.AddScoped<IShipmentTypeRepo, ShipmentTypeRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ICurrencyRepo, CurrencyRepo>();
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
