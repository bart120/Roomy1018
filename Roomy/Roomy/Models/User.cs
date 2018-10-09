using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class User
    {
        [Display(Name = "Nom de famille", ShortName = "Nom", Prompt = "Nom de l'utilisateur")]
        public string Lastname { get; set; }

        [Display(Name = "Prénom")]
        public string Firstname { get; set; }

        [Display(Name = "Adresse mail")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        public string ConfirmedPassword { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
