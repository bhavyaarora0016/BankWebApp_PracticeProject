using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<User> users = new List<User>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            users.Add(new User() { userId = "kanye_west@gmail.com", password = "west@0101" });
            users.Add(new User() { userId = "bhavya_arora@gmail.com", password = "arora@0101" });
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            User u = users.Find(rem => rem.userId == user.userId);
            if ( u!= null)
            {
                if(u.password == user.password)
                {
                   return RedirectToAction("Dashboard", "Home");  
                }
            }
            
                return View();
            
           
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}