using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Service
{
    public class Consigne_maintenanceService : ServiceBase<Consigne_maintenance>, IConsigne_maintenanceService
    {
        public Consigne_maintenanceService(IConsigne_maintenanceRepository consigne_maintenanceRepository)
            : base(consigne_maintenanceRepository)
        {

        }

    }
}
