using Microsoft.Extensions.Configuration;
using Mvc_Bo.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Threading.Tasks;

namespace Mvc_Bo.Models
{
    public class MotoBll
    {
        public List<Moto> GetMotos()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefaultConnection");

            List<Moto> motos = new List<Moto>();

            try
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    SqlCommand cmd = new SqlCommand("GetMotos", conexao);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexao.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Moto moto = new Moto();
                        moto.Id = Convert.ToInt32(dr["id"]);
                        moto.Nome = dr["Nome"].ToString();
                        moto.Cor = dr["Cor"].ToString();
                        moto.Cilindrada = Convert.ToInt32(dr["Cilindrada"]);
                        motos.Add(moto);
                    }


                }
                return motos;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}

