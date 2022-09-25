using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioVisitaPyP
    {
        VisitaPyP AddVisitaPyP(VisitaPyP VisitaPyP);
        VisitaPyP GetVisitaPyP(int idVisitaPyP);
        void DeleteVisitaPyP(int idVisitaPyP);
        VisitaPyP UpdateVisitaPyP(VisitaPyP VisitaPyP);
        Veterinario AsignarVeterinario(int idVisitaPyP, int idVeterinario);
        //IEnumerable<VisitaPyP> GetAllVisitas();
        //Veterinario GetVetVisita(int idVisitaPyP);
        IEnumerable<VisitaPyP> GetAllVisita();
        //IEnumerable<VisitaPyP> GetVisitaPorHistoria(int idHistoria);
    }
}
