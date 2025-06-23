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
                cmd.Parameters.AddWithValue("@gymname", gymtemp.Gym_name);
                cmd.Parameters.AddWithValue("@streetaddress", gymtemp.Streetaddress);
                cmd.Parameters.AddWithValue("@countryID", gymtemp.Country_id);
                cmd.Parameters.AddWithValue("@cityID", gymtemp.City_id);
                cmd.Parameters.AddWithValue("@suburbID", gymtemp.Suburb_id);
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

        public int UpdateCountryName(int countryID, string countryname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.country SET countryname = @countryname WHERE countryID = @countryID", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countryname);
                cmd.Parameters.AddWithValue("@countryID", countryID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertCountry(Country countrytemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.country (countryname) VALUES (@countryname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countrytemp.Country_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteCountryByName(string countryname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.country WHERE countryname = @countryname", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countryname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();
            string sqlString = "SELECT * FROM Location.city";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int cityid = Convert.ToInt32(reader["cityID"]);
                        string cityname = reader["cityname"].ToString();
                        cities.Add(new City(cityid, cityname));
                    }
                }

            }
            return cities;

        }

        public int UpdateCityName(int cityID, string cityname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.city SET cityname = @cityname WHERE cityID = @cityID", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", cityname);
                cmd.Parameters.AddWithValue("@cityID", cityID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertCity(City citytemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.city (cityname) VALUES (@cityname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", citytemp.City_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteCityByName(string cityname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.city WHERE cityname = @cityname", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", cityname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Suburb> GetAllSuburbs()
        {
            List<Suburb> suburbs = new List<Suburb>();
            string sqlString = "SELECT * FROM Location.suburb";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int suburbid = Convert.ToInt32(reader["suburbID"]);
                        string suburbname = reader["suburbname"].ToString();
                        suburbs.Add(new Suburb(suburbid, suburbname));
                    }
                }

            }
            return suburbs;

        }

        public int UpdateSuburbName(int suburbID, string suburbname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.suburb SET suburbname = @suburbname WHERE suburbID = @suburbID", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbname);
                cmd.Parameters.AddWithValue("@suburbID", suburbID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertSuburb(Suburb suburbtemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.suburb (suburbname) VALUES (@suburbname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbtemp.Suburb_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteSuburbByName(string suburbname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.suburb WHERE suburbname = @suburbname", conn))
            {
                cmd.Parameters.AddWithValue("@suburb", suburbname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Instructor> GetAllInstructors()
        {
            List<Instructor> instructors = new List<Instructor>();
            string sqlString = "SELECT * FROM Session.instructor";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int suburbid = Convert.ToInt32(reader["suburbID"]);
                        string suburbname = reader["suburbname"].ToString();
                        suburbs.Add(new Suburb(suburbid, suburbname));
                    }
                }

            }
            return suburbs;

        }

        public int UpdateSuburbName(int suburbID, string suburbname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.suburb SET suburbname = @suburbname WHERE suburbID = @suburbID", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbname);
                cmd.Parameters.AddWithValue("@suburbID", suburbID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertSuburb(Suburb suburbtemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.suburb (suburbname) VALUES (@suburbname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbtemp.Suburb_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteSuburbByName(string suburbname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.suburb WHERE suburbname = @suburbname", conn))
            {
                cmd.Parameters.AddWithValue("@suburb", suburbname);
                return cmd.ExecuteNonQuery();
            }
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
