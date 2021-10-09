using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class UsersDTO
    {
        public string Emailid { get; set; }

        public string Name { get; set; }

        //[DataType(DataType.Password)]
        public string Password { get; set; }


        public string Address { get; set; }
        public string jwtToken { get; set; }
    }
}
