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
        //
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>

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
    }
}