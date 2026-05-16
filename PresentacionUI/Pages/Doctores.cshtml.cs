using AccesoDatos;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio;


namespace PresentacionUI.Pages
{
    public class DoctoresModel : PageModel
    {
        //Campo privado que nos sirva solo como lectura del context

        private readonly DoctoresBLL _doctorBLL;


        //Inyeccion de dependencias
        public DoctoresModel(DoctoresBLL doctoresBLL)
        {
            _doctorBLL = doctoresBLL;
        }
        //crea una lista publica con los datos del medico de la tabla medicos
        public IList<Doctor> Doctores { get; set; }

        //Metodo por defecto que maneja todos los eventos que ocurren cada vez que se visita la pagina.
        public void OnGet()
        {
            Doctores = _doctorBLL.ObtenerDoctores();
        }
    }
}
