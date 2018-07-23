using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMAO.App.Entities
{
    public class TestScheduler_DTO
    {
        public int Id { get; set; }//
        public DateTime start_date { get; set; }//
        public DateTime end_date { get; set; }//
        public string text { get; set; }

        public Nullable<int> room_id { get; set; }

        public string color { get; set; }

        public Nullable<long> event_length { get; set; }
        public string rec_type { get; set; }

        public Nullable<int> event_pid { get; set; }

        public Nullable<int> Equipement_Id { get; set; } //id_Equipement
        public Nullable<int> Personnel_Id { get; set; } // id_Personnel
        
    }
}
