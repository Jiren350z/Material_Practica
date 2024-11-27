using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Enfermero
    {
        public Enfermero()
        {
            Iddoctors = new HashSet<Doctor>();
            Idpacients = new HashSet<Paciente>();
        }

        public int Idenf { get; set; }
        public string Nombre { get; set; } = null!;
        public string Rut { get; set; } = null!;
        public string? HorarioDeAtención { get; set; }
        public int NúmeroDeCasa { get; set; }
        public string Calle { get; set; } = null!;
        public string Ciudad { get; set; } = null!;

        public virtual NúmeroDeTelefonoEnfermero? NúmeroDeTelefonoEnfermero { get; set; }

        public virtual ICollection<Doctor> Iddoctors { get; set; }
        public virtual ICollection<Paciente> Idpacients { get; set; }
    }
}
