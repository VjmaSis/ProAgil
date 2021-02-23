using ProAgil.Domen.ModelBD.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProAgil.Domen.ModelBD
{
    public class RedeSocial : BaseModel
    {
        [Required(ErrorMessage = "O nome da rede é obrigatório")]
        [StringLength(200, ErrorMessage = "A quantidade de caractéres não pode ser maior que 200")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A URL da rede é obrigatório")]
        [StringLength(1000, ErrorMessage = "A quantidade de caractéres não pode ser maior que 1000")]
        public string Url { get; set; }

        public int? EventoID { get; set; }
        public Evento Evento { get; }
        public int? PalestranteID { get; set; }
        public Palestrante Palestrante { get; }

    }
}
