using GMAO.Domain.Entities;
using GMAO.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
    }
}
