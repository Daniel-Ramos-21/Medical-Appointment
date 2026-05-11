using Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{        
    //La clase heredara las capacida de hacer consultas.
    public  class MedicalContext : DbContext
    {
       
            //Constructor que permite pasar la configuacion del DbContext
            //Es como una cadena de conexion al servidor de la base de datos
            public MedicalContext(DbContextOptions<MedicalContext> options) : base(options)
            {

            }

            //Esto es ver la lista de tablas que tenemos en la base datos
            //y dice que cree las tablas a partir de la clases que tenemos en la 
            //bibloteca entidades.
            public DbSet<Doctor> Doctors { get; set; }

            public DbSet<Especialidad> Especialidades { get; set; }

    }
}

