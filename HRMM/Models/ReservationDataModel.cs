using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMM.Models
{
    public class ReservationDataModel
    {
        [Key]
        public string Id { get; set; }
        public RoomDataModel RoomR { get; set; }
        public UserDataModel UserR { get; set; }
        public ClientDataModel ClientsR { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Breakfast { get; set; }
        public bool AllInclusive { get; set;}
        public double FinalPrice { get; set; }
    }
}
