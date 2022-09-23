using DTSMCC_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_WebApp.Controllers
{
    public class ProvinsiController : Controller
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source = NEKOZAWA; Initial Catalog = DTSMCC; User Id = user; Password = 12345678;";

        //READ
        public IActionResult Index()
        {
            string query = "SELECT * FROM Provinsi";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            List<Provinsi> Provinsis = new List<Provinsi>();

            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Provinsi provinsi = new Provinsi();
                            provinsi.idProvinsi = sqlDataReader[0].ToString();
                            provinsi.namaProvinsi = sqlDataReader[1].ToString();
                            Provinsis.Add(provinsi);
                        }
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return View(Provinsis);
        }

        //READ BY ID
        //GET
        public IActionResult ReadById(string id)
        {
            string query = "SELECT * FROM pegawai WHERE idPegawai = @id";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            Provinsi provinsi = new Provinsi();

            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.ParameterName = "@id";
            sqlParameter.Value = id;

            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            provinsi.idProvinsi = sqlDataReader[0].ToString();
                            provinsi.namaProvinsi = sqlDataReader[1].ToString();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return View(provinsi);
        }

        //CREATE
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        public IActionResult Create(Provinsi provinsi)
        {
            using(var context = new )
            {

            }

            return View();
        }

        //UPDATE
        //GET
        public IActionResult Update(string id)
        {
            List<Provinsi> Provinsis = new List<Provinsi>();
            var std = Provinsis.Where(s => s.idProvinsi == id).FirstOrDefault();

            return View(std);
        }

        //POST
        public IActionResult Update(Provinsi provinsi)
        {
            return View();
        }

        //DELETE
        //GET
        public IActionResult Delete(string id)
        {
            var sql = "DELETE FROM Provinsi WHERE idProvinsi = @id";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (SqlException)
            {
                Console.WriteLine("Terdapat Error !");
            }
            return View();
        }

        //POST
        public IActionResult Delete(Provinsi provinsi)
        {
            return View();
        }
    }
}
