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
    public class CategorieEquipementAppService : AppServiceBase<CategorieEquipement, CategorieEquipement_DTO>, IAppCategorieEquipementService
    {

        private readonly ICategorieEquipementService _CategorieEquipementService;
        public CategorieEquipementAppService(ICategorieEquipementService CategorieEquipementService)
            : base(CategorieEquipementService)
        {
            _CategorieEquipementService = CategorieEquipementService;
        }

    }
}
