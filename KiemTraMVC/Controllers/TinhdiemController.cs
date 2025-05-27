using Microsoft.AspNetCore.Mvc;
using KiemTraMVC.Models;
namespace KiemTraMVC.Controllers
{
    public class TinhdiemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Tinhdiem model)
        { 
            if (ModelState.IsValid)
            model.result = (model.number1 * 60 + model.number2 * 30 + model.number3 * 10) / 100;
            return View(model);
        }
        
    }
}