using IdentityBlogingWebsite.Models;

namespace IdentityBlogingWebsite.ViewModels
{
    public class PostViewModel
    {
        
      
        public string Title { get; set; }

        
        public string SubTitle { get; set; }
       
        public string Content { get; set; }

        public String Date { get; set; }
        public IFormFile Image { get; set; }
        public string? appUserid { get; set; }
        public AppUser? appUser { get; set; }

    }
}
