using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Medicamento
    {
        public int Idmed { get; set; }
        public string? CódigoEnBodega { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime FechaDeCaducidad { get; set; }
        public string? InstruccionesDeUso { get; set; }
        public string Integredientes { get; set; } = null!;
        public string? FórmulaFarmaceutica { get; set; }
        public int? Idfarmacia { get; set; }
        public int? Iddoctor { get; set; }

        public virtual Doctor? IddoctorNavigation { get; set; }
        public virtual Farmacium? IdfarmaciaNavigation { get; set; }
    }
}
