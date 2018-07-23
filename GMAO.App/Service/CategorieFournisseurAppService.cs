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
    public class CategorieFournisseurAppService : AppServiceBase<CategorieFournisseur, CategorieFournisseur_DTO>, IAppCategorieFournisseurService
    {

        private readonly ICategorieFournisseurService _CategorieFournisseurService;
        public CategorieFournisseurAppService(ICategorieFournisseurService CategorieFournisseurService)
            : base(CategorieFournisseurService)
        {
            _CategorieFournisseurService = CategorieFournisseurService;
        }

    }
}
