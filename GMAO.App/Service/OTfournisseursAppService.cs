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
    public class OTfournisseursAppService : AppServiceBase<OTfournisseurs, OTfournisseurs_DTO>, IAppOTfournisseursService
    {

        private readonly IOTfournisseursService _OTfournisseursService;
        public OTfournisseursAppService(IOTfournisseursService OTfournisseursService)
            : base(OTfournisseursService)
        {
            _OTfournisseursService = OTfournisseursService;
        }

    }
}
