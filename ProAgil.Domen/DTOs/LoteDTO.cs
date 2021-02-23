using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProAgil.Domen.DTOs
{
    public class LoteDTO
    {
        public int ID { get; set; }

        [StringLength(150, ErrorMessage = "A quantidade máxima de caractéres é 150")]
        [Required(ErrorMessage = "O nome do lote é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0, double.MaxValue, ErrorMessage = "Aceito somente valores monetários")]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }

        [Required(ErrorMessage = "A quantidade é de ingressos do lote é obrigatório")]
        public int Quantidade { get; set; }

    }
}
