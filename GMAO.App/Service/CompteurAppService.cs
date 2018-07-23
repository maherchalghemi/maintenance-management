﻿using GMAO.App.Entities;
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
    public class CompteurAppService : AppServiceBase<Compteur, Compteur_DTO>, IAppCompteurService
    {

        private readonly ICompteurService _CompteurService;
        public CompteurAppService(ICompteurService CompteurService)
            : base(CompteurService)
        {
            _CompteurService = CompteurService;
        }

    }
}
