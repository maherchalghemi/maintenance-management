using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.Login)
            .IsRequired();
            this.Property(t => t.Password)
           .IsRequired();









            // Table & Column Mappings
            this.ToTable("User");

            //relationShips

            this.HasRequired(t => t.groupUser)
            .WithMany(t => t.users)
            .HasForeignKey(t => t.GroupUser_Id)
            .WillCascadeOnDelete(true);

            this.HasRequired(t => t.personnel)
            .WithMany(t => t.users)
            .HasForeignKey(t => t.Personnel_Id)
            .WillCascadeOnDelete(true);



        }
    }
}
