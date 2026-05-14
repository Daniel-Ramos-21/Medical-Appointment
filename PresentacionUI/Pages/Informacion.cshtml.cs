using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentacionUI.Pages
{
    //Inyeccion de dependencias y el constructoe
    public class InformacionModel(DoctoresBLL doctoresBLL) : PageModel
    {
        //Declaracion de una variable privada que accede a la logica de negocio
        //la varible tiene el atributo readonly para que no pueda ser cambiada.
        private readonly DoctoresBLL _doctorBLL = doctoresBLL;

        //Propiedad publica que es la que nos permitira leer los datos de la entidad en
        //el html, un nullable que indica que la propiedad puede esta vacia
        public Doctor ? Doctores { get; set; }

        //metodo con IActionResult que nos permite mandar al usuario a otra pagina o 
        //retornarlo a otro lado.
        public IActionResult OnGet(int id)
        {
            //llamanmos a la logica de negocio para buscar en la base de datos el id
            //del doctor, y el resultado lo guadamos en doctores.
            Doctores = _doctorBLL.ObtenerInforID(id);

            //Si el id no exite lo retorna al apartedo original de doctores.
            if (Doctores == null)
            {
                return RedirectToPage("/Pages_Doctores");
            }
            //Si el id existe carga la pagina de Informacion.cshtml.
            return Page();
        }
    }
}
