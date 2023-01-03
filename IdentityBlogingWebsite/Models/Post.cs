﻿using System.ComponentModel.DataAnnotations;

namespace IdentityBlogingWebsite.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string SubTitle { get; set; }
        [Required] 
        public string Content { get; set; }

        public DateTime Date { get; set; }
        public string Image { get; set; } = "star.png";
        public string? appUserid { get; set; }
        public AppUser? appUser { get; set; }

    }
}
