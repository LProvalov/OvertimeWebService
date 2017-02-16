using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI
{
    public class Repository : IRepository
    {
        private static ConcurrentDictionary<long, DayEventModel> _dayEvents =
            new ConcurrentDictionary<long, DayEventModel>();
        private static long eventCount = 0;

        public Repository()
        {
            Func<long, DayEventModel, DayEventModel> updateFunc = ((id, model) => {
                return model;
            });
            _dayEvents.AddOrUpdate(1, new DayEventModel() { Id = 1, OwnerId = 0, Date = new DateTime(2017, 02, 10), Comment = "Comment. Day 10", Overtime = 90 }, updateFunc);
            _dayEvents.AddOrUpdate(2, new DayEventModel() { Id = 2, OwnerId = 0, Date = new DateTime(2017, 02, 12), Comment = "Comment. Day 12", Overtime = 120 }, updateFunc);
            _dayEvents.AddOrUpdate(3, new DayEventModel() { Id = 3, OwnerId = 0, Date = new DateTime(2017, 02, 15), Comment = "Comment. Day 15", Overtime = 180 }, updateFunc);
            _dayEvents.AddOrUpdate(4, new DayEventModel() { Id = 4, OwnerId = 0, Date = new DateTime(2017, 02, 16), Comment = "Comment. Day 16", Overtime = 90 }, updateFunc);
            _dayEvents.AddOrUpdate(5, new DayEventModel() { Id = 5, OwnerId = 0, Date = new DateTime(2017, 02, 21), Comment = "Comment. Day 21", Overtime = 30 }, updateFunc);
            eventCount = 5;
        }
        public DayEventModel CreateDayEvent(DayEventModel model)
        {
            eventCount++;
            model.Id = eventCount;
            _dayEvents.AddOrUpdate(eventCount, model, null);
            return model;
        }

        public bool DeleteDayEvent(DayEventModel model)
        {
            if (_dayEvents.ContainsKey(model.Id))
            {
                DayEventModel outModel;
                return _dayEvents.TryRemove(model.Id, out outModel);
            }
            return false;
        }

        public DayEventModel GetDayEvent(long id)
        {
            DayEventModel ret = null;
            _dayEvents.TryGetValue(id, out ret);
            return ret;
        }

        public IEnumerable<DayEventModel> GetDayEventsByUser(long ownerId)
        {
            foreach(var val in _dayEvents.Values)
            {
                if(val.OwnerId == ownerId)
                    yield return val;
            }
        }

        public bool UpdateDayEvent(DayEventModel model)
        {
            if (_dayEvents.ContainsKey(model.Id))
            {
                _dayEvents[model.Id] = model;
                return true;
            }
            return false;
        }
    }
}
