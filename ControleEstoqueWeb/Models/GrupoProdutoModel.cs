using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ControleEstoqueWeb.Models
{
    public class GrupoProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o nome")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public static List<GrupoProdutoModel> RecuperarLista()
        {
            var retorno = new List<GrupoProdutoModel>();
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "SELECT * FROM GRUPO_PRODUTO ORDER BY Nome";
                    var reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        retorno.Add(new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]
                        });
                    }
                }
            }
            return retorno;
        }

        public static GrupoProdutoModel RecuperarListaPeloId(int id)
        {
            GrupoProdutoModel retorno = null;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "SELECT * FROM GRUPO_PRODUTO WHERE (id = @id)";

                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    var reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        retorno = new GrupoProdutoModel
                        {
                            Id = (int)reader["id"],
                            Nome = (string)reader["nome"],
                            Ativo = (bool)reader["ativo"]
                        };
                    }
                }
            }
            return retorno;
        }

        public static bool ExcluirListaPeloId(int id)
        {
            var retorno = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "DELETE FROM GRUPO_PRODUTO WHERE (id = @id)";

                    comando.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    retorno = (comando.ExecuteNonQuery() > 0);
                }
            }
            return retorno;
        }

        public int Salvar()
        {
            var retorno = 0;
            var model = RecuperarListaPeloId(this.Id);

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    if (model == null)
                    {
                        comando.CommandText = "INSERT INTO GRUPO_PRODUTO (NOME, ATIVO) VALUES ( @nome, @ativo)";
                        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = this.Nome;
                        comando.Parameters.Add("@ativo", SqlDbType.Bit).Value = this.Ativo ? 1 : 0;
                        retorno = comando.ExecuteNonQuery();
                    }
                    else
                    {
                        comando.CommandText = "UPDATE GRUPO_PRODUTO SET NOME= @nome, ATIVO= @ativo WHERE ID = @id";
                        comando.Parameters.Add("@id", SqlDbType.Int).Value = this.Id;
                        comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = this.Nome;
                        comando.Parameters.Add("@ativo", SqlDbType.Bit).Value = this.Ativo ? 1 : 0;
                        if (comando.ExecuteNonQuery() > 0)
                        {
                            retorno = this.Id;
                        }
                    }
                }
            }
            return retorno;
        }
    }
}