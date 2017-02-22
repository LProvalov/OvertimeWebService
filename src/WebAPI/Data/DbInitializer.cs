using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services;

namespace WebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(OvertimeContext context)
        {
            context.Database.EnsureCreated();
            if (context.DayEvents.Any())
            {
                return;
            }

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

            var users = new User[]
            {
                new User() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "Carlson.Alex@gmail.com", Username ="ACarlson", Role = roles[0] },
                new User() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "Nasonov123@mail.ru", Username="super777", Role = roles[0] },
                new User() { CryptedPassword = PasswordCrypt.CreateDbPassword("qwerty123"), Email = "TarasBulba@gmail.com", Username="Taras91", Role = roles[0] },
                new User() { CryptedPassword = PasswordCrypt.CreateDbPassword("manager"), Email = "mail@mail.com", Username="vasyka111", Role = roles[1] }
            };
            foreach(var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();

            var dayEvents = new DayEvent[]
            {
                new DayEvent() { User = users[0], Date = new DateTime(2017, 1, 9), Comment = "do something 9 of January", Overtime = 120 },
                new DayEvent() { User = users[0], Date = new DateTime(2017, 1, 10), Comment = "do something 10 of January", Overtime = 120 },
                new DayEvent() { User = users[0], Date = new DateTime(2017, 1, 18), Comment = "do something 18 of January", Overtime = 120 },
                new DayEvent() { User = users[0], Date = new DateTime(2017, 2, 27), Comment = "do something 27 of February", Overtime = 240 },
                new DayEvent() { User = users[0], Date = new DateTime(2017, 2, 28), Comment = "do something 28 of February", Overtime = 240 },
                //---
                new DayEvent() { User = users[1], Date = new DateTime(2017, 2, 6), Comment = "do something 6 of February", Overtime = 120 },
                new DayEvent() { User = users[1], Date = new DateTime(2017, 2, 8), Comment = "do something 8 of February", Overtime = 60 },
                new DayEvent() { User = users[1], Date = new DateTime(2017, 2, 17), Comment = "do something 17 of February", Overtime = 60 },
                new DayEvent() { User = users[1], Date = new DateTime(2017, 2, 27), Comment = "do something 27 of February", Overtime = 240 },
                new DayEvent() { User = users[1], Date = new DateTime(2017, 2, 28), Comment = "do something 28 of February", Overtime = 240 },
                //---
                new DayEvent() { User = users[2], Date = new DateTime(2017, 1, 11), Comment = "do something 11 of January", Overtime = 30 },
                new DayEvent() { User = users[2], Date = new DateTime(2017, 1, 12), Comment = "do something 12 of January", Overtime = 60 },
                new DayEvent() { User = users[2], Date = new DateTime(2017, 1, 18), Comment = "do something 18 of January", Overtime = 60 },
                new DayEvent() { User = users[2], Date = new DateTime(2017, 2, 13), Comment = "do something 13 of February", Overtime = 240 },
                new DayEvent() { User = users[2], Date = new DateTime(2017, 2, 14), Comment = "do something 14 of February", Overtime = 60 },
            };
            foreach(var dayEvent in dayEvents)
            {
                context.DayEvents.Add(dayEvent);
            }
            context.SaveChanges();
        }
        
    }
}
