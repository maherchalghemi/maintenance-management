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
    public class OTPieceRechangeAppService : AppServiceBase<OTPieceRechange, OTPieceRechange_DTO>, IAppOTPieceRechangeService
    {

        private readonly IOTPieceRechangeService _OTPieceRechangeService;
        public OTPieceRechangeAppService(IOTPieceRechangeService OTPieceRechangeService)
            : base(OTPieceRechangeService)
        {
            _OTPieceRechangeService = OTPieceRechangeService;
        }

    }
}
