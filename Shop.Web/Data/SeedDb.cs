using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;
        private readonly IUserHelper userHelper;
       
        public SeedDb(DataContext context,IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            var user = await this.userHelper.GetUserByEmailAsync("andresdesarrollo1997@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Andres",
                    LastName = "Yepes",
                    Email = "andresdesarrollo1997@gmail.com",
                    UserName = "andresdesarrollo1997@gmail.com",
                    PhoneNumber = "3104682576"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iphone x",user);
                this.AddProduct("Magic Mouse",user);
                this.AddProduct("iwatch series 4",user);
                await this.context.SaveChangesAsync();

            }
        }

        private void AddProduct(string name,User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}

