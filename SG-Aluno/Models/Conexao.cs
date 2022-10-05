using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace SG_Aluno.Models
{
    public class Conexao
    {
        public MySqlConnection conecao = new MySqlConnection("User id=root;Password=klb@@13%;Host=localhost;DataBase=sg_escolar;");

    }
}