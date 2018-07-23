using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;

namespace GMAO.Domain.Service
{
    public class StockInService : ServiceBase<StockIn>, IStockInService
    {
        public StockInService(IStockInRepository StockInRepository)
            : base(StockInRepository)
        {

        }

    }
}
