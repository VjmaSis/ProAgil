using ProAgil.Domen.ModelBD.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProAgil.Domen.ModelBD
{
    public class Palestrante : BaseModel
    {
        [Required(ErrorMessage = "O nome do  é obrigatório")]
        [StringLength(200, ErrorMessage = "A quantidade de caractéres não pode ser maior que 200")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O mini curriculum é obrigatório")]
        [StringLength(6000, ErrorMessage = "A quantidade de caractéres não pode ser maior que 6000")]
        public string MiniCurriculo { get; set; }

        [StringLength(2000, ErrorMessage = "O nome do arquivo pode ter somente 2000 caractéres")]
        public string ImagemURL { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        [StringLength(20, ErrorMessage = "A quantidade de caractéres deve ser no maximo 20")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Deve ser um e-mail válido")]
        [StringLength(300, ErrorMessage = "O e-mail não pode ter mais que 300 caractéres")]
        public string Email { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public ICollection<Evento> Eventos { get; set; }

    }
}
