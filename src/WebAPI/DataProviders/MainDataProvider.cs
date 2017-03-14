using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using WebAPI.Repositories;
using WebAPI.Repositories.Entities;

namespace WebAPI.DataProviders
{
    public class MainDataProvider : IMainDataProvider
    {
        private Context _context;

        public MainDataProvider(Context context)
        {
            this._context = context;
        }

        public DataProviderResponse<string> CreateNew(string username, string email, string unCryptedPassword)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<ICollection<UserOfService>> FindUsersByPartOfUsername(string partOfUserName, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<ICollection<UserOfService>> GetFriendsList(long userId)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<bool> RemoveFriendsFromFriendList(long userId, ICollection<long> removingUsersIds)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<bool> ReplyOnRequestOfFriendAdding(long userId, long requestId, bool isAccepted)
        {
            throw new NotImplementedException();
        }

        public Task<ClaimsIdentity> ResolveIdentity(string username, string email, string unCryptedPassword)
        {
            if (this.ValidateUser(username, email, unCryptedPassword).Data)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { }));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }

        public DataProviderResponse<bool> SendRequestOfFriendsAdding(long userId, ICollection<long> addingUsersIds)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<string> SingIn(string username, string email, string unCryptedPassword)
        {
            throw new NotImplementedException();
        }

        public DataProviderResponse<bool> ValidateUser(string username, string email, string unCryptedPassword)
        {
            return new DataProviderResponse<bool>(new string[] { }, true, ResponseStatus.OK, string.Empty);
        }
    }
}
