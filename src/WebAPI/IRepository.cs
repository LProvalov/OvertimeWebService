using System;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI
{
    public interface IRepository
    {
        IEnumerable<DayEventModel> GetDayEventsByUser(long ownerId);
        DayEventModel GetDayEvent(long id);
        bool UpdateDayEvent(DayEventModel model);
        DayEventModel CreateDayEvent(DayEventModel model);
        bool DeleteDayEvent(DayEventModel model);
    }
}
