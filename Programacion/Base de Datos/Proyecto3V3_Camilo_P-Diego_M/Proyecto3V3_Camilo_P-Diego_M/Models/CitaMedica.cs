using System;
using System.Collections.Generic;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class CitaMedica
    {
        public int IdcitaMed { get; set; }
        public string Motivo { get; set; } = null!;
        public int Pago { get; set; }
        public string? DepartamentoMedico { get; set; }
        public int Día { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }
        public int? Idpaciente { get; set; }
        public int? Idsal { get; set; }
        public int? Idrecepcionista { get; set; }
        public int? Iddoctor { get; set; }

        public virtual Doctor? IddoctorNavigation { get; set; }
        public virtual Paciente? IdpacienteNavigation { get; set; }
        public virtual Recepcionistum? IdrecepcionistaNavigation { get; set; }
        public virtual Sala? IdsalNavigation { get; set; }
    }
}
