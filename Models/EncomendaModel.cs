using System.ComponentModel.DataAnnotations;

namespace API_Gerendiador_Encomendas.Models
{
    public class EncomendaModel
    {
        [Key]
        public int Id { get; set; }
        public string? Codigo{ get; set; }
        public string? Nome_morador { get; set; }
        public string? Id_moraddor { get; set; }
        public string? Observacao { get; set; }
        public DateTime? Data_recebida { get; set; }
        public DateTime? Data_entrega { get; set; }

    }
}
