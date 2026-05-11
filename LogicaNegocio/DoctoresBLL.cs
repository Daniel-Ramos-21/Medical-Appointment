using AccesoDatos;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class DoctoresBLL
    {
        //Campo privado que nos sirva solo como lectura del context
        private readonly MedicalContext _context;

        //Constructor del medicalContext
        //y guarda la conexion en mi variable privada
        public DoctoresBLL(MedicalContext context)
        {
            _context = context;
        }

        public List<Doctor> ObtenerDoctores()
         {
            return _context.Doctors
            //Esto representaria un JOIN entre la tabla medicos y especialidades
            .Include(m => m.Especialidad)
            .ToList();
        }
    }
}
