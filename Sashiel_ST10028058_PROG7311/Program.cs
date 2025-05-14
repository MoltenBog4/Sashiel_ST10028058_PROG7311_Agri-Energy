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
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Seed roles, users, farmers, and products
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
            Console.WriteLine($"✅ Role '{role}' created.");
        }
    }

    // Seed Employee 1
    var employeeEmail = "employee@email.com";
    var employeePassword = "Pa$$w0rd!";
    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        var newEmployee = new IdentityUser { UserName = employeeEmail, Email = employeeEmail };
        await userManager.CreateAsync(newEmployee, employeePassword);
        await userManager.AddToRoleAsync(newEmployee, "Employee");
        Console.WriteLine("✅ First employee account seeded.");
    }

    // Seed Employee 2
    var employeeEmail2 = "employee2@email.com";
    var employeeUser2 = await userManager.FindByEmailAsync(employeeEmail2);
    if (employeeUser2 == null)
    {
        var newEmployee2 = new IdentityUser { UserName = employeeEmail2, Email = employeeEmail2 };
        await userManager.CreateAsync(newEmployee2, employeePassword);
        await userManager.AddToRoleAsync(newEmployee2, "Employee");
        Console.WriteLine("✅ Second employee account seeded.");
    }

    // Seed Farmer 1
    var farmerEmail = "farmer@email.com";
    var farmerPassword = "Pa$$w0rd!";
    var farmerUser = await userManager.FindByEmailAsync(farmerEmail);
    Farmer? seededFarmer = null;

    if (farmerUser == null)
    {
        var newFarmerUser = new IdentityUser { UserName = farmerEmail, Email = farmerEmail };
        await userManager.CreateAsync(newFarmerUser, farmerPassword);
        await userManager.AddToRoleAsync(newFarmerUser, "Farmer");

        seededFarmer = new Farmer
        {
            Name = "Test Farmer",
            Email = farmerEmail,
            UserId = newFarmerUser.Id
        };

        db.Farmers.Add(seededFarmer);
        await db.SaveChangesAsync();
        Console.WriteLine("✅ First farmer account and profile seeded.");
    }
    else
    {
        seededFarmer = db.Farmers.FirstOrDefault(f => f.Email == farmerEmail);
    }

    // Seed Farmer 2
    var farmerEmail2 = "farmerbrown@email.com";
    var farmerUser2 = await userManager.FindByEmailAsync(farmerEmail2);
    if (farmerUser2 == null)
    {
        var newFarmerUser2 = new IdentityUser { UserName = farmerEmail2, Email = farmerEmail2 };
        await userManager.CreateAsync(newFarmerUser2, farmerPassword);
        await userManager.AddToRoleAsync(newFarmerUser2, "Farmer");

        var farmerEntity2 = new Farmer
        {
            Name = "Farmer Brown",
            Email = farmerEmail2,
            UserId = newFarmerUser2.Id
        };

        db.Farmers.Add(farmerEntity2);
        await db.SaveChangesAsync();
        Console.WriteLine("✅ Second farmer account and profile seeded.");
    }

    // ✅ Always remove and reseed products for first farmer
    if (seededFarmer != null)
    {
        var existingProducts = db.Products.Where(p => p.FarmerId == seededFarmer.Id);
        db.Products.RemoveRange(existingProducts);
        await db.SaveChangesAsync();

        db.Products.AddRange(
            new Product
            {
                Name = "Organic Carrots",
                Type = "Vegetables",
                ProductionDate = new DateTime(2024, 10, 5),
                ImagePath = "/images/products/carrots.jpg",
                FarmerId = seededFarmer.Id
            },
            new Product
            {
                Name = "Wheat Grain",
                Type = "Grains",
                ProductionDate = new DateTime(2024, 9, 20),
                ImagePath = "/images/products/wheat.jpg",
                FarmerId = seededFarmer.Id
            },
            new Product
            {
                Name = "Sunflower Seeds",
                Type = "Seeds",
                ProductionDate = new DateTime(2024, 8, 10),
                ImagePath = "/images/products/sunflower.jpg",
                FarmerId = seededFarmer.Id
            }
        );

        await db.SaveChangesAsync();
        Console.WriteLine("✅ Products seeded for first farmer.");
    }
}

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


 //# Assistance provided by ChatGPT
//# Code and support generated with the help of OpenAI's ChatGPT.
// code attribution
// W3schools
//https://www.w3schools.com/cs/index.php

// code attribution
//Bootswatch
//https://bootswatch.com/

// code attribution
// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio

// code attribution
// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio

// code attribution
// https://youtu.be/qvsWwwq2ynE?si=vwx2O4bCAFDFh5m_