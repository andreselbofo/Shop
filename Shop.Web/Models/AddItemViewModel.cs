using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    public class AddItemViewModel
    {
        [Display(Name = "Product")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un producto.")]
        public int ProductId { get; set; }

        [Display(Name = "Cita")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una cita")]
        public int CitaId { get; set; }

        [Range(0.0001, double.MaxValue, ErrorMessage = "La cantidad debe ser un número positivo.")]
        public double Quantity { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }

        public IEnumerable<SelectListItem> Citas { get; set; }
    }


}
