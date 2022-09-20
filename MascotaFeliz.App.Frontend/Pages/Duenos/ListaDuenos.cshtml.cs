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
    public class ListaDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;
        public IEnumerable<Dueno> listaDuenos {get;set;}
        public IEnumerable<Dueno> listaDuenosFiltro {get;set;}
        
        public ListaDuenosModel()

        {

            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());

        }
        
        public void OnGet()
        {
            listaDuenos = _repoDueno.GetAllDuenos();
        }

       

        public IActionResult OnGet(string? duenoCedula)
            {
                if (duenoCedula != null)
                {
                   listaDuenosFiltro = _repoDueno.GetDuenosPorFiltro(duenoCedula); 
                }
                else{
                    listaDuenos = _repoDueno.GetAllDuenos();
                }
                if (listaDuenosFiltro == null)
                {
                    return RedirectToPage("./NotFound");
                }
                else
                    return Page();

                
                
            }
                
           
    }

        
        
}

