using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Entities
{
    public class Cita : IEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de cita")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}", ApplyFormatInEditMode = false)]
        public DateTime Fecha { get; set; }

        [Required]
        public User User { get; set; }

        [Display(Name = "Especialidad")]
        public string Especialidad { get; set; }
    }
}
