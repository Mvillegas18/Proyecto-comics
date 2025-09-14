using Lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace lib_repositorios.Implementaciones
{
    public partial class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones explícitamente para evitar conflictos de convención
            
            // Relación Clientes -> Membresias
            modelBuilder.Entity<Clientes>()
                .HasOne(c => c.MembresiaNavigation)
                .WithMany(m => m.Clientes)
                .HasForeignKey(c => c.Membresia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Comics -> Categorias
            modelBuilder.Entity<Comics>()
                .HasOne(c => c.CategoriaNavigation)
                .WithMany(cat => cat.Comics)
                .HasForeignKey(c => c.Categoria)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Comics -> Inventarios
            modelBuilder.Entity<Comics>()
                .HasOne(c => c.InventarioNavigation)
                .WithMany(i => i.Comics)
                .HasForeignKey(c => c.Inventario)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Ventas -> Empleados
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.EmpleadoNavigation)
                .WithMany(e => e.Ventas)
                .HasForeignKey(v => v.Empleado)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Ventas -> Proveedores
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.ProveedorNavigation)
                .WithMany(p => p.Ventas)
                .HasForeignKey(v => v.Proveedor)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Ventas -> Membresias
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.MembresiaNavigation)
                .WithMany(m => m.Ventas)
                .HasForeignKey(v => v.Membresia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación DetalleVentas -> Ventas
            modelBuilder.Entity<DetalleVentas>()
                .HasOne(dv => dv.VentaNavigation)
                .WithMany(v => v.DetalleVentas)
                .HasForeignKey(dv => dv.Venta)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación DetalleVentas -> Comics
            modelBuilder.Entity<DetalleVentas>()
                .HasOne(dv => dv.ComicNavigation)
                .WithMany(c => c.DetalleVentas)
                .HasForeignKey(dv => dv.Comic)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Compras -> Clientes
            modelBuilder.Entity<Compras>()
                .HasOne(c => c.ClienteNavigation)
                .WithMany(cl => cl.Compras)
                .HasForeignKey(c => c.Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación DetalleCompras -> Compras
            modelBuilder.Entity<DetalleCompras>()
                .HasOne(dc => dc.CompraNavigation)
                .WithMany(c => c.DetalleCompras)
                .HasForeignKey(dc => dc.Compra)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación DetalleCompras -> Comics
            modelBuilder.Entity<DetalleCompras>()
                .HasOne(dc => dc.ComicNavigation)
                .WithMany(c => c.DetalleCompras)
                .HasForeignKey(dc => dc.Comic)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación DetalleCompras -> Pagos
            modelBuilder.Entity<DetalleCompras>()
                .HasOne(dc => dc.PagoNavigation)
                .WithMany(p => p.DetalleCompras)
                .HasForeignKey(dc => dc.Pago)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Devoluciones -> Clientes
            modelBuilder.Entity<Devoluciones>()
                .HasOne(d => d.ClienteNavigation)
                .WithMany(c => c.Devoluciones)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Devoluciones -> DetalleCompras
            modelBuilder.Entity<Devoluciones>()
                .HasOne(d => d.DetalleCompraNavigation)
                .WithMany(dc => dc.Devoluciones)
                .HasForeignKey(d => d.Detalle_compra)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Comic_promociones -> Promociones
            modelBuilder.Entity<Comic_promociones>()
                .HasOne(cp => cp.PromocionNavigation)
                .WithMany(p => p.ComicPromociones)
                .HasForeignKey(cp => cp.Promocion)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Comic_promociones -> Comics
            modelBuilder.Entity<Comic_promociones>()
                .HasOne(cp => cp.ComicNavigation)
                .WithMany(c => c.ComicPromociones)
                .HasForeignKey(cp => cp.Comic)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Empleados>? Empleados { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Inventarios>? Inventarios { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Comics>? Comics { get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Ventas>? Ventas { get; set; }
        public DbSet<DetalleVentas>? DetalleVentas { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Compras>? Compras { get; set; }
        public DbSet<DetalleCompras>? DetalleCompras { get; set; }
        public DbSet<Devoluciones>? Devoluciones { get; set; }
        public DbSet<Promociones>? Promociones { get; set; }
        public DbSet<Comic_promociones>? ComicPromociones { get; set; }
    }
}