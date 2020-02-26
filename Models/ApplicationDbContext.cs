namespace ContactBook.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ContactModel")
        {
            Database.SetInitializer<ApplicationDbContext>(new CategoriesInitializer());
            
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
