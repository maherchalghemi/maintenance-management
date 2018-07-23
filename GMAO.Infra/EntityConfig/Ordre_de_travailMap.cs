using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class Ordre_de_travailMap : EntityTypeConfiguration<Ordre_de_travail>
    {
        public Ordre_de_travailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RefDecPanne)
                .IsRequired();
            this.Property(t => t.TypePanne)
           .IsRequired();

            this.Property(t => t.Code_OT)
            .IsRequired();
            this.Property(t => t.DescriptionPanne)
           .IsRequired();
            this.Property(t => t.Coût_tot_reel)
            .IsRequired();
            this.Property(t => t.Coût_pieces_de_rechanges_planifie)
           .IsRequired();
            this.Property(t => t.cout_Intervenant_planifie)
            .IsRequired();
            this.Property(t => t.Causepanne)
           .IsRequired();
            this.Property(t => t.Priorite)
            .IsRequired();
            this.Property(t => t.Cout_tot_Planifie)
           .IsRequired();
            this.Property(t => t.Duree_total_Reel)
            .IsRequired();
            this.Property(t => t.Nom_inter)
           .IsRequired();
            this.Property(t => t.dure_int_planifie)
            .IsRequired();
            this.Property(t => t.cout_int_reel)
           .IsRequired();
            this.Property(t => t.duree_int_reel)
            .IsRequired();
            this.Property(t => t.statut)
           .IsRequired();
            this.Property(t => t.Declarant)
            .IsRequired();
            this.Property(t => t.Moye_declaration)
           .IsRequired();
            this.Property(t => t.Date_declaration)
            .IsRequired();
            this.Property(t => t.Heure_declaration)
           .IsRequired();
            this.Property(t => t.Action_immediate)
            .IsRequired();
            this.Property(t => t.degre_urgence)
           .IsRequired();
            this.Property(t => t.Duree_total_planifie)
            .IsRequired();
            this.Property(t => t.Nom_int_reel)
           .IsRequired();
            this.Property(t => t.date_lancement_OT)
            .IsRequired();
            this.Property(t => t.Date_Debut_planifie)
            .IsRequired();
            this.Property(t => t.date_debut_prevu_ext)
           .IsRequired();
            this.Property(t => t.date_debut_reelle_ext)
            .IsRequired();
            this.Property(t => t.Coût_pieces_de_rechanges_reel)
           .IsRequired();
            this.Property(t => t.Date_mise_en_marche)
            .IsRequired();
            this.Property(t => t.Heure_mise_en_marche)
            .IsRequired();
            this.Property(t => t.date_debut_OT)
           .IsRequired();
            this.Property(t => t.Date_fin_Ot)
            .IsRequired();
            this.Property(t => t.Cause_annulation)
           .IsRequired();
            this.Property(t => t.Date_annulation)
            .IsRequired();
            this.Property(t => t.date_clôture)
            .IsRequired();
            this.Property(t => t.Rapport_Intervention)
           .IsRequired();
            this.Property(t => t.Duree_ext_reel_jr)
            .IsRequired();
            this.Property(t => t.Type_ECO)
           .IsRequired();
            this.Property(t => t.Duree_ext_planifie_jr)
            .IsRequired();
            this.Property(t => t.duree_tot_planif_jr)
            .IsRequired();
            this.Property(t => t.duree_tot_reel_jr)
           .IsRequired();

            this.Property(t => t.commentaire_EXT)
           .IsRequired();
            this.Property(t => t.Heure_Debut_OT)
            .IsRequired();
            this.Property(t => t.heuer_fin_ot)
           .IsRequired();
            this.Property(t => t.Date_Fin_Estimee)
            .IsRequired();
            this.Property(t => t.MesureCompteurPN)
            .IsRequired();
            this.Property(t => t.MesureCompteurREM)
           .IsRequired();

            this.Property(t => t.DiagnosticPanne)
            .IsRequired();
            this.Property(t => t.Ressource_Arrêtee)
           .IsRequired();
            this.Property(t => t.Date_arret)
            .IsRequired();
            this.Property(t => t.Heure_arrêt)
            .IsRequired();
            this.Property(t => t.OT_Personnel_Id)
           .IsRequired();


            // Table & Column Mappings
            this.ToTable("Ordre_de_travail");

            //relationShips
            

            this.HasRequired(t => t.equipement)
            .WithMany(t => t.ordres_de_travail)
            .HasForeignKey(t => t.Equipement_Id)
            .WillCascadeOnDelete(true);


            this.HasRequired(t => t.personnel)
            .WithMany(t => t.ordre_de_travails)
            .HasForeignKey(t => t.Personnel_Id)
            .WillCascadeOnDelete(true);


            this.HasRequired(t => t.cArr_Equip)
            .WithMany(t => t.ordres_de_travail)
            .HasForeignKey(t => t.cArr_Equip_Id)
            .WillCascadeOnDelete(true);






        }
    }
}
