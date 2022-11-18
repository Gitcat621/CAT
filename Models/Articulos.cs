using System.ComponentModel.DataAnnotations;

namespace proyecto24BM.Models
{
    public class Articulos
    {
        [Key]
        public int PkArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Urlimg { get; set; }
    }
}
