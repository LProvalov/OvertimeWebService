using System.Collections.Generic;
using WebAPI.Enums;
using WebAPI.Repositories.Entities;
namespace WebAPI.Repositories.Interfaces
{
    public interface IRepositoryUserOfService
    {
        UserOfService CreateUser(UserOfService model);
        ICollection<UserOfService> ReadAllUsers();
        ICollection<UserOfService> ReadUsersPaging(int pageSize, int pageNumber, Sorting sortOrder);
        UserOfService ReadUser(long userId);
        bool UpdateUser(UserOfService model);
        bool DeleteUser(UserOfService model);
    }
}
