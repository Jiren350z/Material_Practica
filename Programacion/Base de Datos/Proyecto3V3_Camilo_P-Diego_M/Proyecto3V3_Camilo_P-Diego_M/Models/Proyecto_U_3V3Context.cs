using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proyecto3V3_Camilo_P_Diego_M.Models
{
    public partial class Proyecto_U_3V3Context : IdentityDbContext
    {
        public Proyecto_U_3V3Context()
        {
        }

        public Proyecto_U_3V3Context(DbContextOptions<Proyecto_U_3V3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Ambulancium> Ambulancia { get; set; } = null!;
        public virtual DbSet<CitaMedica> CitaMedicas { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Enfermero> Enfermeros { get; set; } = null!;
        public virtual DbSet<Farmacium> Farmacia { get; set; } = null!;
        public virtual DbSet<Medicamento> Medicamentos { get; set; } = null!;
        public virtual DbSet<NúmeroDeTelefonoDeFarmacium> NúmeroDeTelefonoDeFarmacia { get; set; } = null!;
        public virtual DbSet<NúmeroDeTelefonoDePaciente> NúmeroDeTelefonoDePacientes { get; set; } = null!;
        public virtual DbSet<NúmeroDeTelefonoDeRecepcionistum> NúmeroDeTelefonoDeRecepcionista { get; set; } = null!;
        public virtual DbSet<NúmeroDeTelefonoEnfermero> NúmeroDeTelefonoEnfermeros { get; set; } = null!;
        public virtual DbSet<NúmeroTelefonoParamedico> NúmeroTelefonoParamedicos { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Paramedico> Paramedicos { get; set; } = null!;
        public virtual DbSet<Recepcionistum> Recepcionista { get; set; } = null!;
        public virtual DbSet<Sala> Salas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=HEROTOLLGOLOSUS\\SQLSERVEREXPRESS; database=Proyecto_U_3V3; integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            modelBuilder.Entity<Ambulancium>(entity =>
            {
                entity.HasKey(e => e.Idamb)
                    .HasName("PK__Ambulanc__932197C298B23031");

                entity.HasIndex(e => e.Patente, "UQ__Ambulanc__CA6551662B26B919")
                    .IsUnique();

                entity.Property(e => e.Idamb).HasColumnName("IDAmb");

                entity.Property(e => e.AñoDeLlamada).HasColumnName("Año_de_llamada");

                entity.Property(e => e.DíaDeLlamada).HasColumnName("Día_de_llamada");

                entity.Property(e => e.HoraDeLlamada).HasColumnName("Hora_de_llamada");

                entity.Property(e => e.Marca)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MesDeLlamada).HasColumnName("Mes_de_llamada");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Patente)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.UbicaciónActual)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Ubicación_actual");
            });

            modelBuilder.Entity<CitaMedica>(entity =>
            {
                entity.HasKey(e => e.IdcitaMed)
                    .HasName("PK__Cita_med__7AF11908FCA1623A");

                entity.ToTable("Cita_medica");

                entity.Property(e => e.IdcitaMed).HasColumnName("IDCitaMed");

                entity.Property(e => e.DepartamentoMedico)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Departamento_medico");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idpaciente).HasColumnName("IDPaciente");

                entity.Property(e => e.Idrecepcionista).HasColumnName("IDRecepcionista");

                entity.Property(e => e.Idsal).HasColumnName("IDSal");

                entity.Property(e => e.Motivo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddoctorNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.Iddoctor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_four");

                entity.HasOne(d => d.IdpacienteNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.Idpaciente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_one");

                entity.HasOne(d => d.IdrecepcionistaNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.Idrecepcionista)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_three");

                entity.HasOne(d => d.IdsalNavigation)
                    .WithMany(p => p.CitaMedicas)
                    .HasForeignKey(d => d.Idsal)
                    .HasConstraintName("FK_two");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("PK__Doctor__93E3A42C009D3353");

                entity.ToTable("Doctor");

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Calle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Especialización)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeAtención)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_de_atención");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NúmeroDeCasa).HasColumnName("Número_de_casa");

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enfermero>(entity =>
            {
                entity.HasKey(e => e.Idenf)
                    .HasName("PK__Enfermer__922E7E2B4BDB3F79");

                entity.ToTable("Enfermero");

                entity.Property(e => e.Idenf).HasColumnName("IDEnf");

                entity.Property(e => e.Calle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeAtención)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_de_atención");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NúmeroDeCasa).HasColumnName("Número_de_casa");

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasMany(d => d.Iddoctors)
                    .WithMany(p => p.Idenfermeros)
                    .UsingEntity<Dictionary<string, object>>(
                        "EasisteD",
                        l => l.HasOne<Doctor>().WithMany().HasForeignKey("Iddoctor").HasConstraintName("FK__EAsisteD__IDDoct__797309D9"),
                        r => r.HasOne<Enfermero>().WithMany().HasForeignKey("Idenfermero").HasConstraintName("FK__EAsisteD__IDEnfe__787EE5A0"),
                        j =>
                        {
                            j.HasKey("Idenfermero", "Iddoctor").HasName("PK__EAsisteD__4A82519811755808");

                            j.ToTable("EAsisteD");

                            j.IndexerProperty<int>("Idenfermero").HasColumnName("IDEnfermero");

                            j.IndexerProperty<int>("Iddoctor").HasColumnName("IDDoctor");
                        });
            });

            modelBuilder.Entity<Farmacium>(entity =>
            {
                entity.HasKey(e => e.Idfar)
                    .HasName("PK__Farmacia__92680E79A0D2794D");

                entity.Property(e => e.Idfar).HasColumnName("IDFar");

                entity.Property(e => e.CapacidadDeStock).HasColumnName("Capacidad_de_stock");

                entity.Property(e => e.HorarioDeAtencion)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_de_atencion");

                entity.Property(e => e.ListaDeMedicamentos)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Lista_de_medicamentos");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medicamento>(entity =>
            {
                entity.HasKey(e => e.Idmed)
                    .HasName("PK__Medicame__941E75944685AEBE");

                entity.ToTable("Medicamento");

                entity.HasIndex(e => e.CódigoEnBodega, "UQ__Medicame__7233961EF50DE055")
                    .IsUnique();

                entity.Property(e => e.Idmed).HasColumnName("IDMed");

                entity.Property(e => e.CódigoEnBodega)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Código_en_bodega");

                entity.Property(e => e.FechaDeCaducidad)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_de_caducidad");

                entity.Property(e => e.FórmulaFarmaceutica)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Fórmula_farmaceutica");

                entity.Property(e => e.Iddoctor).HasColumnName("IDDoctor");

                entity.Property(e => e.Idfarmacia).HasColumnName("IDFarmacia");

                entity.Property(e => e.InstruccionesDeUso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Instrucciones_de_uso");

                entity.Property(e => e.Integredientes)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IddoctorNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.Iddoctor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Medicamen__IDDoc__02084FDA");

                entity.HasOne(d => d.IdfarmaciaNavigation)
                    .WithMany(p => p.Medicamentos)
                    .HasForeignKey(d => d.Idfarmacia)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Medicamen__IDFar__01142BA1");
            });

            modelBuilder.Entity<NúmeroDeTelefonoDeFarmacium>(entity =>
            {
                entity.HasKey(e => e.IdnumFar)
                    .HasName("PK__NúmeroDe__8D039F1C9C33FD94");

                entity.Property(e => e.IdnumFar)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNumFar");

                entity.Property(e => e.NúmeroDeTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumFarNavigation)
                    .WithOne(p => p.NúmeroDeTelefonoDeFarmacium)
                    .HasForeignKey<NúmeroDeTelefonoDeFarmacium>(d => d.IdnumFar)
                    .HasConstraintName("FK__NúmeroDeT__IDNum__59FA5E80");
            });

            modelBuilder.Entity<NúmeroDeTelefonoDePaciente>(entity =>
            {
                entity.HasKey(e => e.IdnumPac)
                    .HasName("PK__NúmeroDe__5DCA472A9D5F8180");

                entity.ToTable("NúmeroDeTelefonoDePaciente");

                entity.Property(e => e.IdnumPac)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNumPac");

                entity.Property(e => e.NúmeroDeTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumPacNavigation)
                    .WithOne(p => p.NúmeroDeTelefonoDePaciente)
                    .HasForeignKey<NúmeroDeTelefonoDePaciente>(d => d.IdnumPac)
                    .HasConstraintName("FK__NúmeroDeT__IDNum__6E01572D");
            });

            modelBuilder.Entity<NúmeroDeTelefonoDeRecepcionistum>(entity =>
            {
                entity.HasKey(e => e.IdnumRecep)
                    .HasName("PK__NúmeroDe__64305DC24E30AFCF");

                entity.Property(e => e.IdnumRecep)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNumRecep");

                entity.Property(e => e.NúmeroDeTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumRecepNavigation)
                    .WithOne(p => p.NúmeroDeTelefonoDeRecepcionistum)
                    .HasForeignKey<NúmeroDeTelefonoDeRecepcionistum>(d => d.IdnumRecep)
                    .HasConstraintName("FK__NúmeroDeT__IDNum__5FB337D6");
            });

            modelBuilder.Entity<NúmeroDeTelefonoEnfermero>(entity =>
            {
                entity.HasKey(e => e.IdnumEnf)
                    .HasName("PK__NúmeroDe__8C423383483E8856");

                entity.ToTable("NúmeroDeTelefonoEnfermero");

                entity.Property(e => e.IdnumEnf)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNumEnf");

                entity.Property(e => e.NúmeroDeTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumEnfNavigation)
                    .WithOne(p => p.NúmeroDeTelefonoEnfermero)
                    .HasForeignKey<NúmeroDeTelefonoEnfermero>(d => d.IdnumEnf)
                    .HasConstraintName("FK__NúmeroDeT__IDNum__4D94879B");
            });

            modelBuilder.Entity<NúmeroTelefonoParamedico>(entity =>
            {
                entity.HasKey(e => e.IdnumPara)
                    .HasName("PK__NúmeroTe__7F3F0E547756E300");

                entity.ToTable("NúmeroTelefonoParamedico");

                entity.Property(e => e.IdnumPara)
                    .ValueGeneratedNever()
                    .HasColumnName("IDNumPara");

                entity.Property(e => e.NúmeroDeTelefono)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdnumParaNavigation)
                    .WithOne(p => p.NúmeroTelefonoParamedico)
                    .HasForeignKey<NúmeroTelefonoParamedico>(d => d.IdnumPara)
                    .HasConstraintName("FK__NúmeroTel__IDNum__52593CB8");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.Idpac)
                    .HasName("PK__Paciente__98F9A670F6C82C52");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rut, "UQ__Paciente__CAF036600AADE94F")
                    .IsUnique();

                entity.Property(e => e.Idpac).HasColumnName("IDPac");

                entity.Property(e => e.Calle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HistoriaClínica)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Historia_clínica");

                entity.Property(e => e.Idambul).HasColumnName("IDAmbul");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NúmeroDeCasa).HasColumnName("Número_de_casa");

                entity.Property(e => e.Problema)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SalaId).HasColumnName("SalaID");

                entity.HasOne(d => d.IdambulNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.Idambul)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Paciente__IDAmbu__6B24EA82");

                entity.HasOne(d => d.Sala)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.SalaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Paciente__SalaID__6A30C649");

                entity.HasMany(d => d.Iddoctors)
                    .WithMany(p => p.Idpacientes)
                    .UsingEntity<Dictionary<string, object>>(
                        "DatiendeP",
                        l => l.HasOne<Doctor>().WithMany().HasForeignKey("Iddoctor").HasConstraintName("FK__DAtiendeP__IDDoc__71D1E811"),
                        r => r.HasOne<Paciente>().WithMany().HasForeignKey("Idpaciente").HasConstraintName("FK__DAtiendeP__IDPac__70DDC3D8"),
                        j =>
                        {
                            j.HasKey("Idpaciente", "Iddoctor").HasName("PK__DAtiende__4E906891042A5FAD");

                            j.ToTable("DAtiendeP");

                            j.IndexerProperty<int>("Idpaciente").HasColumnName("IDPaciente");

                            j.IndexerProperty<int>("Iddoctor").HasColumnName("IDDoctor");
                        });

                entity.HasMany(d => d.Idenfermeros)
                    .WithMany(p => p.Idpacients)
                    .UsingEntity<Dictionary<string, object>>(
                        "EatiendeP",
                        l => l.HasOne<Enfermero>().WithMany().HasForeignKey("Idenfermero").HasConstraintName("FK__EAtiendeP__IDEnf__75A278F5"),
                        r => r.HasOne<Paciente>().WithMany().HasForeignKey("Idpacient").HasConstraintName("FK__EAtiendeP__IDPac__74AE54BC"),
                        j =>
                        {
                            j.HasKey("Idpacient", "Idenfermero").HasName("PK__EAtiende__B2F97C0F40F43C3C");

                            j.ToTable("EAtiendeP");

                            j.IndexerProperty<int>("Idpacient").HasColumnName("IDPacient");

                            j.IndexerProperty<int>("Idenfermero").HasColumnName("IDEnfermero");
                        });

                entity.HasMany(d => d.Idparamedicos)
                    .WithMany(p => p.Idpacientes)
                    .UsingEntity<Dictionary<string, object>>(
                        "PatiendeP",
                        l => l.HasOne<Paramedico>().WithMany().HasForeignKey("Idparamedico").HasConstraintName("FK__PAtiendeP__IDPar__7D439ABD"),
                        r => r.HasOne<Paciente>().WithMany().HasForeignKey("Idpaciente").HasConstraintName("FK__PAtiendeP__IDPac__7C4F7684"),
                        j =>
                        {
                            j.HasKey("Idpaciente", "Idparamedico").HasName("PK__PAtiende__20D292773BC3EE02");

                            j.ToTable("PAtiendeP");

                            j.IndexerProperty<int>("Idpaciente").HasColumnName("IDPaciente");

                            j.IndexerProperty<int>("Idparamedico").HasColumnName("IDParamedico");
                        });
            });

            modelBuilder.Entity<Paramedico>(entity =>
            {
                entity.HasKey(e => e.Idpar)
                    .HasName("PK__Paramedi__98F9A64330B511A2");

                entity.ToTable("Paramedico");

                entity.Property(e => e.Idpar).HasColumnName("IDPar");

                entity.Property(e => e.Calle)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Certificación)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioDeAtención)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Horario_de_atención");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NúmeroDeCasa).HasColumnName("Número_de_casa");

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasMany(d => d.Idambuls)
                    .WithMany(p => p.Idparamedicos)
                    .UsingEntity<Dictionary<string, object>>(
                        "Conduce",
                        l => l.HasOne<Ambulancium>().WithMany().HasForeignKey("Idambul").HasConstraintName("FK__Conduce__IDAmbul__66603565"),
                        r => r.HasOne<Paramedico>().WithMany().HasForeignKey("Idparamedico").HasConstraintName("FK__Conduce__IDParam__656C112C"),
                        j =>
                        {
                            j.HasKey("Idparamedico", "Idambul").HasName("PK__Conduce__F90D710CCA81BC2B");

                            j.ToTable("Conduce");

                            j.IndexerProperty<int>("Idparamedico").HasColumnName("IDParamedico");

                            j.IndexerProperty<int>("Idambul").HasColumnName("IDAmbul");
                        });
            });

            modelBuilder.Entity<Recepcionistum>(entity =>
            {
                entity.HasKey(e => e.Idrecep)
                    .HasName("PK__Recepcio__083226BDFBF65020");

                entity.HasIndex(e => e.Rut, "UQ__Recepcio__CAF0366042E580CF")
                    .IsUnique();

                entity.Property(e => e.Idrecep).HasColumnName("IDRecep");

                entity.Property(e => e.DepartamentoMédico)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Departamento_médico");

                entity.Property(e => e.Horario)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Primer_apellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Primer_nombre");

                entity.Property(e => e.Rut)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Segundo_apellido");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(e => e.Idsala)
                    .HasName("PK__Sala__C6F3BA0F5BB7B1B5");

                entity.ToTable("Sala");

                entity.HasIndex(e => e.Código, "UQ__Sala__D68C8CB051C52F91")
                    .IsUnique();

                entity.Property(e => e.Idsala).HasColumnName("IDSala");

                entity.Property(e => e.CapacidadDePacientes).HasColumnName("Capacidad_de_pacientes");

                entity.Property(e => e.Código)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Diagnóstico)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.HoraDeEntrada).HasColumnName("Hora_de_entrada");

                entity.Property(e => e.HoraDeSalida).HasColumnName("Hora_de_salida");

                entity.Property(e => e.NombreDePaciente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_de_paciente");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tratamiento)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
