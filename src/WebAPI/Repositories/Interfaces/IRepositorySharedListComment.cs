using System.Collections.Generic;
using WebAPI.Enums;
using WebAPI.Repositories.Entities;
namespace WebAPI.Repositories.Interfaces
{
    public interface IRepositorySharedListComment
    {
        SharedListComment CreateSharedListComment(SharedListComment model);
        SharedListComment ReadSharedListComment(long commentId);
        ICollection<SharedListComment> ReadAllSharedListComments(long sharedListId);
        ICollection<SharedListComment> ReadAllSharedListCommentsPaging(long sharedListId, int pageSize, int pageNumber, Sorting order);
        bool UpdateSharedListComment(SharedListComment model);
        bool DeleteSharedListComment(SharedListComment model);
    }
}
