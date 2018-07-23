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
    public class FonctionalityAppService : AppServiceBase<Fonctionality, Fonctionality_DTO>, IAppFonctionalityService
    {

        private readonly IFonctionalityService _FonctionalityService;
        public FonctionalityAppService(IFonctionalityService FonctionalityService)
            : base(FonctionalityService)
        {
            _FonctionalityService = FonctionalityService;
        }

    }
}
