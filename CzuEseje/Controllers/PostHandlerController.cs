using Microsoft.AspNetCore.Mvc;

namespace CzuEseje.Controllers
{
    public class PostHandlerController : Controller
    {
        public PostHandlerController(IWebHostEnvironment env)
        {
            contentRootPath = env.ContentRootPath;
            webRootPath = env.WebRootPath;
            projectRootPath = AppContext.BaseDirectory;
        }

        public string contentRootPath { get; }
        public string webRootPath { get; }
        public string projectRootPath { get; }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult UploadImage(IFormFile file)
        {
            string webRootPathx = webRootPath;
            //file.SaveAs("<give it a name>");
            var uploads = Path.Combine(webRootPathx, "img");
            string uniquefilename = GetUniqueFileName(file.FileName);
            var fullPath = Path.Combine(uploads, uniquefilename);
            file.CopyTo(new FileStream(fullPath, FileMode.Create));
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //     file..CopyToAsync(stream);
            //}
            string postfileurl = "/../img/" + uniquefilename;
            return Json(new { location = postfileurl });
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
    }
}
