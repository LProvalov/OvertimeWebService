using System.Collections.Generic;
using System.Linq;
using WebAPI.Repositories.Interfaces;
using WebAPI.Repositories.Entities;
using WebAPI.Enums;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Repositories
{
    public class RepositorySharedListData : IRepositorySharedListData
    {
        private Context _context;
        public RepositorySharedListData(Context context)
        {
            this._context = context;
        }
        public SharedListData CreateSharedListData(SharedListData model)
        {
            var entryEntity = _context.Datas.Add(model);
            _context.SaveChanges();
            return entryEntity.Entity;
        }

        public bool DeleteSharedListData(SharedListData model)
        {
            var entity = _context.Datas.FirstOrDefault(d => d.Id == model.Id);
            if(entity != null)
            {
                _context.Datas.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SharedListData> ReadAll(long sharedListId, bool includeActiveOnly = true)
        {
            return _context.Datas
                .Where(d => d.SharedListId == sharedListId && 
                (includeActiveOnly ? d.IsActive : false)).ToArray();
        }

        public SharedListData ReadSharedListData(long sharedListDataIs)
        {
            return _context.Datas.FirstOrDefault(d => d.Id == sharedListDataIs);
        }

        public bool UpdateSharedListData(SharedListData model)
        {
            var updatingData = _context.Datas.FirstOrDefault(d => d.Id == model.Id);
            if(updatingData != null)
            {
                updatingData.Update(model);
                _context.Entry(updatingData).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
