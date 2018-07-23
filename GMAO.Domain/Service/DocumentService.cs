using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using GMAO.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Service
{
    public class DocumentService : ServiceBase<Document>, IDocumentService
    {
        public DocumentService(IDocumentRepository DocumentRepository)
            : base(DocumentRepository)
        {

        }

    }
}
