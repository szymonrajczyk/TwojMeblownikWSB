using mebel.Data;
using mebel.Models;
using mebel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mebel.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FurnitureController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Furniture> furnitures = _context.Furnitures.ToList();
            return View(furnitures);
        }

        public IActionResult MyFurniture()
        {
            var curUserId = HttpContext.User.GetUserId();
            List<Furniture> furnitures = _context.Furnitures.Where(f => f.UserId == curUserId).ToList();
            return View(furnitures);
        }

        public IActionResult Detail(int id)
        {
            Furniture furniture = _context.Furnitures.Include(i => i.User).FirstOrDefault(f => f.Id == id);
            List<Furniture> relatedFurniture = _context.Furnitures.Where(f => f.Category == furniture.Category && f.Id != furniture.Id).ToList();
            return View(new DetailFurnitureViewModel { furniture = furniture, relatedFurnitures = relatedFurniture });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var curUserId = HttpContext.User.GetUserId();
            if (curUserId == null)
            {
                return View("Error");
            }

            return View(new CreateFurnitureViewModel { UserId = curUserId });
        }

        [HttpPost]
        public IActionResult Create(CreateFurnitureViewModel furnitureVM)
        {
            if (!ModelState.IsValid)
            {
                return View(furnitureVM);
            }

            Furniture furniture = new Furniture
            {
                Name = furnitureVM.Name,
                Tag = furnitureVM.Tag,
                Price = furnitureVM.Price,
                ImageUrl = furnitureVM.ImageUrl,
                UserId = furnitureVM.UserId,
                Category = furnitureVM.Category
            };

            _context.Add(furniture);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var curUserId = HttpContext.User.GetUserId();
            Furniture furniture = _context.Furnitures.Include(i => i.User).FirstOrDefault(f => f.Id == id);
            if (furniture == null || furniture.UserId != curUserId)
            {
                return View("Error");
            }

            return View(new EditFurnitureViewModel
            {
                ImageUrl = furniture.ImageUrl,
                Name = furniture.Name,
                Tag = furniture.Tag,
                Price = furniture.Price,
                Id = id,
                Category = furniture.Category
            });
        }

        [HttpPost]
        public IActionResult Edit(EditFurnitureViewModel furnitureVM)
        {
            if (!ModelState.IsValid)
            {
                return View(furnitureVM);
            }

            var curUserId = HttpContext.User.GetUserId();
            Furniture furniture = new Furniture
            {
                Id = furnitureVM.Id,
                Name = furnitureVM.Name,
                Tag = furnitureVM.Tag,
                Price = furnitureVM.Price,
                ImageUrl = furnitureVM.ImageUrl,
                UserId = curUserId,
                Category = furnitureVM.Category
            };

            _context.Update(furniture);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var curUserId = HttpContext.User.GetUserId();
            Furniture furniture = _context.Furnitures.Include(i => i.User).FirstOrDefault(f => f.Id == id);
            if (furniture == null || furniture.UserId != curUserId) return View("Error");
            return View(furniture);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteFurniture(int id)
        {
            var curUserId = HttpContext.User.GetUserId();
            Furniture furniture = _context.Furnitures.Include(i => i.User).FirstOrDefault(f => f.Id == id);

            if (furniture == null || furniture.UserId != curUserId)
            {
                return View("Error");
            }

            _context.Remove(furniture);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
