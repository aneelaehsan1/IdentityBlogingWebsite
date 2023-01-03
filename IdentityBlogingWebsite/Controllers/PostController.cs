using IdentityBlogingWebsite.Data;
using IdentityBlogingWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityBlogingWebsite.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _context;
        public PostController(ApplicationDbContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles="User")]
        public IActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult CreatePost(Post post)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            post.appUserid = userId;
            _context.Tbl_Post.Add(post);
            _context.SaveChanges();
            return RedirectToAction("Post","Home");
        }
    }
}
