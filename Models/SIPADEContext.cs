using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SIPADE.Models
{
    public partial class SIPADEContext : DbContext
    {
        public SIPADEContext()
        {
        }

        public SIPADEContext(DbContextOptions<SIPADEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SipTblControlAsistencia> SipTblControlAsistencia { get; set; }
        public virtual DbSet<SipTblDetallePlanilla> SipTblDetallePlanilla { get; set; }
        public virtual DbSet<SipTblEmpleado> SipTblEmpleado { get; set; }
        public virtual DbSet<SipTblEncabezadoPlanilla> SipTblEncabezadoPlanilla { get; set; }
        public virtual DbSet<SipTblTipoActividad> SipTblTipoActividad { get; set; }
        public virtual DbSet<SipTblTrabajoRealizado> SipTblTrabajoRealizado { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ST2ET60;Database=SIPADE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SipTblControlAsistencia>(entity =>
            {
                entity.HasKey(e => e.SipTblCasId);

                entity.ToTable("SIP_TBL_CONTROL_ASISTENCIA");

                entity.Property(e => e.SipTblCasId)
                    .HasColumnName("SIP_TBL_CAS_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblCasFechaHoraEntrada)
                    .HasColumnName("SIP_TBL_CAS_FECHA_HORA_ENTRADA")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipTblCasFechaHoraSalida)
                    .HasColumnName("SIP_TBL_CAS_FECHA_HORA_SALIDA")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipTblEmpId).HasColumnName("SIP_TBL_EMP_ID");

                entity.HasOne(d => d.SipTblEmp)
                    .WithMany(p => p.SipTblControlAsistencia)
                    .HasForeignKey(d => d.SipTblEmpId)
                    .HasConstraintName("FK_SIP_TBL_CONTROL_ASISTENCIA_SIP_TBL_EMPLEADO");
            });

            modelBuilder.Entity<SipTblDetallePlanilla>(entity =>
            {
                entity.HasKey(e => e.SipTblDplId);

                entity.ToTable("SIP_TBL_DETALLE_PLANILLA");

                entity.Property(e => e.SipTblDplId)
                    .HasColumnName("SIP_TBL_DPL_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblDedDeducciones).HasColumnName("SIP_TBL_DED_DEDUCCIONES");

                entity.Property(e => e.SipTblDplBonificacion).HasColumnName("SIP_TBL_DPL_BONIFICACION");

                entity.Property(e => e.SipTblDplIgss).HasColumnName("SIP_TBL_DPL_IGSS");

                entity.Property(e => e.SipTblDplIrtra).HasColumnName("SIP_TBL_DPL_IRTRA");

                entity.Property(e => e.SipTblDplIsr).HasColumnName("SIP_TBL_DPL_ISR");

                entity.Property(e => e.SipTblDplOtros).HasColumnName("SIP_TBL_DPL_OTROS");

                entity.Property(e => e.SipTblEplId).HasColumnName("SIP_TBL_EPL_ID");

                entity.Property(e => e.SipTblTreId).HasColumnName("SIP_TBL_TRE_ID");

                entity.HasOne(d => d.SipTblEpl)
                    .WithMany(p => p.SipTblDetallePlanilla)
                    .HasForeignKey(d => d.SipTblEplId)
                    .HasConstraintName("FK_SIP_TBL_DETALLE_PLANILLA_SIP_TBL_ENCABEZADO_PLANILLA");

                entity.HasOne(d => d.SipTblTre)
                    .WithMany(p => p.SipTblDetallePlanilla)
                    .HasForeignKey(d => d.SipTblTreId)
                    .HasConstraintName("FK_SIP_TBL_DETALLE_PLANILLA_SIP_TBL_TRABAJO_REALIZADO");
            });

            modelBuilder.Entity<SipTblEmpleado>(entity =>
            {
                entity.HasKey(e => e.SipTblEmpId);

                entity.ToTable("SIP_TBL_EMPLEADO");

                entity.Property(e => e.SipTblEmpId)
                    .HasColumnName("SIP_TBL_EMP_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblEmpApellidos)
                    .HasColumnName("SIP_TBL_EMP_APELLIDOS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpDireccion)
                    .HasColumnName("SIP_TBL_EMP_DIRECCION")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpDpi)
                    .HasColumnName("SIP_TBL_EMP_DPI")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpNit)
                    .HasColumnName("SIP_TBL_EMP_NIT")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpNombres)
                    .HasColumnName("SIP_TBL_EMP_NOMBRES")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpNumigss)
                    .HasColumnName("SIP_TBL_EMP_NUMIGSS")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpNumirtra)
                    .HasColumnName("SIP_TBL_EMP_NUMIRTRA")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SipTblEmpTel)
                    .HasColumnName("SIP_TBL_EMP_TEL")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SipTblEncabezadoPlanilla>(entity =>
            {
                entity.HasKey(e => e.SipTblEplId);

                entity.ToTable("SIP_TBL_ENCABEZADO_PLANILLA");

                entity.Property(e => e.SipTblEplId)
                    .HasColumnName("SIP_TBL_EPL_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblEplFechafin)
                    .HasColumnName("SIP_TBL_EPL_FECHAFIN")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipTblEplFechahora)
                    .HasColumnName("SIP_TBL_EPL_FECHAHORA")
                    .HasColumnType("datetime");

                entity.Property(e => e.SipTblEplFechainicio)
                    .HasColumnName("SIP_TBL_EPL_FECHAINICIO")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SipTblTipoActividad>(entity =>
            {
                entity.HasKey(e => e.SipTblActId);

                entity.ToTable("SIP_TBL_TIPO_ACTIVIDAD");

                entity.Property(e => e.SipTblActId)
                    .HasColumnName("SIP_TBL_ACT_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblActCostoact).HasColumnName("SIP_TBL_ACT_COSTOACT");

                entity.Property(e => e.SipTblActNombre)
                    .HasColumnName("SIP_TBL_ACT_NOMBRE")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SipTblTrabajoRealizado>(entity =>
            {
                entity.HasKey(e => e.SipTblTreId);

                entity.ToTable("SIP_TBL_TRABAJO_REALIZADO");

                entity.Property(e => e.SipTblTreId)
                    .HasColumnName("SIP_TBL_TRE_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SipTblActId).HasColumnName("SIP_TBL_ACT_ID");

                entity.Property(e => e.SipTblEmpId).HasColumnName("SIP_TBL_EMP_ID");

                entity.Property(e => e.SipTblTreCantidad).HasColumnName("SIP_TBL_TRE_CANTIDAD");

                entity.Property(e => e.SipTblTreTotal).HasColumnName("SIP_TBL_TRE_TOTAL");

                entity.HasOne(d => d.SipTblAct)
                    .WithMany(p => p.SipTblTrabajoRealizado)
                    .HasForeignKey(d => d.SipTblActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIP_TBL_TRABAJO_REALIZADO_SIP_TBL_TIPO_ACTIVIDAD");

                entity.HasOne(d => d.SipTblEmp)
                    .WithMany(p => p.SipTblTrabajoRealizado)
                    .HasForeignKey(d => d.SipTblEmpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SIP_TBL_TRABAJO_REALIZADO_SIP_TBL_EMPLEADO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
