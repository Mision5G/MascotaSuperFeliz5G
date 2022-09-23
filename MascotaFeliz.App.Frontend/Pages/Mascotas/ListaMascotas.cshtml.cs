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
    public class ListaMascotasModel : PageModel
    {
        private readonly IRepositorioMascota _repoMascota;
        private readonly IRepositorioDueno _repoDueno;
        private readonly IRepositorioVeterinario _repoVeterinario;
        public IEnumerable<Mascota> listadoMascota {get;set;}
        public IEnumerable<Dueno> listadoDueno {get;set;}
        public IEnumerable<Veterinario> listadoVeterinario {get;set;}
        public ListaMascotasModel()
        {
            this._repoMascota = new RepositorioMascota(new Persistencia.AppContext());
            this._repoDueno = new RepositorioDueno(new Persistencia.AppContext());
            this._repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }

        public void OnGet()
        {
            listadoMascota = _repoMascota.GetAllMascotas();
            listadoDueno = _repoDueno.GetAllDuenos();
            listadoVeterinario= _repoVeterinario.GetAllVeterinarios();
        }

    }
}
