using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Repository
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        private readonly DataContext context;
        private readonly ICitaRepository citaRepository;

        public CitaRepository(DataContext context,ICitaRepository citaRepository) : base(context)
        {
            this.context = context;
            this.citaRepository = citaRepository;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Citas.Include(p => p.User);
        }

        public IEnumerable<SelectListItem> GetComboCita()
        {
            var list = this.context.Citas.Select(p => new SelectListItem
            {
                 Text = p.Especialidad,
                 Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
               Text = "(Seleccione una cita...)",
               Value = "0"
            });

            return list;
            
        }
    }
}
