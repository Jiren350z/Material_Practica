using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class NúmeroTelefonoParamedico
    {
        public int IdnumPara { get; set; }
        public string NúmeroDeTelefono { get; set; } = null!;

        public virtual Paramedico IdnumParaNavigation { get; set; } = null!;
    }
}
