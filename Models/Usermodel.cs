using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gerendiador_Encomendas.Models
{
    [Table ("Usuarios")]
    public class Usermodel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
