using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ListaCitas
    {
        private readonly MedicalContext _context;

        public ListaCitas(MedicalContext context)
        {
            _context = context;
        }

        public List<Citas> ObtenerCitasDoctor(int idDoctor)
        {
            return _context.Citas
                .Where(c => c.Id_doctor == idDoctor)
                .Include(c => c.Paciente)
                .OrderBy(c => c.Fecha)
                .ThenBy(c => c.Hora)
                .ToList();
        }

        public void ActualizarEstado(int IdCita, string estado)
        {
            var cita = _context.Citas
        .FirstOrDefault(c => c.Id_Citas == IdCita);

            if (cita != null)
            {
                cita.Estado = estado;
                _context.SaveChanges();
            }
        }

    }
}
