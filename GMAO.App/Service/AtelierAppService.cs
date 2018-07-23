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
    public class AtelierAppService : AppServiceBase<Atelier, Atelier_DTO>, IAppAtelierService
    {

        private readonly IAtelierService _AtelierService;
        public AtelierAppService(IAtelierService AtelierService)
            : base(AtelierService)
        {
            _AtelierService = AtelierService;
        }

    }

}
