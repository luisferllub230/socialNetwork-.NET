using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces
{
    public interface IGeneryRepositories<Entity> where Entity : class
    {
        Task<Entity> add(Entity entity);
        Task delete(Entity entity);
        Task<List<Entity>> getAll();
        Task<Entity> getOne(int id);
        Task update(Entity entity);
        Task<List<Entity>> getAllByInclude(List<string> properties);
    }
}
