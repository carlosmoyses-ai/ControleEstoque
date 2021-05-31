using System.Configuration;
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
                    comando.CommandText = string.Format(
                        "SELECT COUNT(*) FROM USUARIO WHERE LOGIN = '{0}' AND SENHA = '{1}'",
                        login, CriptoHelpers.HashMD5(senha));
                    retorno = ((int)comando.ExecuteScalar() > 0);
                }
            }
            return retorno;
        }
    }
}