using Microsoft.AspNetCore.Mvc;

namespace FirstMvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // controller üzerinden view'a veri göndermek için kullanırız
        // ViewBag dynamic obje gibi çalışır. okunurluğu iyidir ama ViewData'ya göre yavaştır
        // ViewData dictionary gibi çalışır. hızlıdır.
        // TempData dictionary gibi çalışır ama 1 kere çalışır
        // ViewBag.Name = "Orhan";
        ViewData["Name"] = "Orhan";
        ViewData["BirthDate"] = 2000;
        
        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Add()
    {
        // belirli kontroller yaptım varsayalım
        TempData["ErrorMessage"] = "Bunu ekleyemem üzgünüm...";
        return RedirectToAction("Index");
    }
    
}