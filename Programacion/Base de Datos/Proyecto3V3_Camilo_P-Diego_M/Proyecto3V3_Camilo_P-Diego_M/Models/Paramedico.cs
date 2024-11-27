using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Paramedico
    {
        public Paramedico()
        {
            Idambuls = new HashSet<Ambulancium>();
            Idpacientes = new HashSet<Paciente>();
        }

        public int Idpar { get; set; }
        public string Nombre { get; set; } = null!;
        public string Rut { get; set; } = null!;
        public string? HorarioDeAtención { get; set; }
        public string Certificación { get; set; } = null!;
        public int NúmeroDeCasa { get; set; }
        public string Calle { get; set; } = null!;
        public string Ciudad { get; set; } = null!;

        public virtual NúmeroTelefonoParamedico? NúmeroTelefonoParamedico { get; set; }

        public virtual ICollection<Ambulancium> Idambuls { get; set; }
        public virtual ICollection<Paciente> Idpacientes { get; set; }
    }
}
