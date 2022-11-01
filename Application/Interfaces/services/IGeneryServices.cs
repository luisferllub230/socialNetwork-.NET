using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Interfaces.services
{
    public interface IGeneryServices<SaveViewModel, ViewModel, Model> 
        where SaveViewModel : class
        where ViewModel : class
        where Model : class
    {
        Task<SaveViewModel> Add(SaveViewModel cavm);
        Task Update(SaveViewModel cavm, int id);
        Task<SaveViewModel> GetById(int id);
        Task Delete(int id);
    }
}
