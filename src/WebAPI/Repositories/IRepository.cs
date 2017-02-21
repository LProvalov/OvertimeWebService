using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI
{
    public interface IRepository
    {
        IEnumerable<DayEvent> GetDayEventsByUser(long ownerId);
        DayEvent GetDayEvent(long id);
        bool UpdateDayEvent(DayEvent model);
        DayEvent CreateDayEvent(DayEvent model);
        bool DeleteDayEvent(DayEvent model);
    }
}
