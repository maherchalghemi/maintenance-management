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
    public class DocumentAppService : AppServiceBase<Document, Document_DTO>, IAppDocumentService
    {

        private readonly IDocumentService _DocumentService;
        public DocumentAppService(IDocumentService DocumentService)
            : base(DocumentService)
        {
            _DocumentService = DocumentService;
        }

    }
}
