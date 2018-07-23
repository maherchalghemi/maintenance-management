using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class User_DTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int GroupUser_Id { get; set; }
        public int Personnel_Id { get; set; }
    }
}
