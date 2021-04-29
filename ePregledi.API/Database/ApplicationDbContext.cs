using ePregledi.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ePregledi.API.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
