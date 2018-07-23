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
    public class CategoriePieceRechangeAppService : AppServiceBase<CategoriePieceRechange, CategoriePieceRechange_DTO>, IAppCategoriePieceRechangeService
    {

        private readonly ICategoriePieceRechangeService _CategoriePieceRechangeService;
        public CategoriePieceRechangeAppService(ICategoriePieceRechangeService CategoriePieceRechangeService)
            : base(CategoriePieceRechangeService)
        {
            _CategoriePieceRechangeService = CategoriePieceRechangeService;
        }

    }
}
