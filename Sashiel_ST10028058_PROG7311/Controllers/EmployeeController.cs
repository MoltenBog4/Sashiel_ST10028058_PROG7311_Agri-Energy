using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sashiel_ST10028058_PROG7311.Data;
using Sashiel_ST10028058_PROG7311.Models;
using Sashiel_ST10028058_PROG7311.Models.ViewModels;

namespace Sashiel_ST10028058_PROG7311.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult AddFarmer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFarmer(CreateFarmerViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Farmer");

                _context.Farmers.Add(new Farmer
                {
                    Name = model.FullName,
                    Email = model.Email,
                    UserId = user.Id
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = "Farmer account created successfully.";
                return RedirectToAction(nameof(AddFarmer));
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(model);
        }

        public async Task<IActionResult> ViewProducts()
        {
            var products = await _context.Products.Include(p => p.Farmer).ToListAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> FilterProducts(string type, DateTime? fromDate, DateTime? toDate)
        {
            var query = _context.Products.Include(p => p.Farmer).AsQueryable();

            if (!string.IsNullOrEmpty(type))
                query = query.Where(p => p.Type == type);

            if (fromDate.HasValue)
                query = query.Where(p => p.ProductionDate >= fromDate);

            if (toDate.HasValue)
                query = query.Where(p => p.ProductionDate <= toDate);

            return View("ViewProducts", await query.ToListAsync());
        }

        public async Task<IActionResult> ViewFarmers()
        {
            var farmers = await _context.Farmers.ToListAsync();
            return View(farmers);
        }

        // GET: EditFarmer
        public async Task<IActionResult> EditFarmer(int? id)
        {
            if (id == null)
                return NotFound();

            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
                return NotFound();

            return View(farmer);
        }

        // POST: EditFarmer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFarmer(int id, Farmer updated)
        {
            if (id != updated.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(updated);

            try
            {
                var farmer = await _context.Farmers.FindAsync(id);
                if (farmer == null)
                    return NotFound();

                farmer.Name = updated.Name;
                farmer.Email = updated.Email;

                _context.Update(farmer);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Farmer updated successfully.";
                return RedirectToAction(nameof(ViewFarmers));
            }
            catch (DbUpdateConcurrencyException)
            {
                return Problem("Update failed due to concurrency issue.");
            }
        }


        // GET: DeleteFarmer
        public async Task<IActionResult> DeleteFarmer(int? id)
        {
            if (id == null)
                return NotFound();

            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.Id == id);
            if (farmer == null)
                return NotFound();

            return View(farmer);
        }

        // POST: DeleteFarmerConfirmed
        [HttpPost, ActionName("DeleteFarmer")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFarmerConfirmed(int id)
        {
            var farmer = await _context.Farmers.FindAsync(id);
            if (farmer == null)
                return NotFound();

            _context.Farmers.Remove(farmer);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Farmer deleted successfully.";
            return RedirectToAction(nameof(ViewFarmers));
        }

    }
}
////# Assistance provided by ChatGPT
////# Code and support generated with the help of OpenAI's ChatGPT.
//// code attribution
//// W3schools
////https://www.w3schools.com/cs/index.php

//// code attribution
////Bootswatch
////https://bootswatch.com/

//// code attribution
//// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio

//// code attribution
//// https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-8.0&tabs=visual-studio

//// code attribution
//// https://youtu.be/qvsWwwq2ynE?si=vwx2O4bCAFDFh5m_