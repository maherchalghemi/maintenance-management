using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMAO.App.Entities;
using GMAO.App.Interface;
using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Service;

namespace GMAO.App.Service
{
    public class DeviseAppService : AppServiceBase<Devise, Devise_DTO>, IAppDeviseService
    {

        private readonly IDeviseService _DeviseService;
        public DeviseAppService(IDeviseService DeviseService)
            : base(DeviseService)
        {
            _DeviseService = DeviseService;
        }

    }
}
