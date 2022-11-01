using socialNetwork.source.Core.Application.ViewModel.Users;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Interfaces.services
{
    public
        interface IUsersServices : IGeneryServices<SaveUsersViewModel, UsersViewModel, Users>
    {
        Task<bool> confirmUsersNickName(SaveUsersViewModel suvm);
        Task<UsersViewModel> Logging(UsersLoggingViewModel suvm);
    }
}
