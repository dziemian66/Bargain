using Bargain.Domain.Model;
using Bargain.Domain.Model.Addresses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Type = Bargain.Domain.Model.Type;

namespace Bargain.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRating> UserRating { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(a => a.Address).WithOne(b => b.User)
                .HasForeignKey<Address>(c => c.UserRef);
            builder.Entity<Item>()
                .HasOne(a => a.Rating).WithOne(b => b.Item)
                .HasForeignKey<Rating>(c => c.ItemRef);

            builder.Entity<UserRating>()
                .HasKey(it => new { it.UserId, it.RatingId });
            builder.Entity<UserRating>()
                 .HasOne(it => it.User)
                 .WithMany(i => i.UserRatings)
                 .HasForeignKey(it => it.UserId)
                 .OnDelete(DeleteBehavior.ClientSetNull);
            builder.Entity<UserRating>()
                 .HasOne(it => it.Rating)
                 .WithMany(i => i.UserRatings)
                 .HasForeignKey(it => it.RatingId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Item>().Property(a => a.Price).HasPrecision(10,2);
            builder.Entity<Item>().Property(a => a.EarlierPrice).HasPrecision(10,2);
            base.OnModelCreating(builder);
        }
    }
}
