using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        SqlConnection con = ConnectionString.Connect(@"Server=TIENDATNIIT;Database=BenchmarkORM;Trusted_Connection=True;");
        SqlDataReader _sqlDataReader;
        Stopwatch stopwatch1 = new Stopwatch();
        List<Player> listSkill = new List<Player>();
        // GET api/values
        [HttpGet]
        [EnableCors("AllowMyOrigin")]
        public JsonResult Get()
        {

            var dt = new DataTable();
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select top 100 id,FirstName,LastName,DateOfBirth from [BenchmarkORM].[dbo].[Player]", con);
                _sqlDataReader = cmd.ExecuteReader();
                int id = 0;  var FirstName = string.Empty; var LastName = string.Empty; DateTime birthOfDate;

                if (_sqlDataReader.HasRows)
                {
                    stopwatch1.Start();

                    while (_sqlDataReader.Read())
                    {
                        id = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("id"));
                        FirstName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("FirstName"));
                        LastName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("LastName"));
                        birthOfDate = _sqlDataReader.GetDateTime(_sqlDataReader.GetOrdinal("DateOfBirth"));

                        listSkill.Add(new Player(id,FirstName, LastName, birthOfDate));
                    }
                    stopwatch1.Stop();
                }
                con.Close();
            }

            return Json(new { data = listSkill, consummingTime = stopwatch1.Elapsed });
        }

        // GET api/values/5
        [HttpGet("{PlayerId}")]
        [EnableCors("AllowMyOrigin")]
        public JsonResult Get(int PlayerId)
        {
            var dt = new DataTable();
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select top 100 id,FirstName,LastName,DateOfBirth from [BenchmarkORM].[dbo].[Player] where id = @PlayerId", con);
                cmd.Parameters.Add("@PlayerId", SqlDbType.Int, 80).Value = PlayerId;
                _sqlDataReader = cmd.ExecuteReader();

                int id = 0; var FirstName = string.Empty; var LastName = string.Empty; DateTime birthOfDate;

                if (_sqlDataReader.HasRows)
                {
                    stopwatch1.Start();

                    while (_sqlDataReader.Read())
                    {
                        id = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("id"));
                        FirstName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("FirstName"));
                        LastName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("LastName"));
                        birthOfDate = _sqlDataReader.GetDateTime(_sqlDataReader.GetOrdinal("DateOfBirth"));

                        listSkill.Add(new Player(id, FirstName, LastName, birthOfDate));
                    }
                    stopwatch1.Stop();
                }
                con.Close();
            }

            return Json(new { data = listSkill, consummingTime = stopwatch1.Elapsed });
        }

        // POST api/values
        [HttpPost]
        [EnableCors("AllowMyOrigin")]
        public IActionResult Post([FromBody] Player player)
        {
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into [BenchmarkORM].[dbo].[Player] (FirstName,LastName,DateOfBirth,TeamId) values (@FirstName,@LastName,@DateOfBirth,@TeamId)", con);

                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 80).Value = player.FirstName;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 80).Value = player.LastName;
                cmd.Parameters.Add("@name", SqlDbType.DateTime, 80).Value = player.DateOfBirth;
                cmd.Parameters.Add("@name", SqlDbType.Int, 80).Value = player.TeamId;


                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select top 100 id,FirstName,LastName,DateOfBirth from [BenchmarkORM].[dbo].[Player]", con);
                _sqlDataReader = cmd.ExecuteReader();
                int id = 0; var FirstName = string.Empty; var LastName = string.Empty; DateTime birthOfDate;

                if (_sqlDataReader.HasRows)
                {
                    stopwatch1.Start();

                    while (_sqlDataReader.Read())
                    {
                        id = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("id"));
                        FirstName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("FirstName"));
                        LastName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("LastName"));
                        birthOfDate = _sqlDataReader.GetDateTime(_sqlDataReader.GetOrdinal("DateOfBirth"));

                        listSkill.Add(new Player(id, FirstName, LastName, birthOfDate));
                    }
                    stopwatch1.Stop();
                }
                con.Close();
            }

            return Json(new { data = listSkill, consummingTime = stopwatch1.Elapsed });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [EnableCors("AllowMyOrigin")]
        public JsonResult Put(int skillid, [FromBody] Player player)
        {
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("insert into [BenchmarkORM].[dbo].[Player] (FirstName,LastName,DateOfBirth,TeamId) values (@FirstName,@LastName,@DateOfBirth,@TeamId)", con);
                             
                SqlParameter[] param = {new SqlParameter("@Name","Value"),
                        new SqlParameter("@FirstName",player.FirstName),
                        new SqlParameter("@LastName",player.LastName),
                        new SqlParameter("@DateOfBirth", player.DateOfBirth),
                        new SqlParameter("@TeamId",player.TeamId),                 

                        };
                cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select top 100 id,FirstName,LastName,DateOfBirth from [BenchmarkORM].[dbo].[Player]", con);
                _sqlDataReader = cmd.ExecuteReader();
                int id = 0; var FirstName = string.Empty; var LastName = string.Empty; DateTime birthOfDate;

                if (_sqlDataReader.HasRows)
                {
                    stopwatch1.Start();

                    while (_sqlDataReader.Read())
                    {
                        id = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("id"));
                        FirstName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("FirstName"));
                        LastName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("LastName"));
                        birthOfDate = _sqlDataReader.GetDateTime(_sqlDataReader.GetOrdinal("DateOfBirth"));

                        listSkill.Add(new Player(id, FirstName, LastName, birthOfDate));
                    }
                    stopwatch1.Stop();
                }
                con.Close();
            }          

            return Json(new { data = listSkill, consummingTime = stopwatch1.Elapsed });
        }



        // DELETE api/values/5

        [HttpDelete("{id}")]
        [EnableCors("AllowMyOrigin")]
        public JsonResult Delete(int PlayerId)
        {
            using (con)
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("delete skill where id = @id", con);
                cmd.Parameters.Add("@id", SqlDbType.Int, 80).Value = PlayerId;
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("select top 100 id,FirstName,LastName,DateOfBirth from [BenchmarkORM].[dbo].[Player]", con);
                _sqlDataReader = cmd.ExecuteReader();

                int id = 0; var FirstName = string.Empty; var LastName = string.Empty; DateTime birthOfDate;

                if (_sqlDataReader.HasRows)
                {
                    stopwatch1.Start();

                    while (_sqlDataReader.Read())
                    {
                        id = _sqlDataReader.GetInt32(_sqlDataReader.GetOrdinal("id"));
                        FirstName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("FirstName"));
                        LastName = _sqlDataReader.GetString(_sqlDataReader.GetOrdinal("LastName"));
                        birthOfDate = _sqlDataReader.GetDateTime(_sqlDataReader.GetOrdinal("DateOfBirth"));

                        listSkill.Add(new Player(id, FirstName, LastName, birthOfDate));
                    }
                    stopwatch1.Stop();
                }
                con.Close();
            }

            return Json(new { data = listSkill, consummingTime = stopwatch1.Elapsed });
        }
    }
}
