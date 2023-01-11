using IdentityBlogingWebsite.Data;
using IdentityBlogingWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityBlogingWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context) 
        { 
           _context = context;
            _logger = logger;
           
        }

        public IActionResult Post()
        {
            return View();
        }

        public IActionResult AllPosts()
        {
            SharedLayOutData();
            //var myPost = _context.Tbl_Post;

            //return View(myPost);

            IEnumerable<Post> myPost = _context.Tbl_Post;
            //var myPost = _context.Tbl_Post.ToList();
            return View(myPost);

        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ReadPost(int Id)
        {
            SharedLayOutData();
            var DetailedPost = _context.Tbl_Post.Find(Id);
              return View(DetailedPost);
            //    return View();
            
        }
        public void SharedLayOutData()
        {
            ViewBag.Post = _context.Tbl_Post;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}