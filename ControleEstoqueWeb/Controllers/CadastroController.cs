using ControleEstoqueWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ControleEstoqueWeb.Controllers
{
    public class CadastroController : Controller
    {
        public static List<GrupoProdutoModel> _listaGrupoProduto = new List<GrupoProdutoModel>()
        {
            new GrupoProdutoModel()
            {
                Id = 1,
                Nome = "Livros",
                Ativo = true
            },
            new GrupoProdutoModel()
            {
                Id = 2,
                Nome = "Mouses",
                Ativo = true
            },
            new GrupoProdutoModel()
            {
                Id = 3,
                Nome = "Monitores",
                Ativo = false
            },
        };

        [Authorize]
        public ActionResult GrupoProduto()
        {
            return View(GrupoProdutoModel.RecuperarLista());
        }

        [HttpPost]
        [Authorize]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(GrupoProdutoModel.RecuperarListaPeloId(id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult SalvarGrupoProduto(GrupoProdutoModel model)
        {
            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                try
                {
                    var id = model.Salvar();
                    if (id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }
                }
                catch (Exception)
                {
                    resultado = "ERRO";
                }
            }
            return Json(new
            {
                Resultado = resultado,
                Mensagens = mensagens,
                IdSalvo = idSalvo
            });
        }

        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            return Json(GrupoProdutoModel.ExcluirListaPeloId(id));
        }

        [Authorize]
        public ActionResult MarcaProduto()
        {
            return View();
        }
        [Authorize]
        public ActionResult LocalProduto()
        {
            return View();
        }
        [Authorize]
        public ActionResult UnidadeMedida()
        {
            return View();
        }
        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }
        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }
        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }
        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }
        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }
        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }

    }
}