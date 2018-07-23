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
    public class StockOutAppService : AppServiceBase<StockOut, StockOut_DTO>, IAppStockOutService
    {

        private readonly IStockOutService _StockOutService;
        public StockOutAppService(IStockOutService StockOutService)
            : base(StockOutService)
        {
            _StockOutService = StockOutService;
        }

    }
}
