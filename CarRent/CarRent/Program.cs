using CarRent.Data;
using CarRent.Data.Services;

var builder = WebApplication.CreateBuilder(args);

//DbContextConfiguration
builder.Services.AddDbContext<AppDbContext>();

//Services configuration
builder.Services.AddScoped<ICarsService, CarsService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IRentalContractsService, RentalContractsService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//Seed Database
AppDbInitializer.Seed(app);

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
