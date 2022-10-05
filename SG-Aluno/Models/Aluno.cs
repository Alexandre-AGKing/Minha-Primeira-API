using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace SG_Aluno.Models
{
    public class Aluno
    {

        public int ID { get; set; }
        [Required]
        [MinLength(length: 3)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        public bool Sucesso { get; set; }
        public string Erro { get; set; }

    }
}