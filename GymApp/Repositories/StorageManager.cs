using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using GymApp.DBFile.Model;
using Microsoft.Identity.Client;
using System.Data;

namespace GymApp
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successful");

            }
            catch (SqlException e)
            {
                Console.WriteLine("Connection NOT successful\n");
                Console.WriteLine(e.Message);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured\n");
                Console.WriteLine(ex.Message);

            }
        }

        public List<Gym> GetAllGyms()
        {
            List<Gym> gyms = new List<Gym>();
            string sqlString = "SELECT * FROM Gym.gyms";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int gymid = Convert.ToInt32(reader["gymID"]);
                        string gymname = reader["gymname"].ToString();
                        string streetaddress = reader["streetaddress"].ToString();
                        int countryid = Convert.ToInt32(reader["countryID"]);
                        int cityid = Convert.ToInt32(reader["cityID"]);
                        int suburbid = Convert.ToInt32(reader["suburbID"]);
                        gyms.Add(new Gym(gymid, gymname, streetaddress, countryid, cityid, suburbid));
                    }
                }

            }
            return gyms;

        }

        public int UpdateGymName(int gymID, string gymname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Gym.gyms SET gymname = @gymname WHERE gymID = @gymID", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", gymname);
                cmd.Parameters.AddWithValue("@gymID", gymID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertGym(Gym gymtemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Gym.gyms (gymname, streetaddress, countryID, cityID, suburbID) VALUES (@gymname, @streetaddress, @countryID, @cityID, @suburbID); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", "@streetaddress", gymtemp.Gym_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteGymByName(string gymname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Gym.gyms WHERE gymname = @gymname", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", gymname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = new List<Country>();
            string sqlString = "SELECT * FROM Location.country";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int countryid = Convert.ToInt32(reader["countryID"]);
                        string countryname = reader["countryname"].ToString();
                        countries.Add(new Country(countryid, countryname));
                    }
                }

            }
            return countries;

        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

    }
}
