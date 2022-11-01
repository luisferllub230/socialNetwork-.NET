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
    public class GeneryServices<SaveViewModel, ViewModel, Model> : IGeneryServices<SaveViewModel, ViewModel, Model>
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {

        private IGeneryRepositories<Model> _repository;
        private IMapper _mapper;

        public GeneryServices(IGeneryRepositories<Model> u, IMapper mapper)
        {
            _repository = u;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel suvm)
        {
            Model entity = _mapper.Map<Model>(suvm);
            entity = await _repository.add(entity);

            SaveViewModel entityVM = _mapper.Map<SaveViewModel>(entity);
            return entityVM;
        }

        public virtual async Task Update(SaveViewModel suvm, int id)
        {
            Model entity = _mapper.Map<Model>(suvm);
            await _repository.update(entity, id);
        }

        //public async Task<List<UsersViewModel>> GetAll()
        //{
        //    var userList = await _user.getAllByInclude(new List<string> { "post" });

        //    return userList.Select(c => new UsersViewModel
        //    {
        //        id = c.id,

        //        UserNickName = c.UserNickName,
        //        LastName = c.LastName,
        //        UserPhone = c.UserPhone,
        //        UserEmail = c.UserEmail,
        //        UserPassword = c.UserPassword,
        //        Name = c.Name,

        //}).ToList();
        //}

        public async Task<SaveViewModel> GetById(int id)
        {
            var user = await _repository.getOne(id);

            SaveViewModel entityVM = _mapper.Map<SaveViewModel>(user);

            return entityVM;
        }

        public async Task Delete(int id)
        {
            var user = await _repository.getOne(id);
            await _repository.delete(user);
        }
    }
}
