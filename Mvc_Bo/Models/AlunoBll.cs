using Microsoft.Extensions.Configuration;
using Mvc_Bo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Bo.Models
{
    public class AlunoBll : IAlunoBll
    {
        public List<Aluno> GetAlunos()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefaultConnection");

            List<Aluno> alunos = new List<Aluno>();

            try
            {       //
                using (SqlConnection con = new SqlConnection(conexaoString))//faz a conexão
                {
                    SqlCommand cmd = new SqlCommand("GetAlunos", con); //nome da ação, no caso, procedure
                    cmd.CommandType = CommandType.StoredProcedure;     //Informa que é procedure
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32("Id");
                        aluno.Nome = rdr["Nome"].ToString();
                        aluno.Sexo = rdr["Sexo"].ToString();
                        aluno.Email = rdr["Email"].ToString();
                        aluno.Nascimento = Convert.ToDateTime(rdr["Nascimento"]);                        
                        alunos.Add(aluno);
                    }

                }
                return alunos;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
