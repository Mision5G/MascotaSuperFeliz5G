
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
       /* 
        Mascota UpdateMascota(Mascota Mascota);
        void DeleteMascota(int idMascota);
        
        
        Mascota GetMascota(int idMascota);*/
        IEnumerable<Mascota> GetAllMascotas();
        IEnumerable<Mascota> GetMascotasPorFiltro(string filtro);
    }
}