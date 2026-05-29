using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LogicaNegocio;
using Entidades;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using AccesoDatos;


namespace PresentacionUI.Pages
{
    public class CitasModel : PageModel
    {
        //Variable privada que nos sirve solo de lectura de la clase citaBLL
        private readonly CitaBLL _citaBLL;
        

        //Inyeccion de dependencias por constructor
        public CitasModel(CitaBLL citaBLL)
        {
            _citaBLL = citaBLL;
        }

        [BindProperty] //Enlaza los datos del form con los de mis entidades
        public string dui { get; set; }

        [BindProperty]
        public string NombrePaciente { get; set; }

        [BindProperty]
        public string ApellidoPaciente { get; set; }

        [BindProperty]
        public int id_doctor { get; set; }

        [BindProperty]
        public DateOnly fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);//Definimos que la fecha de nuestro formulario inciara en la fecha actual.

        [BindProperty]
        public TimeSpan hora { get; set; }

        [BindProperty]
        public string motivo { get; set; }

        public string MensajeExito { get; set; } = string.Empty; // entidad que nos servira para enviar excepciones y que iniciara como vacio

        public string MensajeError { get; set; } = string.Empty;

        public List<Especialidad> Especialidades { get; set; } //LLama la lista de datos de la tabla entidades

        public List<BloqueHoraDto> HorasDisponibles { get; set; } = new List<BloqueHoraDto>();

        public bool MostrarPasoHoras { get; set; } = false;

        public void OnGet()
        {
            Especialidades = _citaBLL.ObtenerEspecialidades(); //Una vez que la pagina inicie obtendra el metodo para leer especialidades 
        }

        //Metodo que nos filtrara el paciente con Nombre y apellido atravez del campo dui y que JsonResult 
        //Convierta nuesta lista de datos en formato Json 
        public JsonResult OnGetPaciente(string dui)
        {
            if (string.IsNullOrEmpty(dui)) //Condicion si el campo dui esta vacio 
            {
                return new JsonResult(new { encontrado = false }); //y retornamos un valor como false
            }
            var usuario = _citaBLL.ObtenerUsuario(dui); //Declaramos una variable que obtendra los datos del usuario
            if (usuario != null) // Condicion si usuario es diferente a null 
            {
                return new JsonResult(new //Nos retorna el resultado en formato Json 
                {
                    encontrado = true, //y el valor que utilizaremos en js damos un valor de true
                    nombre = usuario.Nombre,
                    apellido = usuario.Apellido
                });
            }
            return new JsonResult(new { encontrado = false }); //Retorna el valor como false
        }

        //Metodo que nos filtrara por Especialidad el id del doctor y que JsonResult 
        //Convierta nuesta lista de datos en formato Json 
        public JsonResult OnGetDoctor(string especialidad) 
        {
            //Delclaramos la variable doctores que obtendra el 
            // Filtramos los doctores en la BLL, y con .Select() creamos una lista anónima 
            // guardando solo el ID del doctor y el nombre de la especialidad
            var doctores = _citaBLL.ObtenerDoctorporEspecialidad(especialidad)
                .Select(d => new { id= d.Id_Doctor, nombre = d.Especialidad.Nombre_especialidad })
                .ToList();
            // Retorna la lista de doctores convertida a formato JSON
            return new JsonResult(doctores);
        }

        public IActionResult OnPostContinuar()
        {
            ModelState.Remove("hora");
            if (!ModelState.IsValid)
            {
                Especialidades = _citaBLL.ObtenerEspecialidades();
                MensajeError = "Por favor, rellene todos los campos";
                return Page();
            }
            try
            {
                //Obtenemos los datos del doctor atravez de un metodo
                var doctor = _citaBLL.ObtenerDoctorPorID(id_doctor);
                //Si el doctor no existe mandamos un mensaje error
                if (doctor == null)
                {
                    MensajeError = "El doctor seleccionado no existe";
                    //Recargamos las lista de especialidades del form
                    Especialidades = _citaBLL.ObtenerEspecialidades();
                    //Recarga la pagina actual
                    return Page();
                }
                //asinamos 2 variables una tiene la hora de entrada del doctor
                //y la otra la hora de salida
                TimeSpan horaInicio = doctor.HoraEntrada;
                TimeSpan horaFin = doctor.HoraSalida;

                //En 2 variables definimos un rango estaticos para el horario de almuerzo
                TimeSpan InicioAlmuerzo = new TimeSpan(12, 0, 0);
                TimeSpan FinAlmuerzo = new TimeSpan(13, 0, 0);

                //Trae la lista de horas que ta estan reservadas para el doctor junto a la fecha
                //Por medio de un metodo
                List<TimeSpan> HorasOcupadas = _citaBLL.ObtenerHorasOcupadasPorFecha(id_doctor, fecha);
                //Inicializa la varible para obtenga la hora de entrada del doctor
                TimeSpan horaAuxiliar = horaInicio;

                //Con un bucle recorre la jornada del doctor
                while (horaAuxiliar < horaFin)
                {
                    //Si la hora actual cae en la hora de almuerzo 
                    if (horaAuxiliar >= InicioAlmuerzo && horaAuxiliar < FinAlmuerzo)
                    {
                        //salta el reloj directamente hasta el final del almuerzo
                        horaAuxiliar = FinAlmuerzo;
                        //y pasamos a la siguiente interacion
                        continue;
                    }
                //verificamos que la hora actual se encuentra en la lista de las horas ocupadas
                bool Ocupado = HorasOcupadas.Contains(horaAuxiliar);

                //Agregamos el bloque de tiempo de a lista que mostraremos en la pagina
                HorasDisponibles.Add(new BloqueHoraDto
                {
                    HoraBloque = horaAuxiliar, //aqui guarda la hora actual
                    Disponible = !Ocupado //Si esta ocupado o disponible sera false o true
                });
                //hacemos que la variable incremente en un intervalo de 15minutos para evaluar el siguiente bloque
                horaAuxiliar = horaAuxiliar.Add(TimeSpan.FromMinutes(15));

            }
                //Si el bucle termnina con exito mostrar horas sera true 
                //entonces damos luz verde para mostrar la lista de horas
            MostrarPasoHoras = true;
        }
            catch(Exception ex)
            {
                //Si algo falla mostraremos un mensaje de error
                MensajeError = "Error al calcular horario";
            }
            //Cargamos la lista de especialidades del form
            Especialidades = _citaBLL.ObtenerEspecialidades();
            //Refresca la pagina con nuevos datos calculados
            return Page();
        }



        //metodo asicrono que nos permitira insertar los datos y traer toda la logica de negocio
        //Y con IActionResult nos retornara a otra parte de la pagina 
        public async Task<IActionResult> OnPostAsync()
        {
            if (hora == TimeSpan.Zero)
            {
                MensajeError = "Debe selecionar una hora disponible para su cita";
                OnPostContinuar();
                return Page();
            }
            if (!ModelState.IsValid)
            {
                Especialidades = _citaBLL.ObtenerEspecialidades();
                MensajeError = "Por favor, rellene todos los campos";
                return Page();
            }


            try
            {
                bool CitaGuardada = await _citaBLL.RegistrarCitas(dui, id_doctor, fecha, hora, motivo);
                if (CitaGuardada)
                {
                    int IdCita = _citaBLL.ObtenerCitas(id_doctor, fecha, hora);

                    if(IdCita > 0)
                    {
                        TempData["CitaReciente"] = IdCita;
                        return RedirectToPage("./Confirmar_Cita");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Aquí atrapamos la excepciones CitaBLL
                MensajeError = ex.Message;
                OnPostContinuar();
            }
            catch (Exception ex)
            {
                // Aqui estarian otras execepciones que no son del CitaBLL
                MensajeError = "Ocurrió un error inesperado en el sistema: " + ex.Message;
                OnPostContinuar();
            }
            Especialidades = _citaBLL.ObtenerEspecialidades();
            return Page();

        }
    }
}