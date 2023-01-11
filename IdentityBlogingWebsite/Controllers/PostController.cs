using IdentityBlogingWebsite.Data;
using IdentityBlogingWebsite.Models;
using IdentityBlogingWebsite.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityBlogingWebsite.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _context;
        private IWebHostEnvironment env;
        public PostController(ApplicationDbContext context, IWebHostEnvironment environment) {
            _context = context;
             env = environment;
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
        public IActionResult CreatePost(PostViewModel post)
        {  
        if(ModelState.IsValid)
            {
        //   string ImageName = post.Image.FileName.ToString();
           var FolderPath = Path.Combine(env.WebRootPath, "images");
           string ImageName = Guid.NewGuid() + ".jpg";
           var CompletePicPath = Path.Combine(FolderPath, ImageName);
           post.Image.CopyTo(new FileStream(CompletePicPath, FileMode.Create));
           Post mypost = new Post();
            mypost.Title = post.Title;
                mypost.SubTitle = post.SubTitle;
                mypost.Content = post.Content;
                mypost.Image = ImageName;
                mypost.Date = post.Date;
            _context.Tbl_Post.Add(mypost);
            _context.SaveChanges();
        }
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            post.appUserid = userId;
           //_context.Tbl_Post.Add(post);
           //_context.SaveChanges();
            return RedirectToAction("AllPosts", "Home");
        }
    }
}
