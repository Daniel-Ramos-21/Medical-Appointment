using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class BloqueHoraDto
    {
        public TimeSpan HoraBloque { get; set;  }

        public bool Disponible { get; set; }
    }
}
