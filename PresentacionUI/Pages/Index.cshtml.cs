using AccesoDatos;
using Entidades;
using LogicaNegocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace PresentacionUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MedicalContext _context;

        public IndexModel(ILogger<IndexModel> logger, MedicalContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IList<Especialidad> Especialidades { get; set; }
        public IList<Doctor> Doctors { get; set; }

        public void OnGet()
        {
            Especialidades = _context.Especialidades.ToList();
            Doctors = _context.Doctors
                .Include(d => d.usuario)
                .Include(d => d.Especialidad)
                .ToList();
        }
    }
}
