using System;
using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Enums;

namespace WebAPI
{
    public interface IRepository
    {
        IEnumerable<DayEvent> GetAllDayEventsByUser(long ownerId);
        DayEvent GetDayEvent(long id);
        bool UpdateDayEvent(DayEvent model);
        DayEvent CreateDayEvent(DayEvent model);
        bool DeleteDayEvent(DayEvent model);
        ICollection<DayEvent> GetAllDayEvent();

        User GetUser(long userId);
        bool UpdateUser(User model);
        User CreateUser(User model);
        bool DeleteUser(User model);
        ICollection<User> GetAllUsers();
        ICollection<User> GetUsersPage(int pageSize, int pageNumber, Sorting sortOrder /* TODO: add parametr for sort (fieldName)*/);
    }
}
