using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    public class Ventas
    {
        [Key]
        public int Id_venta { get; set; }
        public DateTime Fecha_venta { get; set; }
        public decimal Total { get; set; }
        public string? Metodo_pago { get; set; }
        public string? Estado_venta { get; set; }
        public string? Tipo_venta { get; set; }

        // Claves foráneas
        public int Empleado { get; set; }
        public int Proveedor { get; set; }
        public int Membresia { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("Empleado")]
        public virtual Empleados? EmpleadoNavigation { get; set; }
        
        [ForeignKey("Proveedor")]
        public virtual Proveedores? ProveedorNavigation { get; set; }
        
        [ForeignKey("Membresia")]
        public virtual Membresias? MembresiaNavigation { get; set; }
        
        // Navegación inversa
        public virtual ICollection<DetalleVentas>? DetalleVentas { get; set; }
    }
}