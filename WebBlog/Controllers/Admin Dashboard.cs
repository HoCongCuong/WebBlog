using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
    public class Admin_Dashboard : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
