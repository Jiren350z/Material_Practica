using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class NúmeroDeTelefonoDePaciente
    {
        public int IdnumPac { get; set; }
        public string NúmeroDeTelefono { get; set; } = null!;

        public virtual Paciente IdnumPacNavigation { get; set; } = null!;
    }
}
