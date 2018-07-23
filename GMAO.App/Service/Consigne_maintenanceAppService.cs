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
    public class Consigne_maintenanceAppService : AppServiceBase<Consigne_maintenance, Consigne_maintenance_DTO>, IAppConsigne_maintenanceService
    {

        private readonly IConsigne_maintenanceService _Consigne_maintenanceService;
        public Consigne_maintenanceAppService(IConsigne_maintenanceService Consigne_maintenanceService)
            : base(Consigne_maintenanceService)
        {
            _Consigne_maintenanceService = Consigne_maintenanceService;
        }

    }
}
