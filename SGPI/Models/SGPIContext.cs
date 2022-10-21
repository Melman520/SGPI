using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class SGPIContext : DbContext
    {
        public SGPIContext()
        {
        }

        public SGPIContext(DbContextOptions<SGPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAsignatura> TblAsignaturas { get; set; } = null!;
        public virtual DbSet<TblDocumento> TblDocumentos { get; set; } = null!;
        public virtual DbSet<TblEntrevistum> TblEntrevista { get; set; } = null!;
        public virtual DbSet<TblEstudiante> TblEstudiantes { get; set; } = null!;
        public virtual DbSet<TblGenero> TblGeneros { get; set; } = null!;
        public virtual DbSet<TblHomologacion> TblHomologacions { get; set; } = null!;
        public virtual DbSet<TblPago> TblPagos { get; set; } = null!;
        public virtual DbSet<TblPrograma> TblProgramas { get; set; } = null!;
        public virtual DbSet<TblProgramacion> TblProgramacions { get; set; } = null!;
        public virtual DbSet<TblRol> TblRols { get; set; } = null!;
        public virtual DbSet<TblTipoHomologacion> TblTipoHomologacions { get; set; } = null!;
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=SGPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAsignatura>(entity =>
            {
                entity.HasKey(e => e.Idasignatura)
                    .HasName("PK__tblAsign__2E8CCF35E495C01F");

                entity.ToTable("tblAsignatura");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblAsignaturas)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK__tblAsigna__IDPro__3D5E1FD2");
            });

            modelBuilder.Entity<TblDocumento>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("PK__tblDocum__93E3A42C2CF641CA");

                entity.ToTable("tblDocumento");

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblEntrevistum>(entity =>
            {
                entity.HasKey(e => e.Identrevista)
                    .HasName("PK__tblEntre__05824BE9C6199579");

                entity.ToTable("tblEntrevista");

                entity.Property(e => e.Identrevista).HasColumnName("IDEntrevista");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.TblEntrevista)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK__tblEntrev__IDEst__38996AB5");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblEntrevista)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__tblEntrev__IDUsu__37A5467C");
            });

            modelBuilder.Entity<TblEstudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("PK__tblEstud__908672BB966D1CE5");

                entity.ToTable("tblEstudiante");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdpagoNavigation)
                    .WithMany(p => p.TblEstudiantes)
                    .HasForeignKey(d => d.Idpago)
                    .HasConstraintName("FK__tblEstudi__IDPag__34C8D9D1");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblEstudiantes)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__tblEstudi__IDUsu__33D4B598");
            });

            modelBuilder.Entity<TblGenero>(entity =>
            {
                entity.HasKey(e => e.Idgenero)
                    .HasName("PK__tblGener__40E9040F13B704F4");

                entity.ToTable("tblGenero");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Genero)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHomologacion>(entity =>
            {
                entity.HasKey(e => e.Idhomologacion)
                    .HasName("PK__tblHomol__01DC9432C53DC7C0");

                entity.ToTable("tblHomologacion");

                entity.Property(e => e.Idhomologacion).HasColumnName("IDHomologacion");

                entity.Property(e => e.CodigoHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.IdtipoHomologacion).HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.NomAsigHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nota).HasColumnName("nota");

                entity.Property(e => e.PerdiodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .HasConstraintName("FK__tblHomolo__IDAsi__47DBAE45");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK__tblHomolog__nota__44FF419A");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK__tblHomolo__IDPro__45F365D3");

                entity.HasOne(d => d.IdtipoHomologacionNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.IdtipoHomologacion)
                    .HasConstraintName("FK__tblHomolo__IDTip__46E78A0C");
            });

            modelBuilder.Entity<TblPago>(entity =>
            {
                entity.HasKey(e => e.Idpago)
                    .HasName("PK__tblPagos__8A5C3DEE73959E32");

                entity.ToTable("tblPagos");

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<TblPrograma>(entity =>
            {
                entity.HasKey(e => e.Idprograma)
                    .HasName("PK__tblProgr__072DB426CE9211DE");

                entity.ToTable("tblPrograma");

                entity.Property(e => e.Idprograma)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPrograma");

                entity.Property(e => e.Programa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProgramacion>(entity =>
            {
                entity.HasKey(e => e.Idprogramacion)
                    .HasName("PK__tblProgr__E8038DE4FECD0465");

                entity.ToTable("tblProgramacion");

                entity.Property(e => e.Idprogramacion).HasColumnName("IDProgramacion");

                entity.Property(e => e.FechaProgramacion).HasColumnType("datetime");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("sala");

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .HasConstraintName("FK__tblProgra__IDAsi__412EB0B6");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK__tblProgra__IDPro__403A8C7D");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK__tblProgra__IDUsu__4222D4EF");
            });

            modelBuilder.Entity<TblRol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__tblRol__A681ACB691DC3724");

                entity.ToTable("tblRol");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoHomologacion>(entity =>
            {
                entity.HasKey(e => e.IdtipoHomologacion)
                    .HasName("PK__tblTipoH__ECF4DCC339D53182");

                entity.ToTable("tblTipoHomologacion");

                entity.Property(e => e.IdtipoHomologacion).HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.TipoHomologacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__tblUsuar__523111698C20830E");

                entity.ToTable("tblUsuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Clave)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("numeroDocumento");

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primerApellido");

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("primerNombre");

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("segundoApellido");

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("segundoNombre");

                entity.HasOne(d => d.IddocNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Iddoc)
                    .HasConstraintName("FK__tblUsuari__IDDoc__2F10007B");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idgenero)
                    .HasConstraintName("FK__tblUsuari__IDGen__2C3393D0");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK__tblUsuari__IDPro__2E1BDC42");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idrol)
                    .HasConstraintName("FK__tblUsuari__IDRol__2D27B809");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
