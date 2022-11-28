using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMM.Models
{
    public class UserDataModel : IdentityUser
    {
        [Key]
        override public string Id { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="UserName is required")]
        override public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "FirstName is required!")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "LastName is required!")]
        [DataType(DataType.Text)]
        public string LastName { get; set;}
        [DataType(DataType.Text)]
        public string EGN { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        override public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }       
        public bool Active { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

    }
}
