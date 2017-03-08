using System.Collections.Generic;
using WebAPI.Repositories.Entities;
namespace WebAPI.Repositories.Interfaces
{
    public interface IRepositorySharedList
    {
        SharedList CreateSharedList(SharedList model);
        SharedList ReadSharedList(long sharedListId);
        ICollection<SharedList> ReadAllSharedLists(long ownerId);
        ICollection<SharedList> ReadAllSharedListsViewed(long userId);
        ICollection<SharedList> ReadAllSharedListsBySharedListIds(string sharedListIds);
        bool UpdateSharedList(SharedList model);
        bool DeleteSharedList(SharedList model);
    }
}
