using GMAO.App.Entities;
using GMAO.App.Interface;
using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Service
{
    public class UserAppService : AppServiceBase<User, User_DTO>, IAppUserService
    {

        private readonly IUserService _UserService;
        public UserAppService(IUserService UserService)
            : base(UserService)
        {
            _UserService = UserService;
        }

    }
}
