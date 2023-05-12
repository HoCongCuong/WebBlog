using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
    public class Account : Controller
    {
        public IActionResult login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
