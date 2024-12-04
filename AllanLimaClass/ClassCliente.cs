using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Mysqlx.Notice.Warning.Types;

namespace AllanLimaClass
{
    public class ClassCliente
    {
        private object value1;
        private object value2;
        private object value3;
        private object value4;
        private object value5;
        private object value6;

        public int Id_cliente {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set;}
        public TextBox Endereco {  get; set; }
    
        public ClassCliente(int id_cliente, string nome, string email, string telefone, TextBox endereco)
        {
            Id_cliente = id_cliente;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }

        public ClassCliente(object value1, object value2, object value3, object value4, object value5, object value6)
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
            cmd.CommandText = "sp_cliente_insert";
            cmd.Parameters.Add("spnome", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Nome;
            cmd.Parameters.AddWithValue("spnome", Nome);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sptelefone", Telefone);
            cmd.Parameters.AddWithValue("spendereco", Endereco);
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
        public static List<ClassCliente> ObterLista()
        {
            List<ClassCliente> lista = new();
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
            cmd.Parameters.AddWithValue("spid_cliente", Id_cliente);
            cmd.Parameters.AddWithValue("spemail", Email);
            cmd.Parameters.AddWithValue("sptetefone", Telefone);
            cmd.Parameters.AddWithValue("spendereco", Endereco);
            return cmd.ExecuteNonQuery() > 0? true : false;
        }
    
    
    
    }
   

    
}
/*
  id_cliente int(11) AI PK 
nome varchar(100) 
email varchar(100) 
telefone varchar(20) 
endereco text*/