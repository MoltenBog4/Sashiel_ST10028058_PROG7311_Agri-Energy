using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sashiel_ST10028058_PROG7311.Data;
using Sashiel_ST10028058_PROG7311.Models;

namespace Sashiel_ST10028058_PROG7311.Controllers
{
    [Authorize(Roles = "Farmer")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

            if (farmer == null)
                return NotFound("Farmer profile not found.");

            var products = await _context.Products
                .Where(p => p.FarmerId == farmer.Id)
                .ToListAsync();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile ImageFile)
        {
            var userId = _userManager.GetUserId(User);
            var farmer = await _context.Farmers.FirstOrDefaultAsync(f => f.UserId == userId);

            if (farmer == null)
                return NotFound("Farmer profile not found.");

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(ImageFile.FileName)}";
                var filePath = Path.Combine(_env.WebRootPath, "images/products", fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                product.ImagePath = $"/images/products/{fileName}";
            }

            product.FarmerId = farmer.Id;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
