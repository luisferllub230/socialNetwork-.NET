using socialNetwork.source.Core.Application.ViewModel.Users;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces
{
    public interface IUsersRepositories : IGeneryRepositories<Users>
    {
        Task<bool> getByString(string name);
        Task<Users> logging(UsersLoggingViewModel entity);
    }
}
