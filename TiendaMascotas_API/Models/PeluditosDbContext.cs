using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TiendaMascotas_API.Models;

public partial class PeluditosDbContext : DbContext
{
    public PeluditosDbContext()
    {
    }

    public PeluditosDbContext(DbContextOptions<PeluditosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<CarritoDt> CarritoDts { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<EstadoCivil> EstadoCivils { get; set; }

    public virtual DbSet<Mascotum> Mascota { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoMascotum> ProductoMascota { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoPago> TipoPagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaDt> VentaDts { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=PeluditosDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.IdCarrito);

            entity.ToTable("Carrito");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descuento).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Iva).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Carrito_Cliente");
        });

        modelBuilder.Entity<CarritoDt>(entity =>
        {
            entity.HasKey(e => e.IdCarritoDt);

            entity.ToTable("CarritoDt");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descuento).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Iva).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.PrecioU).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdCarritoNavigation).WithMany(p => p.CarritoDts)
                .HasForeignKey(d => d.IdCarrito)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoDt_Carrito");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.CarritoDts)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CarritoDt_Producto");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(35)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Cliente");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Genero)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Identificacion)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoCivilNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdEstadoCivil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_EstadoCivil");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_Usuario");
        });

        modelBuilder.Entity<EstadoCivil>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCivil);

            entity.ToTable("EstadoCivil");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mascotum>(entity =>
        {
            entity.HasKey(e => e.IdMascota);

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.PrecioCosto).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_Categoria");
        });

        modelBuilder.Entity<ProductoMascotum>(entity =>
        {
            entity.HasKey(e => e.IdProductoMascota);

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdMascotaNavigation).WithMany(p => p.ProductoMascota)
                .HasForeignKey(d => d.IdMascota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoMascota_Mascota");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoMascota)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductoMascota_Producto");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK_Rol_1");

            entity.ToTable("Rol");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoPago>(entity =>
        {
            entity.HasKey(e => e.IdTipoPago);

            entity.ToTable("TipoPago");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK_User");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(75)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        modelBuilder.Entity<VentaDt>(entity =>
        {
            entity.HasKey(e => e.IdVentaDt);

            entity.ToTable("VentaDt");

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descuento).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Iva).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.PrecioU).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentaDts)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaDt_Producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaDts)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VentaDt_Venta");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta);

            entity.Property(e => e.CreadoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Descuento).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Iva).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_Cliente");

            entity.HasOne(d => d.IdTipoPagoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoPago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Venta_TipoPago");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
