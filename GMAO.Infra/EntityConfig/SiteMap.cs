using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class SiteMap : EntityTypeConfiguration<Site>
    {
        public SiteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            
				this.Property(t => t.Name)
                .IsRequired();
                this.Property(t => t.code_site)
                .IsRequired();
				this.Property(t => t.adresse_site);
                
				 this.Property(t => t.no_tel);
                
				this.Property(t => t.no_fax);
                
				this.Property(t => t.email);
                
				this.Property(t => t.Ville);
                
				this.Property(t => t.pays);
                
				 this.Property(t => t.Code_postale);
                
				this.Property(t => t.Date_creation);
                
				 this.Property(t => t.date_Modification);
                
			
				
				
				
				
				 
				

            // Table & Column Mappings
            this.ToTable("Site");

            //relationShips
            
					
				
				
           
        }
    }
	
}
