using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace SG_Aluno.Models
{
    public class AlunoServices : Conexao
    {

        string ComandoMysql;
        MySqlCommand cmd;

        public bool Adicionar(Aluno aluno)
        {
            try
            {
                ComandoMysql = "insert into aluno values(default,@nome,@nascimento);";
                cmd = new MySqlCommand(ComandoMysql, conecao);
                cmd.Parameters.AddWithValue("nome", aluno.Nome);
                cmd.Parameters.AddWithValue("nascimento", aluno.DataNascimento);
                conecao.Open();
                cmd.ExecuteNonQuery();
                aluno.Sucesso = true;


            }
            catch (System.Exception ex)
            {
                aluno.Erro = ex.ToString();
                aluno.Sucesso = false;

            }
            finally
            {
                conecao.Close();
            }
            return aluno.Sucesso;
        }
        public List<Aluno> Listar()
        {
            Aluno aluno;
            List<Aluno> lista = new List<Aluno>();
            try
            {

                ComandoMysql = "select * from  aluno";
                cmd = new MySqlCommand(ComandoMysql, conecao);
                conecao.Open();
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    aluno = new Aluno();
                    aluno.ID = Convert.ToInt32(dataReader[0].ToString());
                    aluno.Nome = dataReader[1].ToString();
                    aluno.DataNascimento = Convert.ToDateTime(dataReader[2].ToString());
                    lista.Add(aluno);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
            finally
            {
                conecao.Close();
            }


            return lista;
        }
        public Aluno Eliminar(Aluno aluno)
        {
            try
            {
                ComandoMysql = "delete from aluno where id=@id";
                cmd = new MySqlCommand(ComandoMysql, conecao);
                cmd.Parameters.AddWithValue("@id", aluno.ID);
                conecao.Open();
                cmd.ExecuteNonQuery();
                aluno.Sucesso = true;
            }
            catch (System.Exception ex)
            {
                aluno.Erro = ex.ToString();
                aluno.Sucesso = false;

            }
            finally
            {
                conecao.Close();
            }

            return aluno;

        }
        public Aluno Consultar(Aluno aluno)
        {
            ComandoMysql = "select * from aluno where ID=@id";
            cmd = new MySqlCommand(ComandoMysql, conecao);
            cmd.Parameters.AddWithValue("@id", aluno.ID);
            conecao.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                aluno = new Aluno();
                aluno.ID = Convert.ToInt32(dataReader[0].ToString());
                aluno.Nome = dataReader[1].ToString();
                aluno.DataNascimento = Convert.ToDateTime(dataReader[2].ToString());
            }
            return aluno;
        }
        public Aluno Alterar(Aluno aluno)
        {
            ComandoMysql = "UPDATE aluno set Nome=@nome,DataNascimento=@datanascimento where ID=@id";
            cmd = new MySqlCommand(ComandoMysql, conecao);
            cmd.Parameters.AddWithValue("id", aluno.ID);
            cmd.Parameters.AddWithValue("nome", aluno.Nome);
            cmd.Parameters.AddWithValue("datanascimento", aluno.DataNascimento);
            try
            {
                conecao.Open();
                cmd.ExecuteNonQuery();
                aluno.Sucesso = true;
            }
            catch (System.Exception ex)
            {
                aluno.Erro = ex.ToString();
                aluno.Sucesso = false;
            }
            finally
            {
                conecao.Close();
            }
            return aluno;
        }

    }
}