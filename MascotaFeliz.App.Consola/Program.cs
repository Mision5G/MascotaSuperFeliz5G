using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria= new RepositorioHistoria(new Persistencia.AppContext()); 
        private static IRepositorioVisitaPyP _repoVisitaPyP= new RepositorioVisitaPyP(new Persistencia.AppContext());
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
                       
            //ListarDuenosFiltro();      
            //AddDueno();
            //BuscarDueno(2);

            //ListarVeterinariosFiltro();
            //AddVeterinario();
            //BuscarVeterinario(1);
           // AddMascota();
           ListarMascotasFiltro();
           //ListarMascotas();
            //AddHistoria();
            //AddVisitaPyP();
            //ListarDuenos();
            

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Cedula = "6789",
                Nombres = "Juan",
                Apellidos = "Bautista", 
                Direccion = "Calle 10 # 1-49",
                Telefono = "45644366",
                Correo = "juanchitomayor@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }
        private static void AddMascota() {
            var Mascota = new Mascota
            {
                Nombre = "Mulán",
                Color = "Café con negro", 
                Especie = "Felino",
                Raza = "Criolla"
            };
            _repoMascota.AddMascota(Mascota);

        }
        private static void AddHistoria() {
            var Historia = new Historia
            {
                FechaInicial= DateTime.Now
            };
            _repoHistoria.AddHistoria(Historia);

        }

        private static void AddVisitaPyP() {
            var VisitaPyP= new VisitaPyP
            {
                FechaVisita= DateTime.Now,
                Temperatura = 39.2F,
                Peso=2.3F,
                FrecuenciaCardiaca=210.4F,
                FrecuenciaRespiratoria=45F,
                EstadoAnimo= "Deprimido",
                Recomendaciones="Más vegetales y menos comida procesada"
            };
            _repoVisitaPyP.AddVisitaPyP(VisitaPyP);

        }

         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Cedula = "33448",
                Nombres = "Peter",
                Apellidos = "Pan", 
                Direccion = "Transversal 9 # 17A-155",
                Telefono = "3363365858",
                TarjetaProfesional = "TP52546"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("Fel");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void ListarMascotasFiltro()
        {
            var mascotasF = _repoMascota.GetMascotasPorFiltro("Mul");
            foreach (Mascota m in mascotasF)
            {
                Console.WriteLine(m.Nombre + " " + m.Especie);
            }

        }

         private static void ListarMacotas(){
            var mascotas = _repoMascota.GetAllMascotas();
            foreach(Mascota m in mascotas){
                Console.WriteLine(m.Nombre+ " " + m.Especie + " " +m.Color);
            }
        }

        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void ListarDuenos(){
            var duenos = _repoDueno.GetAllDuenos();
            foreach(Dueno d in duenos){
                Console.WriteLine(d.Nombres+" "+d.Apellidos+" "+d.Cedula);
            }
        }

       


        
        
    }
}
