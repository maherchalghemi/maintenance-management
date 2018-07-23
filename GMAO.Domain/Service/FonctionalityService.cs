﻿using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Service
{
    public class FonctionalityService : ServiceBase<Fonctionality>, IFonctionalityService
    {
        public FonctionalityService(IFonctionalityRepository fonctionalityRepository)
            : base(fonctionalityRepository)
        {

        }

    }
}
