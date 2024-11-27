using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            CitaMedicas = new HashSet<CitaMedica>();
            Iddoctors = new HashSet<Doctor>();
            Idenfermeros = new HashSet<Enfermero>();
            Idparamedicos = new HashSet<Paramedico>();
        }

        public int Idpac { get; set; }
        public string? Rut { get; set; }
        public string Nombre { get; set; } = null!;
        public int Pago { get; set; }
        public string Problema { get; set; } = null!;
        public string? HistoriaClínica { get; set; }
        public int? NúmeroDeCasa { get; set; }
        public string? Calle { get; set; }
        public string Ciudad { get; set; } = null!;
        public int? SalaId { get; set; }
        public int? Idambul { get; set; }

        public virtual Ambulancium? IdambulNavigation { get; set; }
        public virtual Sala? Sala { get; set; }
        public virtual NúmeroDeTelefonoDePaciente? NúmeroDeTelefonoDePaciente { get; set; }
        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }

        public virtual ICollection<Doctor> Iddoctors { get; set; }
        public virtual ICollection<Enfermero> Idenfermeros { get; set; }
        public virtual ICollection<Paramedico> Idparamedicos { get; set; }
    }
}
