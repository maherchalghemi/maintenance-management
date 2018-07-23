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
    public class FournisseurAppService : AppServiceBase<Fournisseur, Fournisseur_DTO>, IAppFournisseurService
    {

        private readonly IFournisseurService _FournisseurService;
        public FournisseurAppService(IFournisseurService FournisseurService)
            : base(FournisseurService)
        {
            _FournisseurService = FournisseurService;
        }

    }
}
