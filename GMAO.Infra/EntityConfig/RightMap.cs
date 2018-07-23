using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class RightMap : EntityTypeConfiguration<Right>
    {
        public RightMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);









            // Table & Column Mappings
            this.ToTable("Right");



            //relationShips

            this.HasRequired(t => t.fonctionality)
            .WithMany(t => t.rights)
            .HasForeignKey(t => t.fonctionality_Id)
            .WillCascadeOnDelete(true);


            this.HasRequired(t => t.groupUser)
            .WithMany(t => t.rights)
            .HasForeignKey(t => t.GroupUser_Id)
            .WillCascadeOnDelete(true);



        }
    }
}
