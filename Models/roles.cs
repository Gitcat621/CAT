using System.ComponentModel.DataAnnotations;

namespace proyecto24BM.Models
{
    public class roles
    {
        [Key]
        public int Pkrol { get; set; }
        public string Nombre { get; set; }
    }
}
