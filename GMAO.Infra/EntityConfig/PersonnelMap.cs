using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class PersonnelMap : EntityTypeConfiguration<Personnel>
    {
        public PersonnelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Nom)
            .IsRequired();
            this.Property(t => t.Prenom)
            .IsRequired();
            this.Property(t => t.DateNaissance);
            
            this.Property(t => t.NomPrenom);
            this.Property(t => t.Adresse);

            this.Property(t => t.Email);

            this.Property(t => t.DateAjout);

            this.Property(t => t.CIN);

            this.Property(t => t.CNSS);

            this.Property(t => t.Sexe);

            this.Property(t => t.Integre);

            this.Property(t => t.DebutIntegration);

            this.Property(t => t.FinIntegration);

            this.Property(t => t.IDService);
            
            this.Property(t => t.Tel);
           
            this.Property(t => t.Matricule)
           .IsRequired();
            this.Property(t => t.Diplomes);
            
            this.Property(t => t.AutresCompetances);
           
            this.Property(t => t.AptitudesPhysiques);
            
            this.Property(t => t.ExperienceProfessionelles);
            
            this.Property(t => t.Actif);
           
            this.Property(t => t.EstTitulaire);
           
            this.Property(t => t.DateTitularisation);
            
            this.Property(t => t.Grade);
         
            this.Property(t => t.NomPre);
            
            this.Property(t => t.IDSite);
           
            this.Property(t => t.IDSociete);
            
            this.Property(t => t.CINDELIVRELE);
         
            this.Property(t => t.LNAISSANCE);
            
            this.Property(t => t.GSM);
           
            this.Property(t => t.DLIQUIDATION);
           
            this.Property(t => t.RIP);
           
            this.Property(t => t.IdCompany);
           







            // Table & Column Mappings
            this.ToTable("Personnel");

            //relationShips

            

            



        }
    }
}
