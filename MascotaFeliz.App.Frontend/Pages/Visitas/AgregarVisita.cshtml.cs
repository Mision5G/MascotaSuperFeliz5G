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
        private readonly IRepositorioVeterinario _repoVeterinario;
        private readonly IRepositorioHistoria _repoHistoria;
        private readonly IRepositorioMascota _repoMascota;
        [BindProperty]
        public VisitaPyP visita { get; set; }
        public Historia historia {get;set;}
        public Veterinario veterinario { get; set; }
        public Mascota mascota { get; set; }

        public IEnumerable<Veterinario> listaVeterinarios { get; set; }
        public IEnumerable<Mascota> listaMascota { get; set; }

        public AgregarVisitaModel(){
            this._repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());
            this._repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());           
        }

        public void OnGet(int? historiaId){

            listaVeterinarios = _repoVeterinario.GetAllVeterinarios();

            if (historiaId.HasValue)
            {
                historia =  _repoHistoria.GetHistoria(historiaId.Value);
                visita = new VisitaPyP();
                Page();
                Console.WriteLine(historia.Id); 

            }
            else
            {
                RedirectToPage("./NotFound");
            }
                
        }

        public IActionResult OnPost(VisitaPyP visita , int veterinarioId, int historiaId)
        {
            if (ModelState.IsValid)
                {
                    veterinario = _repoVeterinario.GetVeterinario(veterinarioId);
                    historia = _repoHistoria.GetHistoria(historiaId);
                    visita = _repoVisitaPyP.AddVisitaPyP(visita); 
                    _repoVisitaPyP.AsignarVeterinario(visita.Id, veterinario.Id);
                    _repoHistoria.AsignarVisitaPyP(historia.Id, visita.Id);  

                    return Page();      
                }
            else
                {
                return RedirectToPage("/Mascotas/ListaMascotas");
                }
                    
                   
        }      
    }
}


