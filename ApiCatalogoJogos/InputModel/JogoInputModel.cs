using System;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "O preço do jogo deve ser entre 1 e 1000 reais")]
        public double Preco { get; set; }

        [Required]
        [Range(1960, 3000, ErrorMessage = "O ano de lançamento do jogo deve ser maior que 1960")]
        public int AnoLancamento { get; set; }
    }
}
