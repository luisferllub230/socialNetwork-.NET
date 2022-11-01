using AutoMapper;
using socialNetwork.source.Core.Application.ViewModel.Users;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.mappings
{
    public class GeneralMappings : Profile
    {
        public GeneralMappings() 
        {
            CreateMap<Users, UsersViewModel>()
                .ReverseMap()
                .ForMember(x => x.isActive, x => x.Ignore())
                .ForMember(x => x.post, x => x.Ignore())
                .ForMember(x => x.Coments, x => x.Ignore());

            CreateMap<Users, SaveUsersViewModel>()
                .ForMember(x => x.ConfirmUsersPasswork, x => x.Ignore())
                .ReverseMap()
                .ForMember(x => x.isActive, x => x.Ignore())
                .ForMember(x => x.post, x => x.Ignore())
                .ForMember(x => x.Coments, x => x.Ignore());


        }
    }
}
