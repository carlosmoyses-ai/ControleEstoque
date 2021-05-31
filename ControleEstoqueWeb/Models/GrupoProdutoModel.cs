using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoqueWeb.Models
{
    public class GrupoProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}