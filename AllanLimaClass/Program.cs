using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllanLimaClass
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        // conteúdo da classe Banco
        public static MySqlCommand Abrir(int cod = 0) // método para abrir conexão
        {
            string strcon = @"server=127.0.0.1;database=systinsdb01;user=aluno;password=senac";
            MySqlConnection mySqlConnection = new(strcon);
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
