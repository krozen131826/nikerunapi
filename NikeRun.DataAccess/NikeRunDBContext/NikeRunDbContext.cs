using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NikeRun.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikeRun.DataAccess.NikeRunDBContext
{
    public class NikeRunDbContext : DbContext
    {
        public NikeRunDbContext(DbContextOptions<NikeRunDbContext> option) : base(option)
        {

        }

        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<Products> Products { get; set; } = null!;
        public DbSet<Carts> Carts { get; set; } = null!;
        public DbSet<Images> Images { get; set; } = null!;
        public DbSet<ProductDetails> ProductDetails { get; set; } = null!;
        public DbSet<RefreshTokens> RefreshToken { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NikeRunDbContext).Assembly);

            modelBuilder.Entity<Products>()
                .HasData(
               new Products()
               {
                   Id = 1,
                   ProductName = "Nike Air Max SYSTM",
                   Category = "Kids",

               },   
               new Products()
               {
                   Id = 2,
                   Category = "Kids",
                   ProductName = "Nike Air Zoom Pegasus 39",

               },
               new Products()
               {
                   Id = 3,
                   Category = "Mens",
                   ProductName = "Nike Winflo 8",

               },
               new Products()
               {
                   Id = 4,
                   Category = "Mens",
                   ProductName = "Nike ZoomX Vaporfly Next 2",
               },
               new Products()
               {
                   Id = 5,
                   Category = "Mens",
                   ProductName = "Nike ZoomX Streakfly",
               },
               new Products()
               {
                   Id = 6,
                   Category = "Womens",
                   ProductName = "Nike ZoomX Invincible Run Flyknit 2",
               },
               new Products()
               {
                   Id = 7,
                   Category = "Womens",
                   ProductName = "Nike ZoomX Streakfly",
               }

            );


            modelBuilder.Entity<ProductDetails>()
            .HasData(
                new ProductDetails()
                {
                    Id = 1,
                    Price = 3500,
                    Description = "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.",
                    ProductId = 1,
                    Size = 8
                },
                new ProductDetails()
                {
                    Id = 2,
                    Price = 3500,
                    Description = "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.",
                    ProductId = 1,
                    Size = 9
                },
                new ProductDetails()
                {
                    Id = 3,
                    Price = 3500,
                    Description = "Cassette mixtapes. Music videos on TV. Shopping centre arcades. The '80s were fun and wild! We're celebrating that wicked cool era with the Nike Air Max SYSTM. From the big and bold Air unit to design lines (inspired by our favourite throwback Air Max shoes), it's all about bringing back what's cool to a new generation.",
                    ProductId = 1,
                    Size = 10
                },
                new ProductDetails()
                {
                    Id = 4,
                    Price = 5000,
                    Description = "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile",
                    ProductId = 2,
                    Size = 8
                },
                 new ProductDetails()
                 {
                     Id = 5,
                     Price = 5000,
                     Description = "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile",
                     ProductId = 2,
                     Size = 9
                 },
                  new ProductDetails()
                  {
                      Id = 6,
                      Price = 5000,
                      Description = "The Nike Air Zoom Pegasus 39 is made for runners of ALL levels—from athletics speedsters to freeze tig champs. Chase your goals with an extra bounce to your stride thanks to our innovative Zoom Air. It's also breathable up top and snug around the laces so you can feel cool, comfortable and confident with every mile",
                      ProductId = 2,
                      Size = 10
                  },
                  new ProductDetails()
                  {
                      Id = 7,
                      Price = 8500,
                      Description = "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.",
                      ProductId = 3,
                      Size = 8
                  },
                  new ProductDetails()
                  {
                      Id = 8,
                      Price = 8500,
                      Description = "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.",
                      ProductId = 3,
                      Size = 9
                  },
                  new ProductDetails()
                  {
                      Id = 9,
                      Price = 8500,
                      Description = "If running is a daily habit, you need support to match your speed. The Nike Winflo 8 brings back the cushioning you love and pairs it with details like a translucent upper and Flywire technology for a snug, stable fit for long road runs.",
                      ProductId = 3,
                      Size = 10
                  },
                  new ProductDetails()
                  {
                      Id = 10,
                      Price = 9000,
                      Description = "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.",
                      ProductId = 4,
                      Size = 8
                  },
                  new ProductDetails()
                  {
                      Id = 11,
                      Price = 9000,
                      Description = "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.",
                      ProductId = 4,
                      Size = 9
                  },
                  new ProductDetails()
                  {
                      Id = 12,
                      Price = 9000,
                      Description = "Continue the next evolution of speed with a racing shoe made to help you chase new goals and records. It helps improve comfort and breathability with a redesigned upper. From a 10K to a marathon, this model, like the previous version, has the responsive cushioning and secure support to push you towards your personal best.",
                      ProductId = 4,
                      Size = 10
                  },
                  new ProductDetails()
                  {
                      Id = 13,
                      Price = 9500,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.",
                      ProductId = 5,
                      Size = 8
                  },
                  new ProductDetails()
                  { 
                      Id = 14,
                      Price = 9500,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.",
                      ProductId = 5,
                      Size = 9
                  },
                  new ProductDetails()
                  {
                      Id = 15,
                      Price = 9500,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best. Pops of bright colour add a fun refresh, so you can turn heads at the finishing line.",
                      ProductId = 5,
                      Size = 10
                  },
                  new ProductDetails()
                  {
                      Id = 16,
                      Price = 7500,
                      Description = "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.",
                      ProductId = 6,
                      Size = 8
                  },
                  new ProductDetails()
                  {
                      Id = 17,
                      Price = 7500,
                      Description = "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.",
                      ProductId = 6,
                      Size = 9
                  },
                  new ProductDetails()
                  {
                      Id = 18,
                      Price = 7500,
                      Description = "Keep pushing your runs to the limit. The Nike ZoomX Invincible Run Flyknit 2 keeps you going with the same super-soft feel that lets you feel the potential when your foot hits the pavement. We created the shoe with plenty of springy responsiveness and our highest level of support to keep you feeling secure and competitive. It's one of our most tested shoes, still designed for you to stay on the road and away from the sidelines.",
                      ProductId = 6,
                      Size = 10
                  },
                  new ProductDetails()
                  {
                      Id = 19,
                      Price = 7000,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.",
                      ProductId = 7,
                      Size = 8
                  },
                  new ProductDetails()
                  {
                      Id = 20,
                      Price = 7000,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.",
                      ProductId = 7,
                      Size = 9
                  },
                  new ProductDetails()
                  {
                      Id = 21,
                      Price = 7000,
                      Description = "Our lightest racing shoe, the Nike ZoomX Streakfly is all about the speed you need to take on the competition in a mile, 5K or 10K race. Low profile with sleek details, it feels like it disappears on your foot to help you better connect with the road on the way to your personal best.",
                      ProductId = 7,
                      Size = 10
                  }
                );
            modelBuilder.Entity<Images>()
             .HasData(
               new Images()
               {
                   Id = 1,
                   ProductId = 1,
                   ImageLink = "https://i.postimg.cc/28QHckXP/Nike-Air-Max-SYSTM-1.png"

               },
                new Images()
                {
                    Id = 2,
                    ProductId = 1,
                    ImageLink = "https://i.postimg.cc/qvp1WPPg/Nike-Air-Max-SYSTM-2.png"

                },
                new Images()
                {
                    Id = 3,
                    ProductId = 1,
                    ImageLink = "https://i.postimg.cc/Prs3QpKW/Nike-Air-Max-SYSTM-3.png"

                },
                new Images()
                {
                    Id = 4,
                    ProductId = 1,
                    ImageLink = "https://i.postimg.cc/3x9thLh1/Nike-Air-Max-SYSTM-4.png"

                },
                new Images()
                {
                    Id = 5,
                    ProductId = 1,
                    ImageLink = "https://i.postimg.cc/VsbZtB9s/Nike-Air-Max-SYSTM-5.png"

                },
                 new Images()
                 {
                     Id = 6,
                     ProductId = 2,
                     ImageLink = "https://i.postimg.cc/MGCVJRnt/Nike-Air-Zoom-Pegasus-39-1.png"

                 },
                  new Images()
                  {
                      Id = 7,
                      ProductId = 2,
                      ImageLink = "https://i.postimg.cc/76S7H674/Nike-Air-Zoom-Pegasus-39-2.png"

                  },
                  new Images()
                  {
                      Id = 8,
                      ProductId = 2,
                      ImageLink = "https://i.postimg.cc/2ymWVDFZ/Nike-Air-Zoom-Pegasus-39-3.png"

                  },
                  new Images()
                  {
                      Id = 9,
                      ProductId = 2,
                      ImageLink = "https://i.postimg.cc/sf9SbMs9/Nike-Air-Zoom-Pegasus-39-4.png",

                  },
                  new Images()
                  {
                      Id = 10,
                      ProductId = 2,
                      ImageLink = "https://i.postimg.cc/KjNMTHJs/Nike-Air-Zoom-Pegasus-39-5.png"

                  },
                  new Images()
                  {
                      Id = 11,
                      ProductId = 3,
                      ImageLink = "https://i.postimg.cc/85bwHJC7/Nike-Winflo-8-1.png"

                  },
                  new Images()
                  {
                      Id = 12,
                      ProductId = 3,
                      ImageLink = "https://i.postimg.cc/yxYjr1Jv/Nike-Winflo-8-2.png"

                  },
                  new Images()
                  {
                      Id = 13,
                      ProductId = 3,
                      ImageLink = "https://i.postimg.cc/kG1c00K9/Nike-Winflo-8-3.png"

                  },
                  new Images()
                  {
                      Id = 14,
                      ProductId = 3,
                      ImageLink = "https://i.postimg.cc/Pr7y2kdQ/Nike-Winflo-8-4.png"

                  },
                  new Images()
                  {
                      Id = 15,
                      ProductId = 3,
                      ImageLink = "https://i.postimg.cc/Y2bbLWVV/Nike-Winflo-8-5.png"

                  },
                  new Images()
                  {
                      Id = 16,
                      ProductId = 4,
                      ImageLink = "https://i.postimg.cc/Nf40QRDC/Nike-Zoom-X-Streakfly-1.png",

                  },
                  new Images()
                  {
                      Id = 17,
                      ProductId = 4,
                      ImageLink = "https://i.postimg.cc/Kctzs6M2/Nike-Zoom-X-Streakfly-2.png"

                  },
                  new Images()
                  {
                      Id = 18,
                      ProductId = 4,
                      ImageLink = "https://i.postimg.cc/TYGw8tVW/Nike-Zoom-X-Streakfly-3.png"

                  },
                  new Images()
                  {
                      Id = 19,
                      ProductId = 4,
                      ImageLink = "https://i.postimg.cc/XY17C3Tw/Nike-Zoom-X-Streakfly-4.png"

                  },
                  new Images()
                  {
                      Id = 20,
                      ProductId = 4,
                      ImageLink = "https://i.postimg.cc/3xxxNWb8/Nike-Zoom-X-Streakfly-5.png"

                  },
                  new Images()
                  {
                      Id = 21,
                      ProductId = 5,
                      ImageLink = "https://i.postimg.cc/bJBQCKDb/zoomx-streakfly-1.png"

                  },
                  new Images()
                  {
                      Id = 22,
                      ProductId = 5,
                      ImageLink = "https://i.postimg.cc/7663Nx6w/zoomx-streakfly-2.png"

                  },
                  new Images()
                  {
                      Id = 23,
                      ProductId = 5,
                      ImageLink = "https://i.postimg.cc/6q4CDYnP/zoomx-streakfly-3.png"

                  },
                  new Images()
                  {
                      Id = 24,
                      ProductId = 5,
                      ImageLink = "https://i.postimg.cc/Th8nGgc3/zoomx-streakfly-4.png"

                  },
                  new Images()
                  {
                      Id = 25,
                      ProductId = 5,
                      ImageLink = "https://i.postimg.cc/XNrhjWgR/zoomx-streakfly-5.png"

                  },
                  new Images()
                  {
                      Id = 26,
                      ProductId = 6,
                      ImageLink = "https://i.postimg.cc/YSw1LYxV/Nike-Zoom-X-Invincible-Run-Flyknit-2-1.png"

                  },
                  new Images()
                  {
                      Id = 27,
                      ProductId = 6,
                      ImageLink = "https://i.postimg.cc/QxwgsRKj/Nike-Zoom-X-Invincible-Run-Flyknit-2-2.png"

                  },
                  new Images()
                  {
                      Id = 28,
                      ProductId = 6,
                      ImageLink = "https://i.postimg.cc/9Q9dfJyZ/Nike-Zoom-X-Invincible-Run-Flyknit-2-3.png",

                  },
                  new Images()
                  {
                      Id = 29,
                      ProductId = 6,
                      ImageLink = "https://i.postimg.cc/vTD9wzQ1/Nike-Zoom-X-Invincible-Run-Flyknit-2-4.png"

                  },
                  new Images()
                  {
                      Id = 30,
                      ProductId = 6,
                      ImageLink = "https://i.postimg.cc/XJsFPh0S/Nike-Zoom-X-Invincible-Run-Flyknit-2-5.png"
                  },
                  new Images()
                  {
                      Id = 31,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/cL6s7bFt/Nike-Zoom-X-Streakfly-1.png"

                  },
                  new Images()
                  {
                      Id = 32,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/nh5n3GWR/Nike-Zoom-X-Streakfly-2.png"

                  },
                  new Images()
                  {
                      Id = 33,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/d1cwYtwG/Nike-Zoom-X-Streakfly-3.png"

                  },
                  new Images()
                  {
                      Id = 34,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/wM0pLXJk/Nike-Zoom-X-Streakfly-4.png"

                  },
                  new Images()
                  {
                      Id = 35,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/j2sTDgW5/Nike-Zoom-X-Streakfly-5.png"

                  },
                  new Images()
                  {
                      Id = 36,
                      ProductId = 7,
                      ImageLink = "https://i.postimg.cc/vB7MHFZk/Nike-Zoom-X-Streakfly-6.png"

                  }

               );
            base.OnModelCreating(modelBuilder);
        }


    }
}
