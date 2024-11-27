using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class NúmeroDeTelefonoDeRecepcionistum
    {
        public int IdnumRecep { get; set; }
        public string NúmeroDeTelefono { get; set; } = null!;

        public virtual Recepcionistum IdnumRecepNavigation { get; set; } = null!;
    }
}
