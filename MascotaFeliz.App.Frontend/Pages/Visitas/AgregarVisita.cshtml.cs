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
    public class AgregarVisitaModel : PageModel
    {
        private readonly IRepositorioVisitaPyP _repoVisitaPyP;
        //private static IRepositorioHistoria _repoHistoria= new RepositorioHistoria(new Persistencia.AppContext()); 
        [BindProperty]
        public VisitaPyP visita { get; set; }
        //public Historia historia { get; set; }

        public AgregarVisitaModel(){
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int? visitaId){
            if (visitaId.HasValue){
                visita = _repoVisitaPyP.GetVisitaPyP(visitaId.Value);
            }
            else{
                visita = new VisitaPyP();
            }
            if (visita == null){
                return RedirectToPage("./NotFound");
            }
            else
            return Page();
        }

        public IActionResult OnPost(){
            if (!ModelState.IsValid)
                {
                    return Page();
                }
            if (visita.Id > 0)
                {
                    visita = _repoVisitaPyP.UpdateVisitaPyP(visita);
                }
            else
                {
                    _repoVisitaPyP.AddVisitaPyP(visita);           
                }
            return Page();
        }
    }
}

