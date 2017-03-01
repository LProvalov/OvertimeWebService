using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.DataProviders
{
    public interface IUserDataProvider
    {
        DataProviderResponse CreateNew(string username, string email, string unCryptedPassword);

        DataProviderResponse SingIn(string username, string email, string unCryptedPassword);

    }
}
