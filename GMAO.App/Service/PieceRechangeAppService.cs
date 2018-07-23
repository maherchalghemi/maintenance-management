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
    public class PieceRechangeAppService : AppServiceBase<PieceRechange, PieceRechange_DTO>, IAppPieceRechangeService
    {

        private readonly IPieceRechangeService _PieceRechangeService;
        public PieceRechangeAppService(IPieceRechangeService PieceRechangeService)
            : base(PieceRechangeService)
        {
            _PieceRechangeService = PieceRechangeService;
        }

    }
}
