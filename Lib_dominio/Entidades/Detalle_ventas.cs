using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    [Table("Detalle_Ventas")]
    public class DetalleVentas
    {
        [Key]
        public int Id { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string? Tipo_producto_vendido { get; set; }

        // Claves foráneas
        public int Venta { get; set; }
        public int Comic { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("Venta")]
        public virtual Ventas? VentaNavigation { get; set; }
        
        [ForeignKey("Comic")]
        public virtual Comics? ComicNavigation { get; set; }
    }
}