using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class User
    {
        public string Lastname { get; set; }

        public string Firstname { get; set; }

        public string Mail { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
