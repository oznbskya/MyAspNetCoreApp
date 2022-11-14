using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            // ViewBag Veri Aktarma
            ViewBag.name = "Ozan Başkaya";
            ViewBag.person = new { Id = 1, Name = "Ozan", Age = 32 };

            // ViewData Veri Aktarma
            ViewData["names"] = new List<string>() { "ozan", "esra", "gönül" };

            // TempData Veri Aktarma
            TempData["Soyad"] = "Başkaya";

            // ViewModel Veri Aktarma
            var productList = new List<Product2>()
            {
                new() { Id=1, Name="Ozan" },
                new() { Id=2, Name="Esra" },
                new() { Id=3, Name="Gönül" }
            };

            return View(productList);
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index");
        }

        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParametre", "Ornek", new { id = id });
        }

        public IActionResult JsonResultParametre(int id)
        {
            return Json(new { Id = id });
        }

        public IActionResult ContentResult()
        {
            return Content("Merhaba!");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "ozan", age = 32 });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
