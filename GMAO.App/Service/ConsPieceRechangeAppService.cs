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
    public class ConsPieceRechangeAppService : AppServiceBase<ConsPieceRechange, ConsPieceRechange_DTO>, IAppConsPieceRechangeService
    {

        private readonly IConsPieceRechangeService _ConsPieceRechangeService;
        public ConsPieceRechangeAppService(IConsPieceRechangeService ConsPieceRechangeService)
            : base(ConsPieceRechangeService)
        {
            _ConsPieceRechangeService = ConsPieceRechangeService;
        }

    }
}
