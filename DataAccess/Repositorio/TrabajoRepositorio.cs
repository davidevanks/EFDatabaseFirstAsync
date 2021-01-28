using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorio
{
    public class TrabajoRepositorio
    {
        public Trabajos ObtenerTrabajo(int trabajoId)
        {
            Trabajos trabajo = null;

            using (var db = new TrabajosConexion())
            {
                //db.Database.Log = Console.WriteLine;

                Console.WriteLine("1. obteniendo trabajo...");

                trabajo = db.Trabajos.FirstOrDefault(x => x.Id == trabajoId);

                Console.WriteLine("2. trabajo obtenido.");
            }

            return trabajo;
        }

        //metodo asincronico
        public async Task<Trabajos> ObtenerTrabajoAsync(int trabajoId)
        {
            Trabajos trabajo = null;

            using (var db = new TrabajosConexion())
            {
                Console.WriteLine("1. obteniendo trabajo asincrónico...");

                trabajo = await (db.Trabajos.FirstOrDefaultAsync(x => x.Id == trabajoId));

                Console.WriteLine("2. trabajo asincrónico obtenido.");
            }

            return trabajo;
        }
    
        public MensajeRespuesta AgregarTrabajo(Trabajos trabajo)
        {
            MensajeRespuesta respuesta = new MensajeRespuesta();

            try
            {
                //codigo
                using (var db = new TrabajosConexion())
                {
                    db.Entry(trabajo).State = EntityState.Added;

                    Console.WriteLine("1. Agregando nuevo trabajo.");

                    db.SaveChanges();

                    Console.WriteLine("2. Trabajo agregado correctamente.");
                }

            } catch(Exception ex)
            {
                respuesta = new MensajeRespuesta(ex.Message);
            }

            return respuesta;
        }

        //metodo asincrónico
        public async Task<MensajeRespuesta> AgregarTrabajoAsync(Trabajos trabajo)
        {
            MensajeRespuesta respuesta = new MensajeRespuesta();

            try
            {
                //codigo
                using (var db = new TrabajosConexion())
                {

                    db.Entry(trabajo).State = EntityState.Added;

                    Console.WriteLine("1. Agregando nuevo trabajo asincrónico.");

                    await (db.SaveChangesAsync());

                    Console.WriteLine("2. Trabajo asincrónico agregado correctamente.");
                }

            }
            catch (Exception ex)
            {
                respuesta = new MensajeRespuesta($"{ex.Message} - {ex.InnerException}");
            }

            return respuesta;
        }
    }

    public class MensajeRespuesta
    {
        public bool OK { get; set; }
        public string Mensaje { get; set; }

        public MensajeRespuesta()
        {
            OK = true;
            Mensaje = "transacción realizada correctamente";
        }

        public MensajeRespuesta(string mensaje)
        {
            OK = false;
            Mensaje = string.Format($"ERROR: {mensaje}");
        }
    }
}
