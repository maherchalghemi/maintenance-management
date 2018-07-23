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
    public class GroupUserAppService : AppServiceBase<GroupUser, GroupUser_DTO>, IAppGroupUserService
    {

        private readonly IGroupUserService _GroupUserService;
        public GroupUserAppService(IGroupUserService GroupUserService)
            : base(GroupUserService)
        {
            _GroupUserService = GroupUserService;
        }

    }
}
