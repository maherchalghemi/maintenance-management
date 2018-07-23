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
    public class OutillageAppService : AppServiceBase<Outillage, Outillage_DTO>, IAppOutillageService
    {

        private readonly IOutillageService _OutillageService;
        public OutillageAppService(IOutillageService OutillageService)
            : base(OutillageService)
        {
            _OutillageService = OutillageService;
        }

    }
}
