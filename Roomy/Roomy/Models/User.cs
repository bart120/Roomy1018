using Roomy.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Roomy.Resources;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roomy.Models
{
    //[Table("nom_de_la_table", Schema = "nom_du_schema")]
    public class User
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //[Column("nom")]
        /*[Display(Name = "Nom de famille", ShortName = "Nom", Prompt = "Nom de l'utilisateur")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]*/
        [Display(Name = "name", ResourceType = typeof(Shared))]
        [Required(ErrorMessageResourceType = typeof(Shared), ErrorMessageResourceName = "required_field")]
        [StringLength(128, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        public string Lastname { get; set; }

        //[Display(Name = "Prénom")]
        [Display(Name = "firstname", ResourceType = typeof(Shared))]
        [StringLength(128, ErrorMessage = "Le champ {0} doit contenir {1} caractères max.")]
        public string Firstname { get; set; }

        [Display(Name = "Adresse mail")]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Le champ {0} n'est pas au bon format.")]
        public string Mail { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champ {0} est obligatoire")]
        [StringLength(150)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
            ErrorMessage = "{0} trop faible")]
        public string Password { get; set; }

        [Display(Name = "Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La confirmation n'est pas bonne.")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }

        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        [Age(18, ErrorMessage = "Il faut avoir plus de {1} ans.")]
        [Column(TypeName = "datetime2")]
        public DateTime? Birthdate { get; set; }
    }
}
