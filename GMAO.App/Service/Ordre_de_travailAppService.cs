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
    public class Ordre_de_travailAppService : AppServiceBase<Ordre_de_travail, Ordre_de_travail_DTO>, IAppOrdre_de_travailService
    {

        private readonly IOrdre_de_travailService _Ordre_de_travailService;
        public Ordre_de_travailAppService(IOrdre_de_travailService Ordre_de_travailService)
            : base(Ordre_de_travailService)
        {
            _Ordre_de_travailService = Ordre_de_travailService;
        }

    }
}
