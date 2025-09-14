using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib_dominio.Entidades
{
    public class Clientes
    {
        [Key]
        public int Id_cliente { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public DateTime Fecha_registro { get; set; }
        
        // Clave foránea
        public int Membresia { get; set; }
        
        // Propiedad de navegación
        [ForeignKey("Membresia")]
        public virtual Membresias? MembresiaNavigation { get; set; }
        
        // Navegación inversa
        public virtual ICollection<Compras>? Compras { get; set; }
        public virtual ICollection<Devoluciones>? Devoluciones { get; set; }
    }
}