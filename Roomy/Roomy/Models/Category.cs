using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Roomy.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name ="Nom de la catégorie")]
        [Required (ErrorMessage = "{0} obligatoire")]
        [StringLength(50)]
        public string Name { get; set; }

        //public ICollection<Room> Rooms { get; set; } => uniquement en MVC
    }
}
