using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Gerendiador_Encomendas.Models
{
    [Table("Encomenda")]
    public class EncomendaModel
    {
        [Key]
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nome_morador { get; set; }

        [ForeignKey("Morador")]
        public int? Id_morador { get; set; }

        public string? Observacao { get; set; }
        public DateTime? Data_recebida { get; set; }
        public DateTime? Data_entrega { get; set; }
    }
}
