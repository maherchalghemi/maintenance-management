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
    public class Dec_PanneAppService : AppServiceBase<Dec_Panne, Dec_Panne_DTO>, IAppDec_PanneService
    {

        private readonly IDec_PanneService _Dec_PanneService;
        public Dec_PanneAppService(IDec_PanneService Dec_PanneService)
            : base(Dec_PanneService)
        {
            _Dec_PanneService = Dec_PanneService;
        }

    }
}
