using System.Collections.Generic;
using WebAPI.Repositories.Entities;
namespace WebAPI.Repositories.Interfaces
{
    public interface IRepositorySharedListData
    {
        SharedListData CreateSharedListData(SharedListData model);
        SharedListData ReadSharedListData(long sharedListDataIs);
        ICollection<SharedListData> ReadAll(long sharedListId, bool includeActiveOnly = true);
        bool UpdateSharedListData(SharedListData model);
        bool DeleteSharedListData(SharedListData model);
    }
}
