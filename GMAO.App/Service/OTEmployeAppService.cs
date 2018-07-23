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
    public class OTEmployeAppService : AppServiceBase<OTEmploye, OTEmploye_DTO>, IAppOTEmployeService
    {

        private readonly IOTEmployeService _OTEmployeService;
        public OTEmployeAppService(IOTEmployeService OTEmployeService)
            : base(OTEmployeService)
        {
            _OTEmployeService = OTEmployeService;
        }

    }
}
