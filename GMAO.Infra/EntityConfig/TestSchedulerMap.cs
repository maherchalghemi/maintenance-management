using GMAO.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.Infra.data.EntityConfig
{
    public class TestSchedulerMap : EntityTypeConfiguration<TestScheduler>
    {
        public TestSchedulerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties

            this.Property(t => t.start_date)
            .IsRequired();
            this.Property(t => t.end_date)
           .IsRequired();
            this.Property(t => t.text)
            .IsRequired();
            this.Property(t => t.room_id)
           .IsRequired();
            this.Property(t => t.color)
            .IsRequired();
            this.Property(t => t.event_length)
            .IsRequired();
            this.Property(t => t.rec_type)
            .IsRequired();
            this.Property(t => t.event_pid)
            .IsRequired();








            // Table & Column Mappings
            this.ToTable("TestScheduler");

            //relationShips

            this.HasRequired(t => t.equipement)
            .WithMany(t => t.testScheduler)
            .HasForeignKey(t => t.Equipement_Id)
            .WillCascadeOnDelete(true);

            this.HasRequired(t => t.personnel)
            .WithMany(t => t.testSchedulers)
            .HasForeignKey(t => t.Personnel_Id)
            .WillCascadeOnDelete(true);



        }
    }
	
}
