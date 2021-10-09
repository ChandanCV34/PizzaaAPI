using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class UserDTO
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is requires")]
        [EmailAddress(ErrorMessage = "Invalid Email Addres")]
        public string Emailid { get; set; }

        public string Name { get; set; }

        //[DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]

        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public string jwtToken { get; set; }

    }
}
