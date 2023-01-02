using IdentityBlogingWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityBlogingWebsite.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options): base(options)
        {
             
        }

        public DbSet<Post> Tbl_Post { get; set; }
        public DbSet<Profile> Tbl_Profile { get; set; }
    }
}
