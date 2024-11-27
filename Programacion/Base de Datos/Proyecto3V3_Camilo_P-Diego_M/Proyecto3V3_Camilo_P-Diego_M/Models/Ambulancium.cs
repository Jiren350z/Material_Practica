using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Ambulancium
    {
        public Ambulancium()
        {
            Pacientes = new HashSet<Paciente>();
            Idparamedicos = new HashSet<Paramedico>();
        }

        public int Idamb { get; set; }
        public string? Patente { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? UbicaciónActual { get; set; }
        public bool Disponibilidad { get; set; }
        public TimeSpan? HoraDeLlamada { get; set; }
        public int? DíaDeLlamada { get; set; }
        public int? MesDeLlamada { get; set; }
        public int? AñoDeLlamada { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }

        public virtual ICollection<Paramedico> Idparamedicos { get; set; }
    }
}
