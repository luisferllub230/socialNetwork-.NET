
using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Domain.Entities;
using socialNetwork.source.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Persistence.Repositories
{
    public class UsersRepositories : GenericRepository<Users>, IUsersRepositories 
    {
        private readonly ApplicationContext _appContex;

        public UsersRepositories(ApplicationContext Dbcontext) : base(Dbcontext)
        {
            _appContex = Dbcontext;
        }


    }
}
