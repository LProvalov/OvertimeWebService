using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Repositories;
using WebAPI.Repositories.Interfaces;
using WebAPI.Enums;

namespace WebAPI
{
    public class Repository
    {
        public Repository(Context context, 
            IRepositorySharedList sharedList,
            IRepositorySharedListComment comments,
            IRepositorySharedListData datas,
            IRepositoryUserOfService users)
        {
            _context = context;
            _sharedLists = sharedList;
            _comments = comments;
            _datas = datas;
            _users = users;
        }
        
        private readonly Context _context;
        private IRepositorySharedList _sharedLists;
        private IRepositorySharedListComment _comments;
        private IRepositorySharedListData _datas;
        private IRepositoryUserOfService _users;

        public IRepositorySharedList SharedLists { get { return this._sharedLists; } }
        public IRepositorySharedListComment Comments { get { return this._comments; } }
        public IRepositorySharedListData Datas { get { return this._datas; } }
        public IRepositoryUserOfService Users { get { return this._users; } }        
    }
}
