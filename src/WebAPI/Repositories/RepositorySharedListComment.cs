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
    public class RepositorySharedListComment : IRepositorySharedListComment
    {
        private Context _context;
        public RepositorySharedListComment(Context context)
        {
            this._context = context;
        }
        public SharedListComment CreateSharedListComment(SharedListComment model)
        {
            var entryEntity = _context.Comments.Add(model);
            _context.SaveChanges();
            return entryEntity.Entity;
        }

        public bool DeleteSharedListComment(SharedListComment model)
        {
            var entity = _context.Comments.FirstOrDefault(c => c.Id == model.Id);
            if(entity != null)
            {
                _context.Comments.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<SharedListComment> ReadAllSharedListComments(long sharedListId)
        {
            return _context.Comments.Where(c => c.SharedListId == sharedListId).ToArray();
        }

        public ICollection<SharedListComment> ReadAllSharedListCommentsPaging(
            long sharedListId, int pageSize, int pageNumber, Sorting order)
        {
            Func<SharedListComment, DateTime> getKey = (slc) => {
                return slc.Timestamp;
            };
            int skipNumber = pageSize * (pageNumber - 1);
            if (order == Sorting.ASC)
                return _context.Comments.Where(c => c.SharedListId == sharedListId).OrderBy(getKey)
                    .Skip(skipNumber).Take(pageNumber).ToArray();
            else
                return _context.Comments.Where(c => c.SharedListId == sharedListId).OrderByDescending(getKey)
                    .Skip(skipNumber).Take(pageNumber).ToArray();
        }

        public SharedListComment ReadSharedListComment(long commentId)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == commentId);
        }

        public bool UpdateSharedListComment(SharedListComment model)
        {
            var updatingEntity = _context.Comments.FirstOrDefault(c => c.Id == model.Id);
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
