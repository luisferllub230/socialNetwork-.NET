using AutoMapper;
using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Application.Interfaces.services;
using socialNetwork.source.Core.Application.ViewModel.Users;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Services
{
    public class UsersServices : GeneryServices<SaveUsersViewModel, UsersViewModel, Users>, IUsersServices
    {

        private IUsersRepositories _user;
        private IMapper _mapper;

        public UsersServices(IUsersRepositories u, IMapper mapper) : base(u, mapper)
        {
            _user = u;
            _mapper = mapper;
        }

        public async Task<bool> confirmUsersNickName(SaveUsersViewModel suvm)
        {
            if (await _user.getByString(suvm.UserNickName))
            {
                return true;
            }

            return false;
        }

        public async Task<UsersViewModel> Logging(UsersLoggingViewModel suvm)
        {
            Users us = await _user.logging(suvm);

            if (us == null)
            {
                return null;
            }

            UsersViewModel user = _mapper.Map<UsersViewModel>(us);
            return user;
        }
    }
}
