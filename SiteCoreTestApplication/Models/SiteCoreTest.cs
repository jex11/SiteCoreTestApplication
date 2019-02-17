namespace SiteCoreTestApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SiteCoreTest : DbContext
    {
        public SiteCoreTest()
            : base("name=SiteCoreTest")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.UserEmail)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserCreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserUpdatedBy)
                .IsUnicode(false);
        }
    }
}
