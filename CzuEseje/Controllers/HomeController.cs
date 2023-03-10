using CzuEseje.Areas.Identity.Data;
using CzuEseje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CzuEseje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public string contentRootPath { get; }
        public string webRootPath { get; }
        public string projectRootPath { get; }

        public HomeController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment env, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            contentRootPath = env.ContentRootPath;
            webRootPath = env.WebRootPath;
            projectRootPath = AppContext.BaseDirectory;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Eseje()
        {
            IEnumerable<Esej> posts = _db.Eseje.ToList();
            ViewBag.posts = posts;
            return View(posts);
        }
        public IActionResult Uzivatele()
        {
            var users = _userManager.Users;
            return View(users);
        }
        public IActionResult Knihy()
        {
            ICollection<Source> sources = _db.Source.ToList();
            return View(sources);
        }
        public IActionResult Test()
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