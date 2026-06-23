using MySql.Data.MySqlClient;

namespace AULACRUD.Services
{
    public class Conexao
    {
        private string dadosConexao= "server=localhost;database=escola1;user=root;password=";

        public MySqlConnection Conectar()
        {
            return new MySqlConnection(dadosConexao);
        }
    }
}