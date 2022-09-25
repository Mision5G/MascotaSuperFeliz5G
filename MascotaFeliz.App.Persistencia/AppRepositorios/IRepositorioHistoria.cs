
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        Historia AddHistoria(Historia Historia);
        IEnumerable<Historia> GetAllHistorias();
        //IEnumerable<Historia> GetHistoriasPorFiltro(string filtro);
        Historia GetHistoria(int idHistoria);
        Historia UpdateHistoria(Historia Historia);
        void DeleteHistoria(int idHistoria);
        VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisita);
       //IEnumerable<VisitaPyP> GetListadoVisitasPorHistoria(int idHistoria);
       IEnumerable<VisitaPyP> GetVisitaHistoria(int idHistoria);

    }
}