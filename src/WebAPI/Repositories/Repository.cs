using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI
{
    public class Repository : IRepository
    {
        private readonly OvertimeContext _context;

        public Repository(OvertimeContext context)
        {
            _context = context;
        }
        public DayEvent CreateDayEvent(DayEvent model)
        {
            _context.DayEvents.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteDayEvent(DayEvent model)
        {
            var item = _context.DayEvents.Where(o => o.Id == model.Id).FirstOrDefault();
            if (item != null)
            {
                _context.DayEvents.Remove(item);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public DayEvent GetDayEvent(long id)
        {
            return _context.DayEvents.Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<DayEvent> GetDayEventsByUser(long ownerId)
        {
            foreach(var val in _context.DayEvents.Where(o => o.Owner.Id == ownerId).ToArray())
            {
                yield return val;
            }
        }

        public bool UpdateDayEvent(DayEvent model)
        {
            var updatingDayEvent = _context.DayEvents.FirstOrDefault(o => o.Id == model.Id);
            if(updatingDayEvent != null)
            {
                updatingDayEvent.Update(model);
                _context.Entry(updatingDayEvent).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
