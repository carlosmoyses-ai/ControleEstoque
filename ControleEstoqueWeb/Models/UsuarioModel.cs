using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ControleEstoqueWeb.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var retorno = false;
            using( var conexao = new SqlConnection())
            {
                conexao.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=controle-estoque;Trusted_Connection=True;MultipleActiveResultSets=true";
                conexao.Open();
                using(var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = string.Format("SELECT COUNT(*) FROM USUARIO WHERE LOGIN = '{0}' AND SENHA = {1}", login, senha);
                    retorno = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return retorno;
        }
    }
}