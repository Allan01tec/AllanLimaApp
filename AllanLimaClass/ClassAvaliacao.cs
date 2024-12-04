using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllanLimaClass
{
    
        public class ClassAvaliacao
        {
            private object value1;
            private object value2;
            private object value3;
            private object value4;
            private object value5;
            private object value6;

            public int Id_avaliacao { get; set; }
            public string Id_placa { get; set; }
            public string Id_cliente { get; set; }
            public string Nota { get; set; }
            public  string Comenteario{ get; set; }

            public ClassAvaliacao(int id_avaliacao, string id_placa, string id_cliente, string nota, string comentario)
            {
                Id_avaliacao = id_avaliacao;
                Id_placa= id_placa;
                Id_cliente = id_cliente;
                Nota = nota;
                Comenteario = comentario;
            }

            public ClassAvaliacao(object value1, object value2, object value3, object value4, object value5, object value6)
            {
                this.value1 = value1;
                this.value2 = value2;
                this.value3 = value3;
                this.value4 = value4;
                this.value5 = value5;
                this.value6 = value6;
            }

            public void Inserir()
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = StoredProcedure;
                cmd.CommandText = "sp_avaliacao_insert";
                cmd.Parameters.Add("spid_avaliacao", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Id_avaliacao;
                cmd.Parameters.AddWithValue("id_placa", Id_placa);
                cmd.Parameters.AddWithValue("spnota", Nota);
                cmd.Parameters.AddWithValue("spcomentario", Comenteario);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Id_cliente = dr.GetInt32(0);
                }
                cmd.Connection.Close();
            }
            public static ClassCliente ObterPorId(int id)
            {
                ClassCliente classCliente = new();
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from avaliacao where id_cliente = {id}";
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    classCliente = new(
                        dr.GetInt32(0),
                         dr.GetInt32(1),
                          dr.GetInt32(2),
                           dr.GetInt32(3)
                        );
                }
                return classCliente;


            }
            public static List<ClassAvaliacao> ObterLista()
            {
                List<ClassAvaliacao> lista = new();
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from avaliacao order by nome asc";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new(
                            dr.GetInt32(0),
                            dr.GetString(1),
                            dr.GetString(2),
                    dr.GetString(3),
                            id_avaliacao.ObterPorId(dr.GetInt32(4))
    

                        )

                    );
                }
                return lista;
            }
            public bool Atualizar()
            {
                var cmd = Banco.Abrir();
                cmd.commandType.StoredProcedure;
                cmd.CommandText = "sp_avaliacao_altera";
                cmd.Parameters.AddWithValue("spid_placa", Id_placa);
                cmd.Parameters.AddWithValue("spnota", Nota);
                cmd.Parameters.AddWithValue("spcomentario", Comenteario);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }



        }
    }
}
