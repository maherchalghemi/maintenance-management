using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class PieceRechangeMap : EntityTypeConfiguration<PieceRechange>
    {
        public PieceRechangeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.CodeBarreFab);
                
				 this.Property(t => t.PrixHT);
              
				this.Property(t => t.QteReappro);
                
				 this.Property(t => t.unité);
              
				this.Property(t => t.CodePiece)
                .IsRequired();
				this.Property(t => t.Designation)
                .IsRequired();
				
               
				this.Property(t => t.CodeBarre);
               
				 
               
				this.Property(t => t.Description);
                
				 this.Property(t => t.code_Fournisseur);
                
				this.Property(t => t.CodeCatgorie);
                
				this.Property(t => t.stock);
                
				 this.Property(t => t.Date_creation);
               
				this.Property(t => t.date_Modification);
                
				 this.Property(t => t.LONGBLOB);
                
				this.Property(t => t.stock_scurit);
                
				this.Property(t => t.Etat_Pice);
             
				
				
				
				
				
				 
				

            // Table & Column Mappings
            this.ToTable("PieceRechange");

            
				
           
        }
    }
}
