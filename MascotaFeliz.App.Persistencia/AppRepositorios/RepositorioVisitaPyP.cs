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
    }
}