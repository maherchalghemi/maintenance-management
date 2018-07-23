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
    public class MagasinAppService : AppServiceBase<Magasin, Magasin_DTO>, IAppMagasinService
    {

        private readonly IMagasinService _MagasinService;
        public MagasinAppService(IMagasinService MagasinService)
            : base(MagasinService)
        {
            _MagasinService = MagasinService;
        }

    }
}
