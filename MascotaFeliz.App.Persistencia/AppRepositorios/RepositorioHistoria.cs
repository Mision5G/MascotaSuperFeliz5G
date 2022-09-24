using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        /// <summary>
        /// Referencia al contexto de Historia
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Historia AddHistoria(Historia Historia)
        {
            var HistoriaAdicionada = _appContext.Historias.Add(Historia);
            _appContext.SaveChanges();
            
            return HistoriaAdicionada.Entity;
        }



         public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrada == null)
                return;
            _appContext.Historias.Remove(historiaEncontrada);
            _appContext.SaveChanges();
        }

       public IEnumerable<Historia> GetAllHistorias()
        {
            return _appContext.Historias;
        }

       /* public IEnumerable<Historia> GetListadoVisitasPorHistoria(int idHistoria)
        {
            var historiaEncontrada = GetHistoria(idHistoria);
            if (historiaEncontrada != null)  //Si se tienen saludos
            {                
                
                foreach ( IEnumerable<Historia> visitaPyP in historiaEncontrada)
                {
                    return visitaPyP;
                }       
            }
            return visitaPyP;
        }*/

        /* public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var Mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (Mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    Mascotas = Mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return Mascotas;
        }*/
       

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.FirstOrDefault(h => h.Id == idHistoria);
        }

        public Historia UpdateHistoria(Historia historia)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(h => h.Id == historia.Id);
            if (historiaEncontrada != null)
            {
                historiaEncontrada.FechaInicial = historia.FechaInicial;
                             
                _appContext.SaveChanges();
            }
            return historiaEncontrada;
        } 
        public VisitaPyP AsignarVisitaPyP(int idHistoria, int idVisita)
        {
            var historiaEncontrada = _appContext.Historias.FirstOrDefault(m => m.Id == idHistoria);
            if (historiaEncontrada != null)
            {
                var VisitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisita);
                if (VisitaPyPEncontrada != null)    
                {
                    if(historiaEncontrada.VisitasPyP!=null){
                        historiaEncontrada.VisitasPyP.Add(VisitaPyPEncontrada);
                    }
                    else{
                        historiaEncontrada.VisitasPyP = new List<VisitaPyP>{VisitaPyPEncontrada};
                    }
                    _appContext.SaveChanges();
                }
                return VisitaPyPEncontrada;
            }
            return null;
        }
        
    }
}