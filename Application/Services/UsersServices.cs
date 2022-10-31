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
    public class UsersServices : IUsersServices
    {

        private IUsersRepositories _user;

        public UsersServices(IUsersRepositories u)
        {
            _user = u;
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

            UsersViewModel user = new();
            user.id = us.id;
            user.UserNickName = us.UserNickName;
            user.Name = us.Name;
            user.LastName = us.LastName;
            user.UserPhone = us.UserPhone;
            user.UserEmail = us.UserEmail;
            user.UserPassword = us.UserPassword;
            user.Name = us.Name;

            return user;
        }

        public async Task<SaveUsersViewModel> Add(SaveUsersViewModel suvm)
        {
            Users user = new();
            user.UserNickName = suvm.UserNickName;
            user.Name = suvm.Name;
            user.LastName = suvm.LastName;
            user.UserPhone = suvm.UserPhone;
            user.UserEmail = suvm.UserEmail;
            user.UserPassword = suvm.UserPassword;
            user.Name = suvm.Name;
            user.UserPhoto = "sdasdas";

            user = await _user.add(user);

            SaveUsersViewModel sc = new SaveUsersViewModel();
            sc.UserNickName = user.UserNickName;
            sc.Name = user.Name;
            sc.LastName = user.LastName;
            sc.UserPhone = user.UserPhone;
            sc.UserEmail = user.UserEmail;
            sc.UserPassword = user.UserPassword;
            sc.Name = user.Name;  

            return sc;
        }

        public async Task Update(SaveUsersViewModel suvm)
        {
            Users user = await _user.getOne(suvm.id);
            user.id = suvm.id;
            user.UserNickName = suvm.UserNickName;
            user.LastName = suvm.LastName;
            user.UserPhone = suvm.UserPhone;
            user.UserEmail = suvm.UserEmail;
            user.UserPassword = suvm.UserPassword;
            user.Name = suvm.Name;
            await _user.update(user);
        }

        public async Task<List<UsersViewModel>> GetAll()
        {
            var userList = await _user.getAllByInclude(new List<string> { "post" });

            return userList.Select(c => new UsersViewModel
            {
                id = c.id,

                UserNickName = c.UserNickName,
                LastName = c.LastName,
                UserPhone = c.UserPhone,
                UserEmail = c.UserEmail,
                UserPassword = c.UserPassword,
                Name = c.Name,

        }).ToList();
        }

        public async Task<SaveUsersViewModel> GetById(int id)
        {
            var user = await _user.getOne(id);

            SaveUsersViewModel suvm = new();
            suvm.id = user.id;
            suvm.UserNickName = user.UserNickName;
            suvm.LastName = user.LastName;
            suvm.UserPhone = user.UserPhone;
            suvm.UserPassword = user.UserPassword;
            suvm.UserEmail = user.UserEmail;
            suvm.Name = user.Name;


            return suvm;
        }

        public async Task Delete(SaveUsersViewModel suvm)
        {
            var user = await _user.getOne(suvm.id);
            await _user.delete(user);
        }
    }
}
