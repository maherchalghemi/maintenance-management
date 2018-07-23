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
    public class CategorieOutillageAppService : AppServiceBase<CategorieOutillage, CategorieOutillage_DTO>, IAppCategorieOutillageService
    {

        private readonly ICategorieOutillageService _CategorieOutillageService;
        public CategorieOutillageAppService(ICategorieOutillageService CategorieOutillageService)
            : base(CategorieOutillageService)
        {
            _CategorieOutillageService = CategorieOutillageService;
        }

    }

}
