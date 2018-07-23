using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Domain.Entities
{
    public partial class Client
    {
        public int Id { get; set; }
        public bool CompteActif { get; set; }
        public bool loex { get; set; }
        public string Banque { get; set; }
        public int nb_bl { get; set; } // change par nature
        public string NCompte { get; set; }
        public string civilite { get; set; } // change par secteur
        public System.DateTime DateCreation { get; set; }
        public System.DateTime DateModification { get; set; }
        public string MatriculeFiscal { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string CodeInterne { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string NomContact { get; set; }
        public string Email { get; set; }
        public string EmailF { get; set; }
        public string Tel { get; set; }
        public string TelF { get; set; }
        public string Domiciliation { get; set; } // GSM
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public int? nbFacture { get; set; } // chnage par iDsite
        public int? delaiLiv { get; set; } // idsociete
        public float? escompte { get; set; } 
        public string Fax { get; set; }
        public string FaxF { get; set; }
        public string IBAN { get; set; } //SITEWEB

        public string observation { get; set; } // design..

        public string UR { get; set; }
        public string RefFour { get; set; }
        public string siret { get; set; }
        public string codeDouane { get; set; }
        public string codeTVA { get; set; }
        public string SWIFT { get; set; }
        public string VILLE { get; set; }
        public string VILLEF { get; set; }
        public string CCP { get; set; }
        public string CCPF { get; set; }
        
    }
}
