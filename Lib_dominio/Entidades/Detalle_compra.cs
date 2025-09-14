using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    [Table("Detalle_compras")]
    public class DetalleCompras
    {
        [Key]
        public int Id { get; set; }
        public decimal Precio_unitario { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public string? Tipo_producto_comprado { get; set; }

        // Claves foráneas
        public int Compra { get; set; }
        public int Comic { get; set; }
        public int Pago { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("Compra")]
        public virtual Compras? CompraNavigation { get; set; }
        
        [ForeignKey("Comic")]
        public virtual Comics? ComicNavigation { get; set; }
        
        [ForeignKey("Pago")]
        public virtual Pagos? PagoNavigation { get; set; }
        
        // Navegación inversa
        public virtual ICollection<Devoluciones>? Devoluciones { get; set; }
    }
}
