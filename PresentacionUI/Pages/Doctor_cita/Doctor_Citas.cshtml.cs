using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace PresentacionUI.Pages.Docto_cita
{
    [Authorize]
    public class Doctor_CitasModel : PageModel
    {
        private readonly ListaCitas _listaCitas;

        public Doctor_CitasModel(ListaCitas listaCitas)
        {
            _listaCitas = listaCitas;
        }

        public List<Citas> Citas { get; set; }

        public void OnGet()
        {
            int idUsuario = int.Parse(
                User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Citas = _listaCitas.ObtenerCitasDoctor(idUsuario);
        }
        public IActionResult OnPost(int idCita, string estado)
        {
            _listaCitas.ActualizarEstado(idCita, estado);

            return RedirectToPage();
        }
    }
}
