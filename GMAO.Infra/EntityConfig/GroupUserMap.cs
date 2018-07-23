using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class GroupUserMap : EntityTypeConfiguration<GroupUser>
    {
        public GroupUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Intitule)
                .IsRequired();
            this.Property(t => t.Description)
           .IsRequired();


            // Table & Column Mappings
            this.ToTable("GroupUser");

            //relationShips
            this.HasRequired(t => t.company)
                    .WithMany(t => t.groupUsers)
                    .HasForeignKey(t => t.Company_Id)
                    .WillCascadeOnDelete(true);





        }
    }
}
