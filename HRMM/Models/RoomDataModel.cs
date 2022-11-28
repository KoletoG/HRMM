using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMM.Models
{
    public class RoomDataModel
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a space")]
        public int Space { get; set; }
        public Types Type { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose availability")]
        public bool Free { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a price for elder")]
        public double PriceE { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a price for young")]
        public double PriceY { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a number")]
        public int Number { get; set; }       
    }
    public enum Types
    {
        two_identical_beds,
        apartment,
        doublebed_room,
        penthouse,
        largeroom
    }
}
