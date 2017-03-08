using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Repositories.Interfaces;
using WebAPI.Repositories.Entities;
using WebAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class RepositoryUserOfService : IRepositoryUserOfService
    {
        private Context _context;
        public RepositoryUserOfService(Context context)
        {
            this._context = context;
        }
        public UserOfService CreateUser(UserOfService model)
        {
            var entryEntity = _context.UsersOfService.Add(model);
            _context.SaveChanges();
            return entryEntity.Entity;
        }

        public bool DeleteUser(UserOfService model)
        {
            var entity = _context.UsersOfService.FirstOrDefault(us => us.Id == model.Id);
            if(entity != null)
            {
                _context.UsersOfService.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<UserOfService> ReadAllUsers()
        {
            return _context.UsersOfService.ToArray();
        }

        public UserOfService ReadUser(long userId)
        {
            return _context.UsersOfService.FirstOrDefault(us => us.Id == userId);
        }

        public ICollection<UserOfService> ReadUsersPaging(int pageSize, int pageNumber, Sorting sortOrder)
        {
            int skipCount = pageSize * (pageNumber - 1);
            Func<UserOfService, string> getKey = u => {
                if(!String.IsNullOrEmpty(u.Username)) return u.Username;
                return u.Email;
            };
            return _context.UsersOfService.OrderBy<UserOfService, string>(getKey)
                .Skip(skipCount).Take(pageSize).ToArray();
        }

        public bool UpdateUser(UserOfService model)
        {
            var updatingEntity = _context.UsersOfService.FirstOrDefault(u => u.Id == model.Id);
            if(updatingEntity != null)
            {
                updatingEntity.Update(model);
                _context.Entry(updatingEntity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
