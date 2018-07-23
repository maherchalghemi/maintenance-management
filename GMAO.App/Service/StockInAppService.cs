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
    public class StockInAppService : AppServiceBase<StockIn, StockIn_DTO>, IAppStockInService
    {

        private readonly IStockInService _StockInService;
        public StockInAppService(IStockInService StockInService)
            : base(StockInService)
        {
            _StockInService = StockInService;
        }

    }
}
