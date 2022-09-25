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
    public class HistoriaMascotasModel : PageModel
    {
       // private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioHistoria _repoHistoria; 
        private readonly IRepositorioVisitaPyP _repoVisitaPyP; 
        public VisitaPyP visitaPyP {get;set;}
       // public Mascota mascota {get;set;}
        public Historia historia {get;set;}
        public IEnumerable<VisitaPyP> listadoVisitas {get;set;}
        //[BindProperty]
       
        
        public HistoriaMascotasModel()
        {
            //this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());          
            
        }

        public IActionResult OnGet(int historiaId)
        {   
            if (historiaId> 0)
            {
               historia = _repoHistoria.GetHistoria(historiaId); 

               //listadoVisitas = _repoHistoria.GetListadoVisitasPorHistoria(historiaId);
               listadoVisitas = _repoVisitaPyP.GetAllVisitas();
               return Page();
            }
            else
            {
               
               return RedirectToPage("./ListaMascotas");
            }
        }
    }
}
