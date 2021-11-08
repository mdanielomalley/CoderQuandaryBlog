using CoderQuandaryBlog.Data;
using CoderQuandaryBlog.Enums;
using CoderQuandaryBlog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.Services
{
    public class DataService
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;


        //constructor injection - inversion of control
        public DataService(ApplicationDbContext dbContext, 
                           RoleManager<IdentityRole> roleManager, 
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //wrapper
        public async Task ManageDataAsync()
        {
            //Task 0: Create the Db from the migrations 
            await _dbContext.Database.MigrateAsync();

            //Task 1: Seed Roles into System
            await SeedRolesAsync();

            //Task 2: Seed Users into System
            await SeedUsersAsync();
        }


        private async Task SeedRolesAsync()
        {
            //If there are already roles in the system, do nothing.
            if (_dbContext.Roles.Any()) 
            {
                return;
            }

            //otherwise we want to create a few roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                //interact with the role manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }

            //role manager knows how to register roles in the system
        }

        private async Task SeedUsersAsync()
        {
            //If there are already users in the system, do nothing
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Step 1: Creates a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "m.daniel.omalley@gmail.com",
                UserName = "m.daniel.omalley@gmail.com",
                FirstName = "Dan",
                LastName = "O'Malley",
                EmailConfirmed = true

            };

            //Step 2: Use the UserManager to create to create a anew user that is defined by the adminUser variable
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step 3: Add this new user to the Administrator Role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


            //Step 1: Creates a new instance of BlogUser
            var modUser = new BlogUser()
            {
                Email = "m.d.omalley@outlook.com",
                UserName = "m.d.omalley@outlook.com",
                FirstName = "Daniel",
                LastName = "O'Malley",
                EmailConfirmed = true

            };

            //Step 2: Use the UserManager to create to create a anew user that is defined by the modUser variable
            await _userManager.CreateAsync(modUser, "Abc&123!");

            //Step 3: Add this new user to the Moderator Role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }






    }
}
