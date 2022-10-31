
using Microsoft.EntityFrameworkCore;
using socialNetwork.source.Core.Application.helpers;
using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Application.ViewModel.Users;
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

        public override async Task<Users> add(Users entity)
        {
            entity.UserPassword = PasswordEncrypted.ComputeSHA256Hash(entity.UserPassword);
            return await base.add(entity);
        }

        public async Task<Users> logging(UsersLoggingViewModel entity)
        {
            //string psw = PasswordEncrypted.ComputeSHA256Hash(entity.UsersPasswork);
            Users u = await _appContex.Set<Users>().FirstOrDefaultAsync(u => u.UserNickName == entity.UserName && u.UserPassword == entity.UsersPasswork);
            return u;
        }

        public async Task<bool> getByString(string name)
        {

            Users u = await _appContex.Set<Users>().FirstOrDefaultAsync(u => u.UserNickName == name);

            if (u != null && u.UserNickName == name)
            {
                return false;
            }

            return true;
        }
    }
}
