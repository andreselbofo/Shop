
namespace Shop.Web.Data.Repository
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;
    using Shop.Web.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OrdenarRepositori : GenericRepository<Cita>, IOrdenarRepositori
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public OrdenarRepositori(DataContext context, IUserHelper userHelper) : base(context)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task<IQueryable<Cita>> GetOrdersAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            if (await this.userHelper.IsUserInRoleAsync(user, "Admin"))
            {
                return this.context.Citas
                    .Include(o => o.Especialidad)
                    .OrderByDescending(o => o.Fecha);
            }

            return this.context.Citas
                .Include(o => o.Especialidad)
                .Where(o => o.User == user)
                .OrderByDescending(o => o.Fecha);
        }
        public async Task<IQueryable<Especialidad>> GetDetallesTempsAsync(string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return null;
            }

            return this.context.Especialidades
                .Include(o => o.Cita)
                .Where(o => o.User == user);
                
        }

        public async Task AddItemToOrderAsync(AddItemViewModel model, string userName)
        {
            var user = await this.userHelper.GetUserByEmailAsync(userName);
            if (user == null)
            {
                return;
            }

            var cita = await this.context.Citas.FindAsync(model.CitaId);
            if (cita == null)
            {
                return;
            }

            var especialidad = await this.context.Especialidades
                .Where(odt => odt.User == user && odt.Cita == cita)
                .FirstOrDefaultAsync();
            if (especialidad == null)
            {
                especialidad = new Especialidad
                {
                    Id = cita.Id,
                    Cita = cita,
                    User = user,
                };

                this.context.Especialidades.Add(especialidad);
            }
            else
            {
                //especialidad.Quantity += model.Quantity;
                this.context.Especialidades.Update(especialidad);
            }

            await this.context.SaveChangesAsync();
        }

        public async Task ModifyOrderDetailTempQuantityAsync(int id)
        {
            var especialidad = await this.context.Especialidades.FindAsync(id);
            if (especialidad == null)
            {
                return;
            }

            //especialidad.Quantity += quantity;
            if (especialidad.Id > 0)
            {
                this.context.Especialidades.Update(especialidad);
                await this.context.SaveChangesAsync();
            }
        }

        public IEnumerable<SelectListItem> GetComboCita()
        {
            throw new System.NotImplementedException();
        }
    }
}

