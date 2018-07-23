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
    public class CategorieClientAppService : AppServiceBase<CategorieClient, CategorieClient_DTO>, IAppCategorieClientService
    {

        private readonly ICategorieClientService _CategorieClientService;
        public CategorieClientAppService(ICategorieClientService CategorieClientService)
            : base(CategorieClientService)
        {
            _CategorieClientService = CategorieClientService;
        }

    }
}
