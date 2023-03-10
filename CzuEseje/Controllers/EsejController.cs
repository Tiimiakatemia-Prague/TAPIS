using CzuEseje.Areas.Identity.Data;
using CzuEseje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CzuEseje.Controllers
{
    public class EsejController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public string contentRootPath { get; }
        public string webRootPath { get; }
        public string projectRootPath { get; }

        public EsejController(ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment env, ApplicationDbContext db)
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
            IEnumerable<Esej> posts = _db.Eseje.Include(x=>x.User).ToList();
            ViewBag.posts = posts;
            return View(posts);
        }
        public IActionResult Zobrazit(int id)
        {
            Esej esej = _db.Eseje.Where(x => x.Id == id).Include(x=>x.User).FirstOrDefault();
            return View(esej);
        }
        public IActionResult Edit(int id)
        {
            Esej esej = new Esej();
            ViewBag.Sources = _db.Source.ToList();
            if (id > 0)
            {
                esej = _db.Eseje.Where(x=>x.Id == id).FirstOrDefault();
            } else 
            {
            }
            return View(esej);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleEsejForm(Esej esej,int selSource)
        {
            ModelState.Remove("User");//you can find the error key by stepping though your code
            if (ModelState.IsValid)
            {
                if (selSource > 0)
                {
                    Source source = _db.Source.Where(x => x.Id == selSource).FirstOrDefault();
                    if (source != null) { esej.Source = source; }
                }
                if (esej.Id == 0)
                {
                    ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
                    if(applicationUser != null)
                    {
                        esej.User = applicationUser;
                    }
                    esej.DateC = DateTime.Now;
                    _db.Eseje.Add(esej);
                }
                else
                {
                    _db.Eseje.Update(esej);
                }

                _db.SaveChanges();
                return RedirectToAction("Index", "Esej");
            }
            ViewBag.Sources = _db.Source.ToList();
            return View("Edit", esej);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}