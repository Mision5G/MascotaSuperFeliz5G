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
    public class EditarMascotasModel : PageModel
    {

        private readonly IRepositorioMascota _repoMascota;
        private static IRepositorioHistoria _repoHistoria= new RepositorioHistoria(new Persistencia.AppContext()); 
        [BindProperty]
        public Mascota mascota { get; set; }
        public Historia historia { get; set; }

            public EditarMascotasModel()
            {
                this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            }
            public IActionResult OnGet(int? mascotaId)
            {
                if (mascotaId.HasValue)
                {
                    mascota = _repoMascota.GetMascota(mascotaId.Value);
                }
                else
                {
                    mascota = new Mascota();
                    
                }
                if (mascota == null)
                {
                    return RedirectToPage("./NotFound");
                }
                else
                    return Page();
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (mascota.Id > 0)
                {
                    mascota = _repoMascota.UpdateMascota(mascota);
                }
                else
                {
                    _repoMascota.AddMascota(mascota);
                    _repoHistoria.AddHistoria(historia);

                   if(historia.FechaInicial> 0)
                    {
                     return Page(): 
                    }  
                    else
                    {
                        
                    }                 
                 
                }
                return Page();
        }
    }
}
