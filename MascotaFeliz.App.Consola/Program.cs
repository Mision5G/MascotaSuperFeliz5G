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
           // AddDueno();
            //BuscarDueno(2);
             //ListarDuenos();
             //EditarDueno();
             //EliminarDueno();


            //ListarVeterinariosFiltro();
            //AddVeterinario();
            //BuscarVeterinario(1);
            //EditarVet();
            //EliminarVet();
            //ListarVet();
          

            //AddMascota();
           //ListarMascotasFiltro();
           //ListarMascotas();
           //BuscarMascota(1);
           //EditarMascota(6);
            //EliminarMascota(1);
            //AsignarVeterinario();
            //AsignarDueno();
            //AsignarHistoria();


        //AddHistoria();
        //AsignarVisitasPyP();
            

        //AddVisitaPyP(); 
           //EliminarVisitaPyP(1);
           //EditarVisitaPyP(3);
           AsignarVet_to_VPyP();

            

        }
//Todos los Adds
        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Cedula = "6632231",
                Nombres = "Sofía",
                Apellidos = "Cardenas", 
                Direccion = "Calle 10 # 1-49",
                Telefono = "45644366",
                Correo = "juanchitomayor@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }
        private static void AddMascota() {
            var Mascota = new Mascota
            {
                Nombre = "Morgan",
                Color = "Café", 
                Especie = "Felino",
                Raza = "Criolla"
            };
            _repoMascota.AddMascota(Mascota);

        }
        private static void AddHistoria() {
            var Historia = new Historia
            {
                FechaInicial= new DateTime(2021, 11, 28)
            };
            _repoHistoria.AddHistoria(Historia);

        }

        private static void AddVisitaPyP() {
            var VisitaPyP= new VisitaPyP
            {
                //FechaVisita= DateTime.Now,
                FechaVisita=new DateTime(2020, 03, 13),
                Temperatura = 27.8F,
                Peso=13.1F,
                FrecuenciaCardiaca=85.4F,
                FrecuenciaRespiratoria=93F,
                EstadoAnimo= "Hiperactividad",
                Recomendaciones="Paseos"
            };
            _repoVisitaPyP.AddVisitaPyP(VisitaPyP);

        }

         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Cedula = "348928",
                Nombres = "Azul",
                Apellidos = "Consuelo", 
                Direccion = "Transversal 9 # 17A-155",
                Telefono = "3363365858",
                TarjetaProfesional = "TP87499"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }


        //Asignar visita PyP, Dueños y demás

        private static void AsignarVisitasPyP()
        {
           var VisitaPyP= _repoHistoria.AsignarVisitaPyP(3,5);
            Console.WriteLine(VisitaPyP.FechaVisita);
           /* var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", CedulaVeterinario = "123", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }*/
        }

       private static void AsignarVeterinario()
        {
            var veterinario = _repoMascota.AsignarVeterinario(7, 5);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void AsignarDueno()
        {
            var dueno = _repoMascota.AsignarDueno(7, 2);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void AsignarHistoria()
        {
            var historia = _repoMascota.AsignarHistoria(3, 3);
            Console.WriteLine(historia.FechaInicial);
        }
       private static void AsignarVet_to_VPyP()
        {
            var veterinario = _repoVisitaPyP.AsignarVeterinario(1,1);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }










        //BUSCAR POR ID

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

        private static void BuscarMascota(int idMascota)
        {
            var mascotasB = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascotasB.Nombre + " " + mascotasB.Especie);
        }
       /* private static void BuscarHistoria(int idHistoria)
        {
            var historiaB = _repoHistoria.GetAllHistoria(idMascota);
            Console.WriteLine(mascotasB.Nombre + " " + mascotasB.Especie);
        }*/


//LISTAR POR FILTRO


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

        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }


// LISTAR TODOS

         private static void ListarMascotas(){
            var mascotas = _repoMascota.GetAllMascotas();
            foreach(Mascota m in mascotas){
                Console.WriteLine(m.Nombre+ " " + m.Especie + " " +m.Color);
            }
        }

        

        private static void ListarDuenos(){
            var duenos = _repoDueno.GetAllDuenos();
            foreach(Dueno d in duenos){
                Console.WriteLine(d.Nombres+" "+d.Apellidos+" "+d.Cedula);
            }
        } 

        private static void ListarVet(){
            var vet = _repoVeterinario.GetAllVeterinarios();
            foreach(Veterinario v in vet){
                Console.WriteLine(v.Nombres+" "+v.Apellidos+" "+v.TarjetaProfesional);
            }
        }

//EDITAR
        private static void EditarDueno(int idDueno){
            var dueno = _repoDueno.GetDueno(idDueno);
            dueno.Cedula = "10289957";
            dueno.Nombres = "Pacho";
            dueno.Apellidos = "El Matematico"; 
            dueno.Direccion = "Trasversal Recta 398";                
            dueno.Telefono = "559662";
            dueno.Correo = "Francis_M@gmail.com";
            _repoDueno.UpdateDueno(dueno);
        }

        private static void EditarVet(int idVeterinario){
            var vet = _repoVeterinario.GetVeterinario(idVeterinario);
            vet.Cedula = "2123743";
            vet.Nombres = "Oscar";
            vet.Apellidos = "Salamanca"; 
            vet.Direccion = "El pais de las maravillas";
            vet.Telefono = "32743822";
            vet.TarjetaProfesional = "TP9933";
            _repoVeterinario.UpdateVeterinario(vet);
        }

        private static void EditarMascota(int idMascota){
            var mascotaE = _repoMascota.GetMascota(idMascota);
            mascotaE.Nombre = "Mengana";
            mascotaE.Color = "Café"; 
            mascotaE.Especie = "Felino";
            mascotaE.Raza = "Criolla";
            _repoMascota.UpdateMascota(mascotaE);
        }

        private static void EditarVisitaPyP(int idVisitaPyP){
            var vis = _repoVisitaPyP.GetVisitaPyP(idVisitaPyP);
            vis.FechaVisita = new DateTime(2022, 08, 19);
            vis.Temperatura = 31.2F;
            vis.Peso=4.7F;
            vis.FrecuenciaCardiaca=198.4F;
            vis.FrecuenciaRespiratoria=39F;
            vis.EstadoAnimo= "Contento";
            vis.Recomendaciones="Más paseos";
            _repoVisitaPyP.UpdateVisitaPyP(vis);
        }


//ELIMINAR


        private static void EliminarDueno(int idDueno){
            _repoDueno.DeleteDueno(idDueno);
        }  

        private static void EliminarVet(int idVeterinario){
            _repoVeterinario.DeleteVeterinario(idVeterinario);
        }  
        private static void EliminarMascota(int idMascota){
            _repoMascota.DeleteMascota(idMascota);
        } 
         private static void EliminarVisitaPyP(int idVisitaPyP){
            _repoVisitaPyP.DeleteVisitaPyP(idVisitaPyP);
        }
        
    }
}
