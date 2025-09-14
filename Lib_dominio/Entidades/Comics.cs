using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{

    public class Comics
    {
        [Key]
        public int Id_comic { get; set; }
        public string? Nombre { get; set; }
        public string? Editorial { get; set; }
        public string? Autor { get; set; }
        public string? Ilustrador { get; set; }
        public decimal Precio { get; set; }

        // Claves foráneas
        public int Categoria { get; set; }
        public int Inventario { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("Categoria")]
        public virtual Categorias? CategoriaNavigation { get; set; }
        
        [ForeignKey("Inventario")]
        public virtual Inventarios? InventarioNavigation { get; set; }
        
        // Navegación inversa
        public virtual ICollection<DetalleVentas>? DetalleVentas { get; set; }
        public virtual ICollection<DetalleCompras>? DetalleCompras { get; set; }
        public virtual ICollection<Comic_promociones>? ComicPromociones { get; set; }
    }
}