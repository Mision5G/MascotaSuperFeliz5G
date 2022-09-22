using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioVisitaPyP : IRepositorioVisitaPyP
    {
        /// <summary>
        //
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>

        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioVisitaPyP(AppContext appContext)
        {
            _appContext = appContext;
        }

        public VisitaPyP AddVisitaPyP(VisitaPyP VisitaPyP)
        {
            var VisitaPyPAdicionada = _appContext.VisitasPyP.Add(VisitaPyP);
            _appContext.SaveChanges();
            return VisitaPyPAdicionada.Entity;
        }

        public void DeleteVisitaPyP(int idVisitaPyP)
        {
            var VisitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v=> v.Id == idVisitaPyP);
            if (VisitaPyPEncontrada == null)
                return;
            _appContext.VisitasPyP.Remove(VisitaPyPEncontrada);
            _appContext.SaveChanges();
        }
        public VisitaPyP GetVisitaPyP(int idVisitaPyP)
        {
            return _appContext.VisitasPyP.FirstOrDefault(v => v.Id == idVisitaPyP);
        }

        public VisitaPyP UpdateVisitaPyP(VisitaPyP visitaPyP)
        {
            var VisitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(v => v.Id == visitaPyP.Id);
            if (VisitaPyPEncontrada != null)
            {
                VisitaPyPEncontrada.FechaVisita= visitaPyP.FechaVisita;
                             
                _appContext.SaveChanges();
            }
            return VisitaPyPEncontrada;
        } 
        public Veterinario AsignarVeterinario(int idVisitaPyP, int idVeterinario)
        {
            var VisitaPyPEncontrada = _appContext.VisitasPyP.FirstOrDefault(m => m.Id == idVisitaPyP);
            if (VisitaPyPEncontrada != null)
            {
                var veterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idVeterinario);
                if (veterinarioEncontrado != null)
                {
                    VisitaPyPEncontrada.Veterinario = veterinarioEncontrado;
                    _appContext.SaveChanges();
                }
                return veterinarioEncontrado;
            }
            return null;
        }

    }
}
