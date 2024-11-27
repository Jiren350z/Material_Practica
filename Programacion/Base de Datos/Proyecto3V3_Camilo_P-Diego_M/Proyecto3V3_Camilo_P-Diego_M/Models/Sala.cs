using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Sala
    {
        public Sala()
        {
            CitaMedicas = new HashSet<CitaMedica>();
            Pacientes = new HashSet<Paciente>();
        }

        public int Idsala { get; set; }
        public string? Código { get; set; }
        public string Tipo { get; set; } = null!;
        public int CapacidadDePacientes { get; set; }
        public string NombreDePaciente { get; set; } = null!;
        public DateTime? Fecha { get; set; }
        public TimeSpan? HoraDeEntrada { get; set; }
        public TimeSpan? HoraDeSalida { get; set; }
        public string? Diagnóstico { get; set; }
        public string? Tratamiento { get; set; }

        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
