using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sashiel_ST10028058_PROG7311.Data;
using Sashiel_ST10028058_PROG7311.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // For simplicity
})
    .AddRoles<IdentityRole>() // Add role management
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔽 Seed roles and users here
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var db = services.GetRequiredService<ApplicationDbContext>();

    string[] roles = { "Farmer", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }

    // Seed Employee
    var employeeEmail = "employee@email.com";
    var employeePassword = "Pa$$w0rd!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        var newEmployee = new IdentityUser { UserName = employeeEmail, Email = employeeEmail };
        await userManager.CreateAsync(newEmployee, employeePassword);
        await userManager.AddToRoleAsync(newEmployee, "Employee");
    }

    // Seed Farmer
    var farmerEmail = "farmer@email.com";
    var farmerPassword = "Pa$$w0rd!";
    var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
    if (farmerUser == null)
    {
        var newFarmer = new IdentityUser { UserName = farmerEmail, Email = farmerEmail };
        await userManager.CreateAsync(newFarmer, farmerPassword);
        await userManager.AddToRoleAsync(newFarmer, "Farmer");

        db.Farmers.Add(new Farmer
        {
            Name = "Test Farmer",
            Email = farmerEmail,
            UserId = newFarmer.Id
        });

        await db.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ✅ Required for Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
