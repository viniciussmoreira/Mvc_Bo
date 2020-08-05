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
                        aluno.Id = Convert.ToInt32(rdr["Id"]);
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

        public void IncluirAluno(Aluno aluno)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexao = configuration.GetConnectionString("DefaultConnection");
            try
            {
                using (SqlConnection con = new SqlConnection(conexao))
                {
                    SqlCommand cmd = new SqlCommand("IncluirAlunos", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    SqlParameter paramNascimento = new SqlParameter();
                    paramNascimento.ParameterName = "@nascimento";
                    paramNascimento.Value = aluno.Nascimento;
                    cmd.Parameters.Add(paramNascimento);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
