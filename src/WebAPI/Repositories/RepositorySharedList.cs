using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Repositories.Interfaces;
using WebAPI.Repositories.Entities;
namespace WebAPI.Repositories
{
    public class RepositorySharedList : IRepositorySharedList
    {
        private Context _context;
        public RepositorySharedList(Context context) {
            this._context = context;
        }
        public SharedList CreateSharedList(SharedList model)
        {
            var entityEntry = _context.SharedLists.Add(model);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public bool DeleteSharedList(SharedList model)
        {
            var entity = _context.SharedLists.FirstOrDefault(sl => sl.Id == model.Id);
            if(entity != null)
            {
                _context.SharedLists.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SharedList> ReadAllSharedLists(long ownerId)
        {
            return _context.SharedLists.Where(sl => sl.OwnerId == ownerId).ToArray();
        }

        public ICollection<SharedList> ReadAllSharedListsBySharedListIds(string sharedListIds)
        {
            if (String.IsNullOrEmpty(sharedListIds)) return null;
            List<long> ids = new List<long>();
            foreach (var idsStr in sharedListIds.Split(','))
            {
                try
                {
                    long id = Convert.ToInt64(idsStr);
                    ids.Add(id);
                } catch (OverflowException) {}
                catch (FormatException) {}
            }
            return _context.SharedLists.Where(sl => ids.Contains(sl.Id)).ToArray();
        }

        public ICollection<SharedList> ReadAllSharedListsViewed(long userId)
        {
            var user = _context.UsersOfService.FirstOrDefault(u => u.Id == userId);
            return ReadAllSharedListsBySharedListIds(user.SharedListIdsViewed);
        }

        public SharedList ReadSharedList(long sharedListId)
        {
            return _context.SharedLists.FirstOrDefault(sl => sl.Id == sharedListId);
        }

        public bool UpdateSharedList(SharedList model)
        {
            var updatingEntity = _context.SharedLists.FirstOrDefault(sl => sl.Id == model.Id);
            if(updatingEntity != null)
            {
                updatingEntity.Update(model);
                _context.Entry(updatingEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
