using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace LogicaNegocio
{
    public class CitaBLL
    {
        //Variable privada que nos sirve solo de lectura del Context y del HttpsClient
        private readonly MedicalContext _context;
        private readonly HttpClient _httpClient;

        //Inyeccion de dependencias por constructor
        public CitaBLL (MedicalContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

       

        //Metodo que es la conexion a la API externa y la validacion de leer unicamente dias feriados
        private async  Task<bool> ESDiaFeriado(DateOnly fecha)
        {
            //Construcion de la url dinamica segun el año de la cita.
            string url = $"https://date.nager.at/api/v3/PublicHolidays/{fecha.Year}/SV";

            //instaciamos un objeto de la clase httpclient
           
            
                try
                {
                    //Llamada peticion Get a la API 
                    HttpResponseMessage respuesta = await _httpClient.GetAsync(url);

                    //Si la API responde con el 200 OK
                    if(respuesta.IsSuccessStatusCode)
                    {
                        //Leemos el JSON que nos devolvió el servidor
                        string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();

                        //Traducimos el JSON a una lista de C# 
                        List<DiaFeriado>? diaFeriados = JsonConvert.DeserializeObject<List<DiaFeriado>>(jsonRespuesta);

                    if (diaFeriados != null)
                    {
                        //Verificamos si la fecha existe en la lista de feriados
                        return diaFeriados.Any(f => DateOnly.FromDateTime(f.Date) == fecha);
                    }
                    }
                }
                catch(Exception )
                {
                    return false;
                }
            return false;
        }
           
        public List<Especialidad> ObtenerEspecialidades()
        {
            return _context.Doctors
                .Select(d => d.Especialidad)
                .Distinct()
                .ToList();
        }

        public List<Doctor> ObtenerDoctorporEspecialidad(string especialidad)
        {
            return _context.Doctors
                .Where(d => d.Especialidad.Nombre_especialidad == especialidad)
                .ToList();
        }

        public Usuarios? ObtenerUsuario(string dui)
        {
            return _context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.DUI == dui);
        }

        public Doctor? ObtenerDoctorPorID(int ID_Doctor)
        {
            return _context.Doctors.Find(ID_Doctor);
                
        }

        public async Task<bool> RegistrarCitas(string dui, int doctor, DateOnly Fecha, TimeSpan Hora, string motivo)
        {
           
            if (Fecha.DayOfWeek == DayOfWeek.Saturday || Fecha.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new ArgumentException("Los días Sábados y Domingos los doctores no están disponibles.");
            }

            if (Fecha <= DateOnly.FromDateTime(DateTime.Now))
            {
                throw new ArgumentException("No se pueden registrar citas en el pasado");
            }

            if (await ESDiaFeriado(Fecha))
            {
                throw new ArgumentException($"No se puede registrar la cita porque la fecha seleccionada es un día feriado en El Salvador.");
            }

            var doc = _context.Doctors.Find(doctor);

            if (doc == null)
            {
                throw new ArgumentException("El doctor seleccionado no existe en el sistema.");
            }


            if (Hora < doc.HoraEntrada || Hora > doc.HoraSalida)
            {
                throw new ArgumentException($"El doctor no atiende a esa hora. Su horario de atención es de {doc.HoraEntrada} a {doc.HoraSalida}.");
            }

            // 5. Creación del registro
            var paciente = ObtenerUsuario(dui);
            if (paciente == null)
            {
                throw new ArgumentException("El DUI ingresado no pertenece a ningún paciente registrado.");
            }

            var registrar = new Citas
            {
                Id_Paciente = paciente.Id_Usuario,
                Id_doctor = doctor,
                Fecha = Fecha,
                Hora = Hora,
                Motivo = motivo
            };

            _context.Citas.Add(registrar);
            await _context.SaveChangesAsync(); 

            return true;
        }

        public List<TimeSpan> ObtenerHorasOcupadasPorFecha(int ID_Doctor, DateOnly Fecha_Cita)
        {
            try
            {
                return _context.Citas
                    .Where(c => c.Id_doctor == ID_Doctor && c.Fecha == Fecha_Cita)
                    .Select(c => c.Hora)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las fechas ocupadas");
            }
        }

        public int ObtenerCitas(int idDoctor, DateOnly fechaCita, TimeSpan HoraCita)
        {
            try
            {
                var cita = _context.Citas
                    .FirstOrDefault(c => c.Id_doctor == idDoctor && c.Fecha == fechaCita && c.Hora == HoraCita);
                return cita != null ? cita.Id_Citas : 0;
            }
            catch(Exception ex)
            {
                throw new Exception("Error al recuperar el Id de la cita : " + ex.Message);
            }
        }

        public Citas? ObtenerCitasID(int id)
        {
            return _context.Citas
                .AsTracking()
                .Include(c => c.Paciente)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.usuario)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.Especialidad)
                .FirstOrDefault(c => c.Id_Citas == id);
        }

    }
}
