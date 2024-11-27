using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class NúmeroDeTelefonoEnfermero
    {
        public int IdnumEnf { get; set; }
        public string NúmeroDeTelefono { get; set; } = null!;

        public virtual Enfermero IdnumEnfNavigation { get; set; } = null!;
    }
}
