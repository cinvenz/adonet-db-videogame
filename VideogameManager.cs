using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class VideogameManager
    {
        string connStr;

        public VideogameManager(string connStr)
        {
            this.connStr = connStr;
        }

        public List<Videogame> GetVideogameByNameLike(string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();

                var query = "SELECT id, name, release_date, date_of_birth ,software_house_id"
                    + " FROM videogame"
                    + $" WHERE name LIKE @NameLike"
                    + " ORDER BY name";

                using var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@NameLike", $"%{likeString}%");

                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var release_dateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(release_dateIdx);

                    var softwareHouseIdx = reader.GetOrdinal("software_house_id");
                    var software_house_id = reader.GetInt64(softwareHouseIdx);

                    var v = new Videogame(id, name, release_date, software_house_id);
                    videogames.Add(v);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return videogames;
        }

        public List<Videogame> GetVideogameByIdLike(string likeString)
        {
            using var conn = new SqlConnection(connStr);
            var videogames = new List<Videogame>();

            try
            {
                conn.Open();

                var query = "SELECT id, name, release_date, date_of_birth ,software_house_id"
                    + " FROM videogame"
                    + $" WHERE name LIKE @IdLike"
                    + " ORDER BY id";

                using var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@IdLike", $"{likeString}");

                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var idIdx = reader.GetOrdinal("id");
                    var id = reader.GetInt64(idIdx);

                    var nameIdx = reader.GetOrdinal("name");
                    var name = reader.GetString(nameIdx);

                    var release_dateIdx = reader.GetOrdinal("release_date");
                    var release_date = reader.GetDateTime(release_dateIdx);

                    var softwareHouseIdx = reader.GetOrdinal("software_house_id");
                    var software_house_id = reader.GetInt64(softwareHouseIdx);

                    var v = new Videogame(id, name, release_date, software_house_id);
                    videogames.Add(v);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return videogames;
        }

        public void AddVideogame(Videogame videogame)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    var query = "INSERT INTO videogame (name, release_date, software_house_id)" +
                            "VALUES (@Name, @ReleaseDate, @SoftwareHouse)";
                    using var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", videogame.Name);
                    cmd.Parameters.AddWithValue("@ReleaseDate", videogame.ReleaseDate);
                    cmd.Parameters.AddWithValue("@SoftwareHouse", videogame.SoftwareHouse);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Il videogame è stato aggiunto");

                    Console.WriteLine("Commit");
                    tran.Commit();
                }
                catch
                {
                    Console.WriteLine("Rollback");
                    tran.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteVideogame(long id)
        {
            using var conn = new SqlConnection(connStr);

            try
            {
                conn.Open();
                using var tran = conn.BeginTransaction();

                try
                {
                    var query = "DELETE FROM videogame WHERE id = @Id";
                    using var cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Il videogame è stato cancellato correttamente");

                    Console.WriteLine("Commit");
                    tran.Commit();
                }
                catch
                {
                    Console.WriteLine("Rollback");
                    tran.Rollback();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
