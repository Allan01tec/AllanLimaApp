using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllanLimaClass
{

    public static class Banco
    {
        // conteúdo da classe Banco
        public static MySqlCommand Abrir(int cod = 0) // método para abrir conexão
        {
            string strcon = @"server=127.0.0.1;database=sistemadeencomendasplacas;user=root;password=";
            MySqlConnection cn = new(strcon);
            MySqlCommand cmd = new();
            try
            {
                cn.Open();
                cmd.Connection = cn;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return cmd;
        }
    }
}
