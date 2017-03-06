using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Repositories.Entities;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            //if (context.DayEvents.Any())
            //{
            //    return;
            //}

            var roles = new Role[]
            {
                new Role() { Name = "Employee" },
                new Role() { Name = "Manager"}
            };

            foreach(var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var users = new UserOfService[]
            {
                new UserOfService() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "Carlson.Alex@gmail.com", Username ="ACarlson", Role = roles[0] },
                new UserOfService() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "Nasonov123@mail.ru", Username="super777", Role = roles[0] },
                new UserOfService() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "TarasBulba@gmail.com", Username="Taras91", Role = roles[0] },
                new UserOfService() { CryptedPassword = PasswordCrypt.CreateDbPassword("manager"), Email = "mail@mail.com", Username="vasyka111", Role = roles[1] }
            };
            foreach(var user in users)
            {
                context.UsersOfService.Add(user);
            }
            context.SaveChanges();

            context.SaveChanges();
        }
        
    }
}
