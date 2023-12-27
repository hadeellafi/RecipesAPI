using RecipesAPI.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace RecipesAPI.Data
{
    public class RecipesDbContext : IdentityDbContext<User>
    {
        public RecipesDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PostIngredient> PostIngredients { get; set; }

        public DbSet<Step> Steps { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>()
       .HasKey(l => new { l.UserID, l.PostID });

            builder.Entity<Follow>()
               .HasKey(f => new { f.UserID, f.FollowerID });
            builder.Entity<PostIngredient>()
              .HasKey(f => new { f.PostID, f.IngredientID });

            base.OnModelCreating(builder);
            builder.Entity<Comment>()
      .HasOne(c => c.User)
      .WithMany()
      .HasForeignKey(c => c.UserID)
      .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostID)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserID)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<Follow>()
                .HasOne(f => f.User)
                .WithMany(u => u.Following)
                .HasForeignKey(f => f.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Follow>()
                .HasOne(f => f.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.FollowerID)
                .OnDelete(DeleteBehavior.Restrict);
            //data seeding

            var user1 = new User { Id = "1", UserName = "User1",Email="user1@gmail.com", FullName = "User One", ProfilePicture = "pic1.jpg" };
            var user2 = new User { Id = "2", UserName = "User2", Email = "user2@gmail.com", FullName = "User Two", ProfilePicture = "pic2.jpg" };
            var user3 = new User { Id = "3", UserName = "User3", Email = "user3@gmail.com", FullName = "User Three", ProfilePicture = "pic3.jpg" };

            builder.Entity<User>().HasData(user1, user2, user3);

            var follow1 = new Follow { UserID = "1", FollowerID = "2" };
            var follow2 = new Follow { UserID = "1", FollowerID = "3" };
            var follow3 = new Follow { UserID = "2", FollowerID = "3" };

            builder.Entity<Follow>().HasData(follow1, follow2, follow3);

            var ingerdient1 = new Ingredient { IngredientID = 1, IngredientName = "Beef " };
            var ingerdient2 = new Ingredient { IngredientID = 2, IngredientName = "Chicken " };
            var ingerdient3 = new Ingredient { IngredientID = 3, IngredientName = "Cherry Tomatoes " };
            builder.Entity<Ingredient>().HasData(ingerdient1, ingerdient2, ingerdient3);
        }

    }
}
