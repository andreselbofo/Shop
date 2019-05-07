using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Data.Entities;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data.Repository
{
    public interface IOrdenarRepositori : IGenericRepository<Cita>
    {
        Task<IQueryable<Cita>> GetOrdersAsync(string userName);

        Task<IQueryable<Especialidad>> GetDetallesTempsAsync(string userName);
        Task AddItemToOrderAsync(AddItemViewModel model, string userName);

        Task ModifyOrderDetailTempQuantityAsync(int id);
        IEnumerable<SelectListItem> GetComboCita();
    }
}
