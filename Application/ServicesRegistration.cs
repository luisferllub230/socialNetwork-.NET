using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using socialNetwork.source.Core.Application.Interfaces.services;
using socialNetwork.source.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServicesRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region repositories
            services.AddTransient<IUsersServices, UsersServices>();
            #endregion
        }
    }
}
