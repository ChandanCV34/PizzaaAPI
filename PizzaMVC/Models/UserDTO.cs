﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaMVC.Models
{
    public class UserDTO
    {
        //[Display(Name="Email address")]
        //[Required(ErrorMessage ="Email address is requires")]
       
        [DataType(DataType.EmailAddress)]
        public string Emailid { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
        public string jwtToken { get; set; }

    }
}
