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
    public class RightAppService : AppServiceBase<Right, Right_DTO>, IAppRightService
    {

        private readonly IRightService _RightService;
        public RightAppService(IRightService RightService)
            : base(RightService)
        {
            _RightService = RightService;
        }

    }
}
