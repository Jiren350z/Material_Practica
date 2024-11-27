using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Recepcionistum
    {
        public Recepcionistum()
        {
            CitaMedicas = new HashSet<CitaMedica>();
        }

        public int Idrecep { get; set; }
        public string? Rut { get; set; }
        public string? DepartamentoMédico { get; set; }
        public string? Horario { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }

        public virtual NúmeroDeTelefonoDeRecepcionistum? NúmeroDeTelefonoDeRecepcionistum { get; set; }
        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
    }
}
