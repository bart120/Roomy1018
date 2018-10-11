using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class Room
    {
        public int ID { get; set; }

        [Display(Name="Nom de la salle")]
        [Required(ErrorMessage = "{0} obligatoire")]
        [StringLength(40)]
        public string Name { get; set; }

        [Display(Name="Capacité")]
        [Required]
        [Range(0,int.MaxValue)]
        public int Capacity { get; set; }

        [Display(Name = "Prix")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Catégorie")]
        public int CategoryID { get; set; }

        [Display(Name = "Catégorie")]
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }


    }
}
