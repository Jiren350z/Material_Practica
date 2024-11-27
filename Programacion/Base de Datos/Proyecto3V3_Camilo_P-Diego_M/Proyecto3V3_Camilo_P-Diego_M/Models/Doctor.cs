using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            CitaMedicas = new HashSet<CitaMedica>();
            Medicamentos = new HashSet<Medicamento>();
            Idenfermeros = new HashSet<Enfermero>();
            Idpacientes = new HashSet<Paciente>();
        }

        public int Iddoc { get; set; }
        public string Nombre { get; set; } = null!;
        public string Especialización { get; set; } = null!;
        public string? HorarioDeAtención { get; set; }
        public string Rut { get; set; } = null!;
        public int NúmeroDeCasa { get; set; }
        public string Calle { get; set; } = null!;
        public string Ciudad { get; set; } = null!;

        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
        public virtual ICollection<Medicamento> Medicamentos { get; set; }

        public virtual ICollection<Enfermero> Idenfermeros { get; set; }
        public virtual ICollection<Paciente> Idpacientes { get; set; }
    }
}
