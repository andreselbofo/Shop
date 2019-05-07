using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Repository
{
    public interface ICitaRepository : IGenericRepository<Cita>
    {
        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboCita();
    }
}
