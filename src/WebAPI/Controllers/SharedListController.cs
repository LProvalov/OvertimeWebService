using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using WebAPI;
using WebAPI.Repositories.Entities;

namespace WebAPI.Controllers
{
    [EnableCors("AllowCors")]
    [Route("api/[controller]")]
    public class SharedListController : Controller
    {
        public SharedListController(Repository repository)
        {
            MainRepository = repository;
        }

        public Repository MainRepository { get; set; }
        
        [HttpGet("ByOwner/{ownerId}", Name = "GetAllByOwner")]
        public IEnumerable<SharedList> GetAllByOwner(long ownerId)
        {
            return MainRepository.SharedLists.ReadAllSharedLists(ownerId);
        }

        [HttpGet("User/{userId}/Viewed", Name = "GetViewed")]
        public IEnumerable<SharedList> GetAllBySharedList(long userId)
        {
            return MainRepository.SharedLists.ReadAllSharedListsViewed(userId);
        }
    }
}
