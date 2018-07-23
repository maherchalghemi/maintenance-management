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
    public class EmplacementAppService : AppServiceBase<Emplacement, Emplacement_DTO>, IAppEmplacementService
    {

        private readonly IEmplacementService _EmplacementService;
        public EmplacementAppService(IEmplacementService EmplacementService)
            : base(EmplacementService)
        {
            _EmplacementService = EmplacementService;
        }

    }
}
