using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class StockOutMap : EntityTypeConfiguration<StockOut>
    {
        public StockOutMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Ref);
            this.Property(t => t.personnel);
            this.Property(t => t.Date);
            this.Property(t => t.magasin);
            this.Property(t => t.piece);
            this.Property(t => t.observation);
            this.Property(t => t.refExt);
            this.Property(t => t.qte);






            // Table & Column Mappings
            this.ToTable("StockOut");



        }
    }
}
