using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PixivClone.Models
{
    public partial class UserDbContext : DbContext, IDbContext
    {
        static UserDbContext()
        {
            Database.SetInitializer<UserDbContext>(null);
        }

        public UserDbContext()
            : base("Name=UserDbContext")
        {
        }

        public DbSet<User> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
        }
    }

    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.Username)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("userid");
            this.Property(t => t.Username).HasColumnName("username");
        }
    }
}