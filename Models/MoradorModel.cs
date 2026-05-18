using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gerendiador_Encomendas.Models
{
    [Table("Morador")]
    public class MoradorModel
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Casa { get; set; }
        public string? Numero { get; set; }
        public string? Email { get; set; }
    }
}
