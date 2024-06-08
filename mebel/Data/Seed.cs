using mebel.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;

namespace mebel.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Furnitures.Any())
                {
                    context.Furnitures.AddRange(new List<Furniture>()
                    {
                        new Furniture()
                        {
                            Name = "Test",
                            Price = "100.00",
                            ImageUrl = "https://plus.unsplash.com/premium_photo-1673548917423-073963e7afc9?q=80&w=1171&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Tag = "Komoda"
                         },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
