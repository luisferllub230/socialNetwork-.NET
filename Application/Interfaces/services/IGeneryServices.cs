using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Interfaces.services
{
    public interface IGeneryServices<Entity, ViewModel> 
        where Entity : class
        where ViewModel : class
    {
        Task<ViewModel> Add(ViewModel cavm);
        Task Update(ViewModel cavm);
        Task<List<Entity>> GetAll();
        Task<ViewModel> GetById(int id);
        Task Delete(ViewModel cavm);
    }
}
