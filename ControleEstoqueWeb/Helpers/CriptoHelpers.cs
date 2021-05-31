using System.Security.Cryptography;
using System.Text;

namespace ControleEstoqueWeb
{
    public static class CriptoHelpers
    {
        public static string HashMD5(string val)
        {
            var bytes = Encoding.ASCII.GetBytes(val);
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(bytes);
            var retorno = string.Empty;
            for (int i = 0; i < hash.Length; i++)
            {
                retorno += hash[i].ToString("x2");
            }
            return retorno;
        }
    }
}