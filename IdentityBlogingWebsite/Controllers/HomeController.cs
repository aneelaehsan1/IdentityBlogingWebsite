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

            //IEnumerable<Post> myPost = tdb.Tbl_Post;
            var myPost = _context.Tbl_Post.ToList();
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

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Post postobj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Tbl_Post.Add(postobj);
        //        _context.SaveChanges();
        //        TempData["ResultOk"] = "Record Added Successfully !";
        //        return RedirectToAction("Index");
        //    }

        //    return View(postobj);
        //}

        //public IActionResult Post()
        //{
        // SharedLayOutData();
        //    var DetailedPost = _tdb.Tbl_Post.Where(x => x.Slug == Slug).FirstOrDefault();
        //   return View(DetailedPost);
        //    return View();
        //}
        //}
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var postfromdb = _context.Tbl_Post.Find(id);

        //    if (postfromdb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(postfromdb);

        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Post postobj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Tbl_Post.Update(postobj);
        //        _context.SaveChanges();
        //        TempData["ResultOk"] = "Data Updated Successfully !";
        //        return RedirectToAction("Index");
        //    }

        //    return View(postobj);
        //}
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var postfromdb = _context.Tbl_Post.Find(id);

        //    if (postfromdb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(postfromdb);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteEmp(int? id)
        //{
        //    var deleterecord = _context.Tbl_Post.Find(id);
        //    if (deleterecord == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Tbl_Post.Remove(deleterecord);
        //    _context.SaveChanges();
        //    TempData["ResultOk"] = "Data Deleted Successfully !";
        //    return RedirectToAction("Index");
        //}
    }
}