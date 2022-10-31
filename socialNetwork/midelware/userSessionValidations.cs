using Microsoft.AspNetCore.Http;
using socialNetwork.source.Core.Application.helpers;
using socialNetwork.source.Core.Application.ViewModel.Users;

namespace socialNetwork.midelware
{
    public class userSessionValidations
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public userSessionValidations(IHttpContextAccessor ca)
        {
            _contextAccessor = ca;
        }

        public bool hasUser()
        {
            UsersViewModel user = _contextAccessor.HttpContext.Session.get<UsersViewModel>("user");
            if (user == null)
            {
                return false;
            }

            return true;
        }
    }
}
