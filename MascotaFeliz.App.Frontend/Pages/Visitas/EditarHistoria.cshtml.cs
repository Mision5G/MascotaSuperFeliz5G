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
    public class EditarHistoriaModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioHistoria _repoHistoria;
        [BindProperty]
        public VisitaPyP visita { get; set; }
        public Veterinario veterinario { get; set; }
        public IEnumerable<Veterinario> listaVeterinarios { get; set; }
        public Historia historia {get;set;}
        
        public EditarHistoriaModel()
        {

            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());       
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        }

        public void OnGet(int? visitaId){

            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();

            if (visitaId.HasValue)
            {
                visita = _repoVisitaPyP.GetVisitaPyP(visitaId.Value);   
                Console.WriteLine(visita.Recomendaciones);  

            }
            else
            {
              RedirectToPage("./NotFound");
            }
         
                
        }

        public IActionResult OnPost(VisitaPyP visita, int veterinarioId){
          
            if(ModelState.IsValid)
            {    
                veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                visita.Veterinario = veterinario;
                visita = _repoVisitaPyP.UpdateVisitaPyP(visita);
                return RedirectToPage("/Mascotas/ListaMascotas"); 
            }
            else 
            {
                return RedirectToPage("./NotFound");
            } 

             
                        
        }
    }
}
