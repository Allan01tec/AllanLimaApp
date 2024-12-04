using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AllanLimaClass.ClassPlaca;

namespace AllanLimaClass
{
    public class ClassPlaca
    {
        private object value1;
        private object value2;
        private object value3;
        private object value4;
        private object value5;

        public ClassPlaca(object value1, object value2, object value3, object value4, object value5)
        {
            this.value1 = value1;
            this.value2 = value2;
            this.value3 = value3;
            this.value4 = value4;
            this.value5 = value5;
        }

        public class Classplaca
        {
            private object value1;
            private object value2;
            private object value3;
            private object value4;
    

            public int Id_placa { get; set; }
            public string Tipo { get; set; }
            public string Tamanho { get; set; }
            public string Preco { get; set; }


            public Classplaca(int id_placa, string tipo, string tamaho, decimal preco)
            {
                Id_placa = id_placa;
                Tipo = tipo;
                Tamanho = tamaho;
                
          
            }

            public Classplaca(object value1, object value2, object value3, object value4, object value5, object value6)
            {
                this.value1 = value1;
                this.value2 = value2;
                this.value3 = value3;
                this.value4 = value4;
           
            }

            public void Inserir()
            {
                var cmd = Banco.Abrir();

                cmd.CommandType = StoredProcedure;
                cmd.CommandText = "sp_cliente_insert";
                cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
                cmd.Parameters.AddWithValue("spid_placa", Id_placa);
                cmd.Parameters.AddWithValue("sptipo", Tipo);
                cmd.Parameters.AddWithValue("sptamanho", Tamanho);
                cmd.Parameters.AddWithValue("sppres", Preco);
                var dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Id_placa = dr.GetInt32(0);
                }
                cmd.Connection.Close();
            }
            public static ClassPlaca ObterPorId(int id)
            {
                ClassPlaca classPlaca = new();
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from clientes where id_cliente = {id}";
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
            public static List<ClassPlaca> ObterLista()
            {
                List<ClassPlaca> lista = new();
                var cmd = Banco.Abrir();
                cmd.CommandText = $"select * from clientes order by nome asc";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lista.Add(new(
                            dr.GetInt32(0),
                            dr.GetString(1),
                            dr.GetString(2),
                    dr.GetString(3),
                            id_cliente.ObterPorId(dr.GetInt32(4))

                        )

                    );
                }
                return lista;
            }
            public bool Atualizar()
            {
                var cmd = Banco.Abrir();
                cmd.commandType.StoredProcedure;
                cmd.CommandText = "sp_cliente_altera";
                cmd.Parameters.AddWithValue("sptipo", Tipo);
                cmd.Parameters.AddWithValue("sptamanho", Tamanho);
                cmd.Parameters.AddWithValue("sppreco", Preco);
                return cmd.ExecuteNonQuery() > 0 ? true : false;
            }



        }

    }
}
}
/*
 id_placa int(11) AI PK 
tipo varchar(50) 
tamanho varchar(50) 
preco decimal(10,2)*/