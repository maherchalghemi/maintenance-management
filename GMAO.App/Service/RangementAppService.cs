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
    public class RangementAppService : AppServiceBase<Rangement, Rangement_DTO>, IAppRangementService
    {

        private readonly IRangementService _RangementService;
        public RangementAppService(IRangementService RangementService)
            : base(RangementService)
        {
            _RangementService = RangementService;
        }

    }

}
