using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ControleEstoqueWeb.Models
{
    public class UsuarioModel
    {
        public static bool ValidarUsuario(string login, string senha)
        {
            var retorno = false;
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString = ConfigurationManager.ConnectionStrings["principal"].ConnectionString;
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    comando.CommandText = "SELECT COUNT(*) FROM USUARIO WHERE LOGIN = @login AND SENHA = @senha";

                    comando.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = CriptoHelpers.HashMD5(senha);
                    retorno = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return retorno;
        }
    }
}