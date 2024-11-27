using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class NúmeroDeTelefonoDeFarmacium
    {
        public int IdnumFar { get; set; }
        public string NúmeroDeTelefono { get; set; } = null!;

        public virtual Farmacium IdnumFarNavigation { get; set; } = null!;
    }
}
