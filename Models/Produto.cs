using System.ComponentModel.DataAnnotations;

namespace ApiFuncional.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public required string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}
