using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Web.Data.Repository;
using Shop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        private readonly IOrdenarRepositori ordenarRepositori;

        public CitasController(IOrdenarRepositori ordenarRepositori)
        {
            this.ordenarRepositori = ordenarRepositori;
        }
        public async Task<IActionResult> Index()
        {
            var model = await ordenarRepositori.GetOrdersAsync(this.User.Identity.Name);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = await this.ordenarRepositori.GetDetallesTempsAsync(this.User.Identity.Name);
            return this.View(model);
        }
        public IActionResult AddProduct()
        {
            var model = new AddItemViewModel
            {
                Citas = this.ordenarRepositori.GetComboCita()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(AddItemViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                await this.ordenarRepositori.AddItemToOrderAsync(model, this.User.Identity.Name);
                return this.RedirectToAction("Create");
            }

            return this.View(model);
        }


    }
}
