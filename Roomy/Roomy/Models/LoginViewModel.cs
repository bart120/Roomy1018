using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Login")]
        [Required]
        public string Mail { get; set; }


        [Display(Name = "Mot de passe")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
