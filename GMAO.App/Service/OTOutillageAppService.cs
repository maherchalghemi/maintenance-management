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
    public class OTOutillageAppService : AppServiceBase<OTOutillage, OTOutillage_DTO>, IAppOTOutillageService
    {

        private readonly IOTOutillageService _OTOutillageService;
        public OTOutillageAppService(IOTOutillageService OTOutillageService)
            : base(OTOutillageService)
        {
            _OTOutillageService = OTOutillageService;
        }

    }
}
