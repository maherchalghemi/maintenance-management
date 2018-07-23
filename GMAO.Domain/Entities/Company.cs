using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Company
    {
        public Company()
        {
            this.articles = new List<Article>();
            this.clients = new List<Client>();
            //this.fournisseurs = new List<fournisseur>();
            this.groupUsers = new List<GroupUser>();
           
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Article> articles { get; set; }
        public virtual ICollection<Client> clients { get; set; }
        //public virtual ICollection<fournisseur> fournisseurs { get; set; }
        public virtual ICollection<GroupUser> groupUsers { get; set; }
        
    }
}
