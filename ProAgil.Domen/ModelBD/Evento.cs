using ProAgil.Domen.ModelBD.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace ProAgil.Domen.ModelBD
{
    public class Evento : BaseModel
    {
        [Required(ErrorMessage = "O local do evento deve ser informado")]
        [StringLength(150, ErrorMessage = "A quantidade máxima de caractéres é de 150")]
        public string Local { get; set; }

        [Required(ErrorMessage = "A data do evento é obrigatória")]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "O tema do evento é obrigatório")]
        [StringLength(200, ErrorMessage ="A quantidade de caractéres não pode ser maior que 200")]
        public string Tema { get; set; }

        [Required(ErrorMessage = "A quantidade de pessoas é obrigatória")]
        [Range(3, 120000, ErrorMessage = "A quantidade de pessoas permitida deve ser no minimo 3 e no máximo 120.000")]
        public int QtdPessoas { get; set; }

        [StringLength(2000, ErrorMessage = "O nome do arquivo pode ter somente 2000 caractéres")]
        public string ImagemURL { get; set; }
        
        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        [StringLength(20, ErrorMessage = "A quantidade de caractéres deve ser no maximo 20")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Deve ser um e-mail válido")]
        [StringLength(300, ErrorMessage = "O e-mail não pode ter mais que 300 caractéres")]
        public string Email { get; set; }
        public List<Lote> Lotes { get; set; }
        public List<RedeSocial> RedeSociais { get; set; }
        public ICollection<Palestrante> Palestrantes { get; set; }

    }
}
