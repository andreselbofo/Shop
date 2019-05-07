using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Entities
{
    public class Especialidad : IEntity
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Cita Cita { get; set; }

        [Display(Name = "Medico General")]
        public string MedicoGeneral { get; set; }

        [Display(Name = "Odontolodia")]
        public string Odontologia { get; set; }

        [Display(Name = "Oftamologia")]
        public string Oftamologia { get; set; }
    }
}
