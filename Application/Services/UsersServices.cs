using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Services
{
    public class UsersServices : IUsersRepositories
    {

        private IUsersRepositories _user;

        public UsersServices(IUsersRepositories u)
        {
            _user = u;
        }


        public Task<Users> add(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task delete(Users entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Users>> getAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Users>> getAllByInclude(List<string> properties)
        {
            throw new NotImplementedException();
        }

        public Task<Users> getOne(int id)
        {
            throw new NotImplementedException();
        }

        public Task update(Users entity)
        {
            throw new NotImplementedException();
        }
    }
}
