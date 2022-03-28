using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace mvcWithMosh.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }

        public DbSet<Customers> Customer { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MembershipType> MembershipType { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieRental> Rentals { get; set; }
    }
}