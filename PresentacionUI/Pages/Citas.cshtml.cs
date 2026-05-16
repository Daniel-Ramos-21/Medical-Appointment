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

        //metodo asicrono que nos permitira insertar los datos y traer toda la logica de negocio
        //Y con IActionResult nos retornara a otra parte de la pagina 
        public async Task<IActionResult> OnPostAsync()
        {
            //Condicion que evaluara la reglas de validacion de la entidades 
            if (!ModelState.IsValid)
            {
                //Retornamos la lista de especialidades para que este lista cuando se ingrese a la pagina 
                Especialidades = _citaBLL.ObtenerEspecialidades(); 
                //Mensaje de error de nuestro atributo
                MensajeError = "Por favor, rellene todos los campos correctamente.";
                //Nos retorna a la misma pagina 
                return Page();
            }

            try
            {
                //Declaracion de variable booleana que obtendra el metodo para registrar una cita y validad si la cita se registro
                bool resultado = await _citaBLL.RegistrarCitas(dui, id_doctor, fecha, hora, motivo);

                //Condicion si resultado obtine los datos ingresados 
                if (resultado)
                {
                    //Mensaje de datos ingresados con exito
                    MensajeExito = "¡La cita se ha registrado exitosamente!";
                    Especialidades = _citaBLL.ObtenerEspecialidades(); 
                    //Retornamos a la pagina de index
                    return RedirectToPage("/Index");
                }
            }
            catch (ArgumentException ex)
            {
                // Aquí atrapamos la excepciones CitaBLL
                MensajeError = ex.Message;
            }
            catch (Exception ex)
            {
                // Aqui estarian otras execepciones que no son del CitaBLL
                MensajeError = "Ocurrió un error inesperado en el sistema: " + ex.Message;
            }

            Especialidades = _citaBLL.ObtenerEspecialidades();
            return Page();
        }

    }
}