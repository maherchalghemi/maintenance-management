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
    public class DepartementAppService : AppServiceBase<Departement, Departement_DTO>, IAppDepartementService
    {

        private readonly IDepartementService _DepartementService;
        public DepartementAppService(IDepartementService DepartementService)
            : base(DepartementService)
        {
            _DepartementService = DepartementService;
        }

    }
}
