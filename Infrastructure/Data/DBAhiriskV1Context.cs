using ApplicationCore.Entities.Ahirisk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DBAhiriskV1Context : DbContext
    {
        public DBAhiriskV1Context() { }

        public DBAhiriskV1Context(DbContextOptions<DBAhiriskV1Context> options) : base(options) { }

        //----
        public virtual DbSet<tblUsuarios> tblUsuarios { get; set; }
        public virtual DbSet<tblEntidadPerfiles> tblEntidadPerfiles { get; set; }
        public virtual DbSet<tblMenu> tblMenu { get; set; }
        public virtual DbSet<tblMenuPerfiles> tblMenuPerfiles { get; set; }
        public virtual DbSet<tblPerfiles> tblPerfiles { get; set; }
        public virtual DbSet<tblEntidad> tblEntidad { get; set; }
        public virtual DbSet<tblMultivalores> tblMultivalores { get; set; }
        public virtual DbSet<tblMultivaloresIdiomas> tblMultivaloresIdiomas { get; set; }
        public virtual DbSet<tblIdiomas> tblIdiomas { get; set; }
        public virtual DbSet<tblEntidadUsuario> tblEntidadUsuario { get; set; }
        public virtual DbSet<tblUsuariosPerfiles> tblUsuariosPerfiles { get; set; }
        public virtual DbSet<tblEntidadParametros> tblEntidadParametros { get; set; }
        public virtual DbSet<tblParametros> tblParametros { get; set; }
        public virtual DbSet<tblParametrosIdiomas> tblParametrosIdiomas { get; set; }
        public virtual DbSet<tblEntidadPasswordSettings> tblEntidadPasswordSettings { get; set; }
        public virtual DbSet<tblPasswordSettings> tblPasswordSettings { get; set; }
        public virtual DbSet<tblPasswordSettingsIdiomas> tblPasswordSettingsIdiomas { get; set; }
        public virtual DbSet<tblEmailNotificaciones> tblEmailNotificaciones { get; set; }
        public virtual DbSet<tblProcesos> tblProcesos {  get; set; }
        public virtual DbSet<tblProcesosPaisIdioma> tblProcesosPaisIdioma { get; set; }
        public virtual DbSet<tblTipoProcesos> tblTipoProcesos { get; set; }
        public virtual DbSet<tblTipoProcesosPaisIdioma> tblTipoProcesosPaisIdioma { get; set; }
        public virtual DbSet<tblProductos> tblProductos { get; set; }
        public virtual DbSet<tblPaises> tblPaises { get; set; }
        public virtual DbSet<tblOrganismosControl> tblOrganismosControl { get; set; }
        public virtual DbSet<tblMetodologiaRiesgo> tblMetodologiaRiesgo { get; set; }
        public virtual DbSet<tblMetodologiaRiesgoPaisIdioma> tblMetodologiaRiesgoPaisIdioma { get; set; }
        public virtual DbSet<tblFactoresRiesgo> tblFactoresRiesgo { get; set; }
        public virtual DbSet<tblFactoresRiesgoPaisIdioma> tblFactoresRiesgoPaisIdioma { get; set; }
        public virtual DbSet<tblEntidadOrganismosControl> tblEntidadOrganismosControl { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6 - servicing - 10079");

            modelBuilder.Entity<tblEntidad>(entity =>
            {
                entity.ToTable("tblEntidad", "administrativo");

                entity.HasKey(e => e.iIDEntidad);

                entity.Property(e => e.tNumeroIdentificacion).HasMaxLength(200);

                entity.Property(e => e.tDigitoVerificacion).HasMaxLength(200);

                entity.Property(e => e.tPrimerNombre).HasMaxLength(200);

                entity.Property(e => e.tSegundoNombre).HasMaxLength(200);

                entity.Property(e => e.tPrimerApellido).HasMaxLength(200);

                entity.Property(e => e.tSegundoApellido).HasMaxLength(200);

                entity.Property(e => e.tRazonSocial).HasMaxLength(200);

                entity.Property(e => e.tNombreEntidad).HasMaxLength(200);

                entity.Property(e => e.tLogo).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                   .WithMany(p => p.tblEntidadiIDUsarioCreacionNavigation)
                   .HasForeignKey(d => d.iIDUsuarioCreacion)
                   .HasConstraintName("FK_tblEntidad_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                 .WithMany(p => p.tblEntidadiIDUsarioModificacionNavigation)
                 .HasForeignKey(d => d.iIDUsuarioModificacion)
                 .HasConstraintName("FK_tblEntidad_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                .WithMany(p => p.tblEntidadiIDUsarioInactivacionNavigation)
                .HasForeignKey(d => d.iIDUsuarioInactivacion)
                .HasConstraintName("FK_tblEntidad_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblMultivaloresTipoDocNavigation)
                   .WithMany(p => p.tblEntidadTipoDocNavigation)
                   .HasForeignKey(d => new { d.iIDSubTablaTipoDoc, d.tIDValorTipoDoc })
                   .HasConstraintName("FK_tblEntidad_tblMultivalores_TipoDoc");

                entity.HasOne(d => d.tblMultivaloresRegimenNavigation)
                  .WithMany(p => p.tblEntidadRegimenNavigation)
                  .HasForeignKey(d => new { d.iIDSubTablaRegimen, d.tIDValorRegimen })
                  .HasConstraintName("FK_tblEntidad_tblMultivalores_Regimen");

            });

            modelBuilder.Entity<tblUsuarios>(entity =>
            {
                entity.ToTable("tblUsuarios", "seguridad");

                entity.HasKey(e => e.iIDUsuario);

                entity.Property(e => e.tPrimerNombre).HasMaxLength(200);

                entity.Property(e => e.tSegundoNombre).HasMaxLength(200);

                entity.Property(e => e.tPrimerApellido).HasMaxLength(200);

                entity.Property(e => e.tSegundoApellido).HasMaxLength(200);

                entity.Property(e => e.tUsuario).HasMaxLength(200);

                entity.Property(e => e.tNumDoc).HasMaxLength(200);

                entity.Property(e => e.tEmail).HasMaxLength(200);

                entity.Property(e => e.tPassword).HasMaxLength(200);

                entity.Property(e => e.tConfirmarEmail).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.Property(e => e.bHabilitado).HasColumnType("bool");

                entity.HasOne(d => d.tblMultivaloresTipoDocNavigation)
                  .WithMany(p => p.tblUsuariosTipoDocNavigation)
                  .HasForeignKey(d => new { d.iIDSubTablaTipoDoc, d.tIDValorTipoDoc })
                  .HasConstraintName("FK_tblUsuarios_tblMultivalores_TipoDoc");

            });

            modelBuilder.Entity<tblEntidadPerfiles>(entity =>
            {
                entity.ToTable("tblEntidadPerfiles", "seguridad");

                entity.HasKey(e => e.iIDEntidadPerfil);

                entity.Property(e => e.bHeredaPerfil).HasColumnType("bool");

                entity.Property(e => e.tDescripcion).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                   .WithMany(p => p.tblEntidadPerfilesiIDUsarioCreacionNavigation)
                   .HasForeignKey(d => d.iIDUsuarioCreacion)
                   .HasConstraintName("FK_tblEntidadPerfiles_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                 .WithMany(p => p.tblEntidadPerfilesiIDUsarioModificacionNavigation)
                 .HasForeignKey(d => d.iIDUsuarioModificacion)
                 .HasConstraintName("FK_tblEntidadPerfiles_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                .WithMany(p => p.tblEntidadPerfilesiIDUsarioInactivacionNavigation)
                .HasForeignKey(d => d.iIDUsuarioInactivacion)
                .HasConstraintName("FK_tblEntidadPerfiles_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblEntidadNavigation)
                .WithMany(p => p.tblEntidadPerfilesNavigation)
                .HasForeignKey(d => d.iIDEntidad)
                .HasConstraintName("FK_tblEntidadPerfiles_tblEntidad");

                entity.HasOne(d => d.tblPerfilesNavigation)
               .WithMany(p => p.tblEntidadPerfilesNavigation)
               .HasForeignKey(d => d.iIDPerfil)
               .HasConstraintName("FK_tblEntidadPerfiles_tblPerfil");

            });

            modelBuilder.Entity<tblMenu>(entity =>
            {
                entity.ToTable("tblMenu", "seguridad");

                entity.HasKey(e => e.iIDMenu);

                entity.Property(e => e.tDescripcion).HasMaxLength(200);

                entity.Property(e => e.iIDPadre).HasColumnType("int");

                entity.Property(e => e.iPosicionPadre).HasColumnType("int");

                entity.Property(e => e.iPosicion).HasColumnType("int");

                entity.Property(e => e.tUrl).HasMaxLength(200);

                entity.Property(e => e.tIcono).HasMaxLength(200);

                entity.Property(e => e.tDefinicion).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bVisible).HasColumnType("bool");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuariosCreacionNavigation)
                      .WithMany(p => p.tblMenuiIDUsarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblMenu_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuariosModificacionNavigation)
                    .WithMany(p => p.tblMenuiIDUsarioModificacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioModificacion)
                    .HasConstraintName("FK_tblMenu_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuariosInactivacionNavigation)
                    .WithMany(p => p.tblMenuiIDUsarioInactivacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioInactivacion)
                    .HasConstraintName("FK_tblMenu_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.iIDPadreNavigation)
                    .WithMany(p => p.InverseiIDPadreNavigation)
                    .HasForeignKey(d => d.iIDPadre)
                    .HasConstraintName("FK_tblMenu_tblMenu");
            });

            modelBuilder.Entity<tblPerfiles>(entity =>
            {
                entity.ToTable("tblPerfiles", "seguridad");

                entity.HasKey(e => e.iIDPerfil);

                entity.Property(e => e.tDescripcion).HasMaxLength(200);

                entity.Property(e => e.tDefinicion).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuariosCreacionNavigation)
                      .WithMany(p => p.tblPerfilesiIDUsarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblPerfiles_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuariosModificacionNavigation)
                    .WithMany(p => p.tblPerfilesiIDUsarioModificacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioModificacion)
                    .HasConstraintName("FK_tblPerfiles_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuariosInactivacionNavigation)
                    .WithMany(p => p.tblPerfilesiIDUsarioInactivacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioInactivacion)
                    .HasConstraintName("FK_tblPerfiles_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblMenuPerfiles>(entity =>
            {
                entity.ToTable("tblMenuPerfiles", "seguridad");

                entity.HasKey(e => e.iIDMenuPerfil);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuariosCreacionNavigation)
                      .WithMany(p => p.tblMenuPerfilesiIDUsarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblMenuPerfiles_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuariosModificacionNavigation)
                    .WithMany(p => p.tblMenuPerfilesiIDUsarioModificacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioModificacion)
                    .HasConstraintName("FK_tblMenuPerfiles_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuariosInactivacionNavigation)
                    .WithMany(p => p.tblMenuPerfilesiIDUsarioInactivacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioInactivacion)
                    .HasConstraintName("FK_tblMenuPerfiles_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblPerfilesNavigation)
                    .WithMany(p => p.tblMenuPerfilesNavigation)
                    .HasForeignKey(d => d.iIDPerfil)
                    .HasConstraintName("FK_tblMenuPerfiles_tblPerfiles");

                entity.HasOne(d => d.tblMenuNavigation)
                   .WithMany(p => p.tblMenuPerfilesNavigation)
                   .HasForeignKey(d => d.iIDMenu)
                   .HasConstraintName("FK_tblMenuPerfiles_tblMenu");

            });

            modelBuilder.Entity<tblMultivalores>(entity =>
            {
                entity.HasKey(e => new { e.iIDSubTabla, e.tIDValor });

                entity.ToTable("tblMultivalores", "administrativo");

                entity.Property(e => e.tSubTabla).HasMaxLength(100);

                entity.Property(e => e.iOrden).HasColumnType("int");

                entity.Property(e => e.tComentario).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuariosCreacionNavigation)
                     .WithMany(p => p.tblMultivaloresiIDUsarioCreacionNavigation)
                     .HasForeignKey(d => d.iIDUsuarioCreacion)
                     .HasConstraintName("FK_tblMultivalores_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuariosModificacionNavigation)
                    .WithMany(p => p.tblMultivaloresiIDUsarioModificacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioModificacion)
                    .HasConstraintName("FK_tblMultivalores_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuariosInactivacionNavigation)
                    .WithMany(p => p.tblMultivaloresiIDUsarioInactivacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioInactivacion)
                    .HasConstraintName("FK_tblMultivalores_tblUsuarios_Inactivacion");

            });

            modelBuilder.Entity<tblMultivaloresIdiomas>(entity =>
            {
                entity.HasKey(e => e.iIDMultivaloresIdioma);

                entity.ToTable("tblMultivaloresIdiomas", "administrativo");

                entity.Property(e => e.tDescripcionValor).HasMaxLength(100);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuariosCreacionNavigation)
                     .WithMany(p => p.tblMultivaloresIdiomasiIDUsarioCreacionNavigation)
                     .HasForeignKey(d => d.iIDUsuarioCreacion)
                     .HasConstraintName("FK_tblMultivaloresIdiomas_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuariosModificacionNavigation)
                    .WithMany(p => p.tblMultivaloresIdiomasiIDUsarioModificacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioModificacion)
                    .HasConstraintName("FK_tblMultivaloresIdiomas_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuariosInactivacionNavigation)
                    .WithMany(p => p.tblMultivaloresIdiomasiIDUsarioInactivacionNavigation)
                    .HasForeignKey(d => d.iIDUsuarioInactivacion)
                    .HasConstraintName("FK_tblMultivaloresIdiomas_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblMultivaloresNavigation)
                    .WithMany(p => p.tblMultivaloresIdiomasNavigation)
                    .HasForeignKey(d => new { d.iIDSubTabla, d.tIDValor })
                    .HasConstraintName("FK_tblMultivaloresIdiomas_tblMultivalores");

            });
            
            modelBuilder.Entity<tblIdiomas>(entity =>
            {
                entity.ToTable("tblIdiomas", "administrativo");

                entity.HasKey(e => e.iIDIdioma);

                entity.Property(e => e.tCodigo).HasMaxLength(200);

                entity.Property(e => e.tCodigoPais).HasMaxLength(200);

                entity.Property(e => e.tNombre).HasMaxLength(200);

                entity.Property(e => e.tPais).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                   .WithMany(p => p.tblIdiomasiIDUsarioCreacionNavigation)
                   .HasForeignKey(d => d.iIDUsuarioCreacion)
                   .HasConstraintName("FK_tblIdiomas_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                 .WithMany(p => p.tblIdiomasiIDUsarioModificacionNavigation)
                 .HasForeignKey(d => d.iIDUsuarioModificacion)
                 .HasConstraintName("FK_tblIdiomas_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                .WithMany(p => p.tblIdiomasiIDUsarioInactivacionNavigation)
                .HasForeignKey(d => d.iIDUsuarioInactivacion)
                .HasConstraintName("FK_tblIdiomas_tblUsuarios_Inactivacion");
            

            });
            
            modelBuilder.Entity<tblEntidadUsuario>(entity =>
            {
                entity.ToTable("tblEntidadUsuario", "seguridad");

                entity.HasKey(e => e.iIDEntidadUsuario);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                   .WithMany(p => p.tblEntidadUsuarioiIDUsarioCreacionNavigation)
                   .HasForeignKey(d => d.iIDUsuarioCreacion)
                   .HasConstraintName("FK_tblEntidadUsuario_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                 .WithMany(p => p.tblEntidadUsuarioiIDUsarioModificacionNavigation)
                 .HasForeignKey(d => d.iIDUsuarioModificacion)
                 .HasConstraintName("FK_tblEntidadUsuario_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                .WithMany(p => p.tblEntidadUsuarioiIDUsarioInactivacionNavigation)
                .HasForeignKey(d => d.iIDUsuarioInactivacion)
                .HasConstraintName("FK_tblEntidadUsuario_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblUsuarioUsuarioNavigation)
                  .WithMany(p => p.tblEntidadUsuarioiIDUsarioUsuarioNavigation)
                  .HasForeignKey(d => d.iIDUsuario)
                  .HasConstraintName("FK_tblEntidadUsuario_tblUsuarios_Usuario");

                entity.HasOne(d => d.tblEntidadNavigation)
                .WithMany(p => p.tblEntidadUsuarioNavigation)
                .HasForeignKey(d => d.iIDEntidad)
                .HasConstraintName("FK_tblEntidadUsuario_tblEntidad");

            

            });

            modelBuilder.Entity<tblUsuariosPerfiles>(entity =>
            {
                entity.ToTable("tblUsuariosPerfiles", "seguridad");

                entity.HasKey(e => e.iIDUsuarioPerfil);               

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                   .WithMany(p => p.tblUsuariosPerfilesiIDUsarioCreacionNavigation)
                   .HasForeignKey(d => d.iIDUsuarioCreacion)
                   .HasConstraintName("FK_tblUsuariosPerfiles_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                 .WithMany(p => p.tblUsuariosPerfilesiIDUsarioModificacionNavigation)
                 .HasForeignKey(d => d.iIDUsuarioModificacion)
                 .HasConstraintName("FK_tblUsuariosPerfiles_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                .WithMany(p => p.tblUsuariosPerfilesiIDUsarioInactivacionNavigation)
                .HasForeignKey(d => d.iIDUsuarioInactivacion)
                .HasConstraintName("FK_tblUsuariosPerfiles_tblUsuarios_Inactivacion");

                entity.HasOne(d => d.tblUsuarioUsuarioNavigation)
                .WithMany(p => p.tblUsuariosPerfilesiIDUsarioUsuarioNavigation)
                .HasForeignKey(d => d.iIDUsuario)
                .HasConstraintName("FK_tblUsuariosPerfiles_tblUsuarios_Usuario");

                entity.HasOne(d => d.tblPerfilesPerfilNavigation)
               .WithMany(p => p.tblUsuariosPerfilesNavigation)
               .HasForeignKey(d => d.iIDPerfil)
               .HasConstraintName("FK_tblUsuariosPerfiles_tblPerfil");

            });

            modelBuilder.Entity<tblEntidadParametros>(entity =>
            {
                entity.ToTable("tblEntidadParametros", "administrativo");

                entity.HasKey(e => e.iIDEntidadParametro);

                entity.Property(e => e.iTipoParametro).HasColumnType("int");

                entity.Property(e => e.tCodigo).HasColumnType("text");

                entity.Property(e => e.tDescripcion).HasColumnType("text");

                entity.Property(e => e.dValor).HasColumnType("numeric");

                entity.Property(e => e.dtValor).HasColumnType("date");

                entity.Property(e => e.bValor).HasColumnType("bool");

                entity.Property(e => e.tValor).HasColumnType("text");

                entity.Property(e => e.iValor).HasColumnType("int");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblEntidadNavigation)
                      .WithMany(p => p.tblEntidadParametrosNavigation)
                      .HasForeignKey(d => d.iIDEntidad)
                      .HasConstraintName("FK_tblEntidadParametros_tblEntidad");

                entity.HasOne(d => d.tblParametrosNavigation)
                      .WithMany(p => p.tblEntidadParametrosNavigation)
                      .HasForeignKey(d => d.iIDParametro)
                      .HasConstraintName("FK_tblEntidadParametros_tblParametros");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblEntidadParametrosUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblEntidadParametrosUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblEntidadParametrosUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblParametros>(entity =>
            {
                entity.ToTable("tblParametros", "administrativo");

                entity.HasKey(e => e.iIDParametro);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblParametrosUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblParametros_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblParametrosUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblParametros_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblParametrosUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblParametros_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblParametrosIdiomas>(entity =>
            {
                entity.ToTable("tblParametrosIdiomas", "administrativo");

                entity.HasKey(e => e.iIDParametrosIdiomas);

                entity.Property(e => e.tParametroNombre).HasColumnType("text");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblIdiomasNavigation)
                      .WithMany(p => p.tblParametrosIdiomasNavigation)
                      .HasForeignKey(d => d.iIDIdioma)
                      .HasConstraintName("FK_tblParametrosIdiomas_tblIdiomas");

                entity.HasOne(d => d.tblParametrosNavigation)
                      .WithMany(p => p.tblParametrosIdiomasNavigation)
                      .HasForeignKey(d => d.iIDParametro)
                      .HasConstraintName("FK_tblParametrosIdiomas_tblParametros");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblParametrosIdiomasUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblParametrosIdiomas_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblParametrosIdiomasUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblParametrosIdiomas_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblParametrosIdiomasUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_ParametrosIdiomas_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblEntidadPasswordSettings>(entity =>
            {
                entity.ToTable("tblEntidadPasswordSettings", "seguridad");

                entity.HasKey(e => e.iIDEntidadPasswordSetting);

                entity.Property(e => e.iValorMinimo).HasColumnType("int");

                entity.Property(e => e.iValorMaximo).HasColumnType("int");

                entity.Property(e => e.bRequerido).HasColumnType("bool");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblEntidadNavigation)
                      .WithMany(p => p.tblEntidadPasswordSettingsNavigation)
                      .HasForeignKey(d => d.iIDEntidad)
                      .HasConstraintName("FK_tblEntidadPasswordSettings_tblEntidad");

                entity.HasOne(d => d.tblPasswordSettingsNavigation)
                      .WithMany(p => p.tblEntidadPasswordSettingsNavigation)
                      .HasForeignKey(d => d.iIDPasswordSetting)
                      .HasConstraintName("FK_tblEntidadPasswordSettings_tblPasswordSettings");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblEntidadPasswordSettingsUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblEntidadPasswordSettings_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblEntidadPasswordSettingsUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblEntidadPasswordSettings_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblEntidadPasswordSettingsUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblEntidadPasswordSettings_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblPasswordSettings>(entity =>
            {
                entity.ToTable("tblPasswordSettings", "seguridad");

                entity.HasKey(e => e.iIDPasswordSetting);

                entity.Property(e => e.tExpresionRegular).HasColumnType("text");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblPasswordSettings_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblPasswordSettings_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblPasswordSettings_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblPasswordSettingsIdiomas>(entity =>
            {
                entity.ToTable("tblPasswordSettingsIdiomas", "seguridad");

                entity.HasKey(e => e.iIDPasswordSettingIdioma);

                entity.Property(e => e.tSettingDescripcion).HasColumnType("text");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblPasswordSettingsNavigation)
                      .WithMany(p => p.tblPasswordSettingsIdiomasNavigation)
                      .HasForeignKey(d => d.iIDPasswordSetting)
                      .HasConstraintName("FK_tblPasswordSettingsIdiomas_tblPasswordSettings");

                entity.HasOne(d => d.tblIdiomasNavigation)
                      .WithMany(p => p.tblPasswordSettingsIdiomasNavigation)
                      .HasForeignKey(d => d.iIDIdioma)
                      .HasConstraintName("FK_tblPasswordSettingsIdiomas_tblIdiomas");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsIdiomasUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblPasswordSettingsIdiomas_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsIdiomasUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblPasswordSettingsIdiomas_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblPasswordSettingsIdiomasUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblPasswordSettingsIdiomas_tblUsuarios_Inactivacion");
            });
            
            modelBuilder.Entity<tblEmailNotificaciones>(entity =>
            {
                entity.ToTable("tblEmailNotificaciones", "administrativo");

                entity.HasKey(e => e.iIDEmailNotificacion);

                entity.Property(e => e.tEmail).HasColumnType("text");

                entity.Property(e => e.tContrasena).HasColumnType("text");

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");
               

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblEmailNotificacionesUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblEmailNotificacionesUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblEmailNotificacionesUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblEntidadParametros_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblProcesos>(entity =>
            {
                entity.ToTable("tblProcesos", "administrativo");

                entity.HasKey(e => e.iIDProceso);

                //entity.Property(e => e.iIDTipoProceso).HasColumnType("int");

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblTipoProcesosPaisIdiomaNavigation)
                      .WithMany(p => p.tblProcesosNavigation)
                      .HasForeignKey(d => d.iIDTipoProceso)
                      .HasConstraintName("FK_tblProcesos_tblTipoProcesosPaisIdioma");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblProcesosUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblProcesos_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblProcesosUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblProcesos_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblProcesosUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblProcesos_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblProcesosPaisIdioma>(entity =>
            {
                entity.ToTable("tblProcesosPaisIdioma", "administrativo");

                entity.HasKey(e => e.iIDProcesoPaisIdioma);

                //entity.Property(e => e.iIDProceso).HasColumnType("int");

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.iIDIdioma).HasColumnType("int");

                entity.Property(e => e.tDescripcionProceso).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblProcesosNavigation)
                      .WithMany(p => p.tblProcesosPaisIdiomaNavigation)
                      .HasForeignKey(d => d.iIDProceso)
                      .HasConstraintName("FK_tblProcesosPaisIdioma_tblProcesos");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblProcesosPaisIdiomaUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblProcesosPaisIdioma_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblProcesosPaisIdiomaUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblProcesosPaisIdioma_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblProcesosPaisIdiomaUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblProcesosPaisIdioma_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblTipoProcesos>(entity =>
            {
                entity.ToTable("tblTipoProcesos", "administrativo");

                entity.HasKey(e => e.iIDTipoProceso);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblTipoProcesosUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblTipoProcesos_tblUsuarios_Creacion");
            });

            modelBuilder.Entity<tblTipoProcesosPaisIdioma>(entity =>
            {
                entity.ToTable("tblTipoProcesosPaisIdioma", "administrativo");

                entity.HasKey(e => e.iIDTipoProcesosPaisIdioma);

                //entity.Property(e => e.iIDTipoProceso).HasColumnType("int");

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.iIDIdioma).HasColumnType("int");

                entity.Property(e => e.tDescripcionProceso).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblTipoProcesosNavigation)
                      .WithMany(p => p.tblTipoProcesosPaisIdiomaNavigation)
                      .HasForeignKey(d => d.iIDTipoProceso)
                      .HasConstraintName("FK_tblTipoProcesosPaisIdioma_tblTipoProcesos");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblTipoProcesosPaisIdiomaUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblTipoProcesosPaisIdioma_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblTipoProcesosPaisIdiomaUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblTipoProcesosPaisIdioma_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblTipoProcesosPaisIdiomaUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblTipoProcesosPaisIdioma_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblProductos>(entity =>
            {
                entity.ToTable("tblProductos", "administrativo");

                entity.HasKey(e => e.iIDProducto);

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.iIDOrganismoControl).HasColumnType("int");

                entity.Property(e => e.tCodigoProducto).HasMaxLength(200);

                entity.Property(e => e.tNombreProducto).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblProductosUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblProductos_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblProductosUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblProductos_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblProductosUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblProductos_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblPaises>(entity =>
            {
                entity.ToTable("tblPaises", "administrativo");

                entity.HasKey(e => e.iIDPais);

                entity.Property(e => e.tCodigoSimple).HasMaxLength(200);

                entity.Property(e => e.tCodigoCompuesto).HasMaxLength(200);

                entity.Property(e => e.tCodigoNumero).HasMaxLength(200);

                entity.Property(e => e.tIndTelefonico).HasMaxLength(200);

                entity.Property(e => e.tNombrePais).HasMaxLength(200);

                entity.Property(e => e.dtFechaCreacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblPaisesUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioCreacion)
                      .HasConstraintName("FK_tblPaises_tblUsuarios_Creacion");

            });

            modelBuilder.Entity<tblOrganismosControl>(entity =>
            {
                entity.ToTable("tblOrganismosControl", "administrativo");

                entity.HasKey(e => e.iIDOrganismoControl);

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.tSiglaOrganismo).HasMaxLength(200);

                entity.Property(e => e.tNombreOrganismo).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblOrganismosControlUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblOrganismosControl_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblOrganismosControlUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblOrganismosControl_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblOrganismosControlUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblOrganismosControl_tblUsuarios_Inactivacion");

            });

            modelBuilder.Entity<tblMetodologiaRiesgo>(entity =>
            {
                entity.ToTable("tblMetodologiaRiesgo", "administrativo");

                entity.HasKey(e => e.iIDMetodologiaRiesgo);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblMetodologiaRiesgoUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblMetodologiaRiesgo_tblUsuarios_Creacion");
            });

            modelBuilder.Entity<tblMetodologiaRiesgoPaisIdioma>(entity =>
            {
                entity.ToTable("tblMetodologiaRiesgoPaisIdioma", "administrativo");

                entity.HasKey(e => e.iIDMetodologiaRiesgoPaisIdioma);

                entity.Property(e => e.iIDMetodologiaRiesgo).HasColumnType("int");

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.iIDIdioma).HasColumnType("int");

                entity.Property(e => e.tSigla).HasMaxLength(200);

                entity.Property(e => e.tDescripcion).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblMetodologiaRiesgoPaisIdiomaUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblMetodologiaRiesgoPaisIdioma_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblMetodologiaRiesgoPaisIdiomaUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblMetodologiaRiesgoPaisIdioma_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblMetodologiaRiesgoPaisIdiomaUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblMetodologiaRiesgoPaisIdioma_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblFactoresRiesgo>(entity =>
            {
                entity.ToTable("tblFactoresRiesgo", "administrativo");

                entity.HasKey(e => e.iIDFactorRiesgo);

                entity.Property(e => e.iIDMetodologiaRiesgo).HasColumnType("int");

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblFactoresRiesgo_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblFactoresRiesgo_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblFactoresRiesgo_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblFactoresRiesgoPaisIdioma>(entity =>
            {
                entity.ToTable("tblFactoresRiesgoPaisIdioma", "administrativo");

                entity.HasKey(e => e.iIDFactorRiesgoPaisIdioma);

                entity.Property(e => e.iIDFactorRiesgo).HasColumnType("int");

                entity.Property(e => e.iIDPais).HasColumnType("int");

                entity.Property(e => e.iIDIdioma).HasColumnType("int");

                entity.Property(e => e.tDescripcionFactor).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoPaisIdiomaUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblFactoresRiesgoPaisIdioma_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoPaisIdiomaUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblFactoresRiesgoPaisIdioma_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblFactoresRiesgoPaisIdiomaUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblFactoresRiesgoPaisIdioma_tblUsuarios_Inactivacion");
            });

            modelBuilder.Entity<tblEntidadOrganismosControl>(entity =>
            {
                entity.ToTable("tblEntidadOrganismosControl", "administrativo");

                entity.HasKey(e => e.iIDEntidadOrganismoControl);

                entity.Property(e => e.iIDEntidad).HasColumnType("int");

                entity.Property(e => e.iIDOrganismoControl).HasColumnType("int");

                entity.Property(e => e.tCodigoEntidad).HasMaxLength(200);

                entity.Property(e => e.dtFechaInsercion).HasColumnType("date");

                entity.Property(e => e.dtFechaModificacion).HasColumnType("date");

                entity.Property(e => e.dtFechaInactivacion).HasColumnType("date");

                entity.Property(e => e.bActivo).HasColumnType("bool");

                entity.HasOne(d => d.tblUsuarioCreacionNavigation)
                      .WithMany(p => p.tblEntidadOrganismosControlUsuarioCreacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInsercion)
                      .HasConstraintName("FK_tblEntidadOrganismosControl_tblUsuarios_Creacion");

                entity.HasOne(d => d.tblUsuarioModificacionNavigation)
                      .WithMany(p => p.tblEntidadOrganismosControlUsuarioModificacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioModificacion)
                      .HasConstraintName("FK_tblEntidadOrganismosControl_tblUsuarios_Modificacion");

                entity.HasOne(d => d.tblUsuarioInactivacionNavigation)
                      .WithMany(p => p.tblEntidadOrganismosControlUsuarioInactivacionNavigation)
                      .HasForeignKey(d => d.iIDUsuarioInactivacion)
                      .HasConstraintName("FK_tblEntidadOrganismosControl_tblUsuarios_Inactivacion");
            });

            //---------

        }
    }
}
 