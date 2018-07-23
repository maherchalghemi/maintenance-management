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
    public class PersonnelAppService : AppServiceBase<Personnel, Personnel_DTO>, IAppPersonnelService
    {

        private readonly IPersonnelService _PersonnelService;
        public PersonnelAppService(IPersonnelService PersonnelService)
            : base(PersonnelService)
        {
            _PersonnelService = PersonnelService;
        }

    }
}
