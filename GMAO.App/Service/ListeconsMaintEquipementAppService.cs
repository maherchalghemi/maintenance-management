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
    public class ListeconsMaintEquipementAppService : AppServiceBase<ListeconsMaintEquipement, ListeconsMaintEquipement_DTO>, IAppListeconsMaintEquipementService
    {

        private readonly IListeconsMaintEquipementService _ListeconsMaintEquipementService;
        public ListeconsMaintEquipementAppService(IListeconsMaintEquipementService ListeconsMaintEquipementService)
            : base(ListeconsMaintEquipementService)
        {
            _ListeconsMaintEquipementService = ListeconsMaintEquipementService;
        }

    }
}
