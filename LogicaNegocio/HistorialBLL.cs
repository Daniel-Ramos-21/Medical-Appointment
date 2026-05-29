using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;


namespace LogicaNegocio
{
    public  class HistorialBLL
    {
        private readonly MedicalContext _context;

        public HistorialBLL(MedicalContext context)
        {
            _context = context;
        }

        public List<Citas> HistorialCitas(int id)
        {
            return _context.Citas
                .Where(c => c.Id_Paciente == id)
                .Include(c => c.Paciente)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.usuario)
                .Include(c => c.Doctor)
                .ThenInclude(d => d.Especialidad)
                .ToList();
        }

    }
}
