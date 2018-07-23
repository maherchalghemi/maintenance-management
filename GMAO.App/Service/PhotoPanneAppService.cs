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
    public class PhotoPanneAppService : AppServiceBase<PhotoPanne, PhotoPanne_DTO>, IAppPhotoPanneService
    {

        private readonly IPhotoPanneService _PhotoPanneService;
        public PhotoPanneAppService(IPhotoPanneService PhotoPanneService)
            : base(PhotoPanneService)
        {
            _PhotoPanneService = PhotoPanneService;
        }

    }
}
