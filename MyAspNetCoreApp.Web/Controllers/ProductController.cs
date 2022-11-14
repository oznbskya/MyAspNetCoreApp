using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();

            if(!_productRepository.GetAll().Any())
            {
                _productRepository.Add(new() { Id = 1, Name = "Kalem 1", Price = 100, Stock = 100 });
                _productRepository.Add(new() { Id = 2, Name = "Kalem 2", Price = 150, Stock = 200 });
                _productRepository.Add(new() { Id = 3, Name = "Kalem 3", Price = 200, Stock = 300 });
            }
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll();

            return View(products);
        }
    }
}
