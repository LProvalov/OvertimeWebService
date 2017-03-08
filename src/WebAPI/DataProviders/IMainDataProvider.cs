using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebAPI.Repositories.Entities;

namespace WebAPI.DataProviders
{
    public interface IMainDataProvider
    {
        // Work with user        
        DataProviderResponse<string> CreateNew(string username, string email, string unCryptedPassword);

        DataProviderResponse<string> SingIn(string username, string email, string unCryptedPassword);

        // Work with friends list
        DataProviderResponse<ICollection<UserOfService>> GetFriendsList(long userId);

        DataProviderResponse<bool> RemoveFriendsFromFriendList(long userId, ICollection<long> removingUsersIds);

        DataProviderResponse<bool> SendRequestOfFriendsAdding(long userId, ICollection<long> addingUsersIds);

        DataProviderResponse<bool> ReplyOnRequestOfFriendAdding(long userId, long requestId, bool isAccepted);

        DataProviderResponse<ICollection<UserOfService>> FindUsersByPartOfUsername(string partOfUserName, int pageSize, int pageNumber);

        // Work with shared lists

    }
}
