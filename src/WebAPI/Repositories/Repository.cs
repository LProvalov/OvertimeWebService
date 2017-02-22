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

        public ICollection<DayEvent> GetAllDayEvent()
        {
            return _context.DayEvents.ToArray();
        }

        public DayEvent GetDayEvent(long id)
        {
            return _context.DayEvents.Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<DayEvent> GetAllDayEventsByUser(long ownerId)
        {
            foreach(var val in _context.DayEvents.Where(o => o.User.Id == ownerId).ToArray())
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

        public User GetUser(long userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }

        public bool UpdateUser(User model)
        {
            var updatedUser = _context.Users.FirstOrDefault(u => u.Id == model.Id);
            if(updatedUser != null)
            {
                updatedUser.Update(model);
                _context.Entry(updatedUser).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public User CreateUser(User model)
        {
            var entityEntry = _context.Users.Add(model);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public bool DeleteUser(User model)
        {
            var entity = _context.Users.FirstOrDefault(o => o.Id == model.Id);
            if(entity != null)
            {
                _context.Users.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


    }
}
