using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Repositories;
using WebAPI.Enums;

namespace WebAPI
{
    public class Repository
    {
        private readonly Context _context;
        private RepositorySharedList _sharedLists;
        private RepositorySharedListComment _comments;
        private RepositorySharedListData _datas;
        private RepositoryUserOfService _users;

        public RepositorySharedList SharedLists { get { return this._sharedLists; } }
        public RepositorySharedListComment Comments { get { return this._comments; } }
        public RepositorySharedListData Datas { get { return this._datas; } }
        public RepositoryUserOfService Users { get { return this._users; } }

        public Repository(Context context)
        {
            _context = context;
            _sharedLists = new RepositorySharedList(_context);
            _comments = new RepositorySharedListComment(_context);
            _datas = new RepositorySharedListData(_context);
            _users = new RepositoryUserOfService(_context);
        }

        
    }
}
