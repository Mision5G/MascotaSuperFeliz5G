using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetalleMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        public Mascota mascota {get;set;}
        public Dueno dueno{get;set;}
        public DetalleMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        }
        public IActionResult OnGet(int mascotaId)
        {
            mascota = _repoMascota.GetMascota(mascotaId);
            if (mascota == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
