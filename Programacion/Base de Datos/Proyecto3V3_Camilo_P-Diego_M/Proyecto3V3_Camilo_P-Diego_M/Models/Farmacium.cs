using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Farmacium
    {
        public Farmacium()
        {
            Medicamentos = new HashSet<Medicamento>();
        }

        public int Idfar { get; set; }
        public string? HorarioDeAtencion { get; set; }
        public string Ubicacion { get; set; } = null!;
        public int? CapacidadDeStock { get; set; }
        public string? ListaDeMedicamentos { get; set; }

        public virtual NúmeroDeTelefonoDeFarmacium? NúmeroDeTelefonoDeFarmacium { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }
    }
}
