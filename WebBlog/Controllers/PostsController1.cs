using Microsoft.AspNetCore.Mvc;

namespace WebBlog.Controllers
{
    public class PostsController1 : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult reader()
        {
            return View();
        }
    }
}
