using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProEventos.Service.DTO
{
    public class EventoDTO
    {
        public int Id { get; set; }

        public string Local { get; set; }

        public string DataEvento { get; set; }

        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        //[MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres")]
        //[MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {1} e {2} caracteres")]
        public string Tema { get; set; }

        [Display(Name = "Quantidade de Pessoas")]
        [Range(1, 120000, ErrorMessage = "{0} não pode ser menor que {1} e maior que {2}")]
        public int QtdPessoas { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Não é uma imagem válida. (gif, jpeg, jpg, bmp ou png)")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Phone(ErrorMessage ="O campo {0} está com um número inválido.")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Não foi informado um {0} válido.")]
        public string Email { get; set; }

        public IEnumerable<LoteDTO> Lotes { get; set; }
        public IEnumerable<RedeSocialDTO> RedesSociais { get; set; }
        public IEnumerable<PalestranteDTO> Palestrantes { get; set; }
    }
}
