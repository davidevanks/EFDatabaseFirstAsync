using DataAccess;
using DataAccess.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppConsolaDF
{
    class Program
    {
        static void Main(string[] args)
        {
            Trabajos trabajo = new Trabajos {
                Titulo = "Trabajo con registros sincrónicos",
                Ubicacion = "Ciudad de méxico",
                Salario = 1870,
                Descripcion = "Se necesita de un programador que sepa manejar metodos sincrónicos.",
                TipoContratoId = 2,
                CategoriaTrabajoId = 12,
                FechaRegistro = DateTime.Now,
                FechaModificacion = DateTime.Now,
                Estado = true
            };

            var trabajoAsincronico = new TrabajoRepositorio().AgregarTrabajoAsync(trabajo);

            Console.WriteLine("3. este código se ejecuta despues de obtener un trabajo.");

            Console.WriteLine("4. este código se ejecuta a continuación.");

            Console.WriteLine("5. este código se ejecuta al final.");

            Console.WriteLine($"Estado: {trabajoAsincronico.Result.OK}, Mensaje: {trabajoAsincronico.Result.Mensaje}");


            //var agregarTrabajo = new TrabajoRepositorio().AgregarTrabajo(trabajo);

            //Console.WriteLine("3. este código se ejecuta despues de obtener un trabajo.");

            //Console.WriteLine("4. este código se ejecuta a continuación.");

            //Console.WriteLine("5. este código se ejecuta al final.");

            //Console.WriteLine($"ID: {trabajo.Id}, TÍTULO: {trabajo.Titulo}");

            //Console.WriteLine($"ESTADO: {agregarTrabajo.OK}, MENSAJE: {agregarTrabajo.Mensaje}");


            //var trabajo = new TrabajoRepositorio().ObtenerTrabajo(1);

            //Console.WriteLine("3. este código se ejecuta despues de obtener un trabajo.");

            //Console.WriteLine("4. este código se ejecuta a continuación.");

            //Console.WriteLine("5. este código se ejecuta al final.");

            //Console.WriteLine($"ID: {trabajo.Id}, TÍTULO: {trabajo.Titulo}");

            //ejecutar
            //var trabajo = new TrabajoRepositorio().ObtenerTrabajoAsync(1);

            //Console.WriteLine("3. este código se ejecuta despues de obtener un trabajo.");

            //Console.WriteLine("4. este código se ejecuta a continuación.");

            //Console.WriteLine("5. este código se ejecuta al final.");

            //Console.WriteLine($"ID: {trabajo.Result.Id}, TÍTULO: {trabajo.Result.Titulo}");


            Console.ReadKey();
        }


        
    }
}
