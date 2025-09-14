using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    public class Compras
    {
        [Key]
        public int Id_compra { get; set; }
        public DateTime Fecha_compra { get; set; }
        public string? Nombre_comic { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public string? Estado_compra { get; set; }

        // Clave foránea
        public int Cliente { get; set; }
        
        // Propiedad de navegación
        [ForeignKey("Cliente")]
        public virtual Clientes? ClienteNavigation { get; set; }
        
        // Navegación inversa
        public virtual ICollection<DetalleCompras>? DetalleCompras { get; set; }
    }
}