using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace DataLayer
{
    public class FrutinContext : DbContext
    {
        public FrutinContext() : base("FrutinContext")
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Link> Link { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<BlogTag> BlogTag { get; set; }
        public DbSet<ProductTag> ProductTag { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<ChildHeaderMenu> ChildHeaderMenu { get; set; }

        // header models :
        public DbSet<HeaderMenu> HeaderMenu { get; set; }
        public DbSet<HeaderNotification> HeaderNotification { get; set; }
        // end header models

        // subcribe news email 
        public DbSet<NewsEmail> NewsEmail { get; set; }
        // end sunbscribe news email

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(c => c.Shop)
                .WithRequired(a => a.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
