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
    public class ClientAppService : AppServiceBase<Client, Client_DTO>, IAppClientService
    {

        private readonly IClientService _ClientService;
        public ClientAppService(IClientService ClientService)
            : base(ClientService)
        {
            _ClientService = ClientService;
        }

    }
}
