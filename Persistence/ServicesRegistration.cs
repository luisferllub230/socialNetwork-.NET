using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using socialNetwork.source.Core.Application.Interfaces.repositoriesInterfaces;
using socialNetwork.source.Core.Persistence.Context;
using socialNetwork.source.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            #region context
            //for run database in memory 
            if (configuration.GetValue<bool>("UseInMemoryDataBase"))
            {
                services.AddDbContext<ApplicationContext>(o => o.UseInMemoryDatabase("applicationDB"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(configuration.GetConnectionString("DefaultConection")
                    , m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }

            #endregion

            //#region repositories
            services.AddTransient(typeof(IGeneryRepositories<>), typeof(GenericRepository<>));
            services.AddTransient<IUsersRepositories, UsersRepositories>();
            //services.AddTransient<ICategoriesRepositories, CategoriesRepositories>();
            //services.AddTransient<IComercialRepositories, ComercialRepositories>();
            //#endregion
        }
    }
}
