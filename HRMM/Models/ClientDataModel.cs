using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMM.Models
{
    public class ClientDataModel
    {
        [Key]
        public string Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please insert a name")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a name")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert a phone number")]
        public string TelNumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please insert an email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose an age")]
        public bool Elder { get; set; }
         
    }
}
