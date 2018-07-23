using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class Ordre_de_travail_DTO
    {
        public int Id { get; set; }

        public int RefDecPanne { get; set; }
        public string TypePanne { get; set; }
        public string Code_OT { get; set; }

        public string DescriptionPanne { get; set; }

        public Nullable<double> Coût_tot_reel { get; set; }
        public Nullable<double> Coût_pieces_de_rechanges_planifie { get; set; }
        public Nullable<double> cout_Intervenant_planifie { get; set; }
        public string Causepanne { get; set; }
        public string Priorite { get; set; }

        public Nullable<double> Cout_tot_Planifie { get; set; }
        public string Duree_total_Reel { get; set; }
        public string Nom_inter { get; set; }
        public string dure_int_planifie { get; set; } // heure   
        public Nullable<double> cout_int_reel { get; set; }
        public string duree_int_reel { get; set; } // heure  
        public string statut { get; set; } //xxxxxxxxxxxxx
        public string Declarant { get; set; }

        public string Moye_declaration { get; set; }
        public Nullable<System.DateTime> Date_declaration { get; set; }
        public string Heure_declaration { get; set; } // heure  
        public string Action_immediate { get; set; }
        public string degre_urgence { get; set; }

        public string Duree_total_planifie { get; set; } // heure   
        public string Nom_int_reel { get; set; }
        public Nullable<System.DateTime> date_lancement_OT { get; set; }
        public Nullable<System.DateTime> Date_Debut_planifie { get; set; }
        public Nullable<System.DateTime> date_debut_prevu_ext { get; set; }
        public Nullable<System.DateTime> date_debut_reelle_ext { get; set; }
        public Nullable<double> Coût_pieces_de_rechanges_reel { get; set; }
        public Nullable<System.DateTime> Date_mise_en_marche { get; set; }
        public string Heure_mise_en_marche { get; set; } // heure     
        public Nullable<System.DateTime> date_debut_OT { get; set; }
        public Nullable<System.DateTime> Date_fin_Ot { get; set; }
        public string Cause_annulation { get; set; }
        public Nullable<System.DateTime> Date_annulation { get; set; }
        public Nullable<System.DateTime> date_clôture { get; set; }
        public string Rapport_Intervention { get; set; }
        public string Duree_ext_reel_jr { get; set; } // heure
        public string Duree_ext_planifie_jr { get; set; } // heure
        public string duree_tot_planif_jr { get; set; } // heure
        public string duree_tot_reel_jr { get; set; } // heure
        public string Type_ECO { get; set; } // type SMALLINT

        public string commentaire_EXT { get; set; }
        public string Heure_Debut_OT { get; set; } // heure   
        public string heuer_fin_ot { get; set; } // heure   
        public Nullable<System.DateTime> Date_Fin_Estimee { get; set; }

        public string MesureCompteurPN { get; set; } // type BIGINT 8 bytes
        public string MesureCompteurREM { get; set; } // type BIGINT 8 bytes
        public string DiagnosticPanne { get; set; }
        public bool Ressource_Arrêtee { get; set; } // type TINYINT 1 byte
        public Nullable<System.DateTime> Date_arret { get; set; }
        public string Heure_arrêt { get; set; } // heure

        public int OT_Personnel_Id { get; set; } //id OT_Personnel a changer le type en int

        
        public Nullable<int> Compteur_Id { get; set; } // id copteur 
        

        public int Equipement_Id { get; set; } //id_Equipement
        
        public int Personnel_Id { get; set; } // id_Personnel
        

        public Nullable<int> cArr_Equip_Id { get; set; }
        
    }
}
