using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class GroupUser
    {
        public GroupUser()
        {
            this.rights = new List<Right>();
            this.users = new List<User>();
        }

        public int Id { get; set; }
        public string Intitule { get; set; }
        public string Description { get; set; }
        public int Company_Id { get; set; }
        public virtual Company company { get; set; }
        public virtual ICollection<Right> rights { get; set; }
        public virtual ICollection<User> users { get; set; }
    }
}
