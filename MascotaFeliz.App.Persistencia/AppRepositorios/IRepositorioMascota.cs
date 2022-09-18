
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioMascota
    {
        Mascota AddMascota(Mascota Mascota);
       
        Mascota UpdateMascota(Mascota Mascota);
        void DeleteMascota(int idMascota);      
        
        Mascota GetMascota(int Id);
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
        Veterinario AsignarVeterinario(int idMascota, int idVeterinario);
        Dueno AsignarDueno(int idMascota, int idDueno);
        Historia AsignarHistoria(int idMascota, int idHistoria);
    }
}