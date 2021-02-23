using ProAgil.Domen.ModelBD.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProAgil.Domen.ModelBD
{
    public class Lote : BaseModel
    {
        [StringLength(150, ErrorMessage = "A quantidade máxima de caractéres é 150")]
        [Required(ErrorMessage = "O nome do lote é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        [Required(ErrorMessage = "A quantidade é de ingressos do lote é obrigatório")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage ="O evento referente ao lote deve ser informado")]
        public int EventoID { get; set; }
        public Evento Evento { get;  }
    }
}
