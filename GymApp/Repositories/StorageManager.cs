using GymApp.DBFile.Model;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString) //try catch to test the sql connection to my database
        {
            try//If the connection was successful
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Connection successful");

            }
            catch (SqlException e)//If the connection was not successful
            {
                Console.WriteLine("Connection NOT successful\n");
                Console.WriteLine(e.Message);

            }
            catch (Exception ex)//If any other error occured
            {
                Console.WriteLine("An error occured\n");
                Console.WriteLine(ex.Message);

            }
        }

        

        public List<Gym> GetAllGyms() //Used to gather all gym records from my sql database
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
                        Int64 phonenumber = Convert.ToInt64(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int role_id = Convert.ToInt32(reader["roleID"]);

                        gyms.Add(new Gym(gymid, gymname, streetaddress, countryid, cityid, suburbid, phonenumber, emailaddress, username, password, role_id));
                    }
                }

            }
            return gyms;

        }

        public int UpdateGymName(int gymID, string gymname) //Used to update the gymname field from gym records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Gym.gyms SET gymname = @gymname WHERE gymID = @gymID", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", gymname);
                cmd.Parameters.AddWithValue("@gymID", gymID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertGym(Gym gymtemp) //Used to insert new gyms into my database
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

        public int DeleteGymByName(string gymname) //Used to delete gyms from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Gym.gyms WHERE gymname = @gymname", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", gymname);
                    
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Record deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No record found with that ID.");
                        }
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 547) // Foreign key violation
                        {
                            Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                        }
                        else
                        {
                            Console.WriteLine($"SQL Error: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"General Error: {ex.Message}");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                return 0;

            }
        }

        public List<Country> GetAllCountries()//Used to gather all country records from my sql database
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

        public int UpdateCountryName(int countryID, string countryname)//Used to update the countryname field from country records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.country SET countryname = @countryname WHERE countryID = @countryID", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countryname);
                cmd.Parameters.AddWithValue("@countryID", countryID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertCountry(Country countrytemp)//Used to insert new countries into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.country (countryname) VALUES (@countryname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countrytemp.Country_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteCountryByName(string countryname)//Used to delete countries from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.country WHERE countryname = @countryname", conn))
            {
                cmd.Parameters.AddWithValue("@countryname", countryname);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<City> GetAllCities()//Used to gather all city records from my sql database
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

        public int UpdateCityName(int cityID, string cityname)//Used to update the cityname field from city records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.city SET cityname = @cityname WHERE cityID = @cityID", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", cityname);
                cmd.Parameters.AddWithValue("@cityID", cityID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertCity(City citytemp)//Used to insert new cities into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.city (cityname) VALUES (@cityname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", citytemp.City_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteCityByName(string cityname)//Used to delete cities from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.city WHERE cityname = @cityname", conn))
            {
                cmd.Parameters.AddWithValue("@cityname", cityname);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<Suburb> GetAllSuburbs()//Used to gather all suburb records from my sql database
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

        public int UpdateSuburbName(int suburbID, string suburbname)//Used to update the suburbname field from suburb records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Location.suburb SET suburbname = @suburbname WHERE suburbID = @suburbID", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbname);
                cmd.Parameters.AddWithValue("@suburbID", suburbID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertSuburb(Suburb suburbtemp)//Used to insert new suburbs into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Location.suburb (suburbname) VALUES (@suburbname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@suburbname", suburbtemp.Suburb_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteSuburbByName(string suburbname)//Used to delete suburb records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Location.suburb WHERE suburbname = @suburbname", conn))
            {
                cmd.Parameters.AddWithValue("@suburb", suburbname);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<Instructor> GetAllInstructors()//Used to gather all instructor records from my sql database
        {
            List<Instructor> instructors = new List<Instructor>();
            string sqlString = "SELECT * FROM Session.instructor";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int instructorid = Convert.ToInt32(reader["instructorID"]);
                        string instructorname = reader["instructorname"].ToString();
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        Int64 phonenumber = Convert.ToInt64(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["roleID"]);
                        instructors.Add(new Instructor(instructorid, instructorname, gymID, phonenumber, emailaddress, username, password, roleID));
                    }
                }

            }
            return instructors;

        }

        public int UpdateInstructorName(int instructorID, string instructorname)//Used to update the instructorname field from instructor records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.instructor SET instructorname = @instructorname WHERE instructorID = @instructorID", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructorname);
                cmd.Parameters.AddWithValue("@instructorID", instructorID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertInstructor(Instructor instructortemp)//Used to insert new instructors into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.instructor (instructorname, gymID, phonenumber, emailaddress, username, password, roleID) VALUES (@instructorname, @gymID, @phonenumber, @emailaddress, @username, @password, @4); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructortemp.Instructor_name);
                cmd.Parameters.AddWithValue("@gymID", instructortemp.Gym_id);
                cmd.Parameters.AddWithValue("@phonenumber", instructortemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", instructortemp.Emailaddress);
                cmd.Parameters.AddWithValue("@username", instructortemp.User_name);
                cmd.Parameters.AddWithValue("@password", instructortemp.Password);
                cmd.Parameters.AddWithValue("@4", instructortemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteInstructorByName(string instructorname)//Used to delete instructor records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.instructor WHERE instructorname = @instructorname", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructorname);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }
       
        public List<ClassType> GetAllClasstypes()//Used to gather all classtype records from my sql database
        {
            List<ClassType> classtypes = new List<ClassType>();
            string sqlString = "SELECT * FROM Session.classtype";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int classtypeid = Convert.ToInt32(reader["classtypeID"]);
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        classtypes.Add(new ClassType(classtypeid, classtype, classprice));
                    }
                }

            }
            return classtypes;

        }

        public int UpdateClasstypeName(int classtypeID, string classtype)//Used to update the classtypename field from classtype records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.classtype SET classtype = @classtype WHERE classtypeID = @classtypeID", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtype);
                cmd.Parameters.AddWithValue("@classtypeID", classtypeID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertClasstype(ClassType classtypetemp)//Used to insert new classtypes into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.classtype (classtype) VALUES (@classtype); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtypetemp.Classtype);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteClasstype(string classtype)//Used to delete classtype records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.classtype WHERE classtype = @classtype", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtype);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<Member> GetAllMembers()//Used to gather all member records from my sql database
        {
            List<Member> members = new List<Member>();
            string sqlString = "SELECT * FROM Member.members";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int memberID = Convert.ToInt32(reader["memberID"]);
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["roleID"]);
                        members.Add(new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID));
                    }
                }

            }
            return members;

        }

        public int UpdateMemberFirstName(int memberID, string firstname)//Used to update the firstname field from member records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Member.members SET firstname = @firstname WHERE memberID = @memberID", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertMember(Member membertemp)//Used to insert new members into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Member.members (firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID) VALUES (@firstname, @lastname, @phonenumber, @emailaddress, @gymID, @username, @password, @1); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", membertemp.Firstname);
                cmd.Parameters.AddWithValue("@lastname", membertemp.Lastname);
                cmd.Parameters.AddWithValue("@phonenumber", membertemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", membertemp.Emailaddress);
                cmd.Parameters.AddWithValue("@gymID", membertemp.Gym_id);
                cmd.Parameters.AddWithValue("@username", membertemp.User_name);
                cmd.Parameters.AddWithValue("@password", membertemp.Password);
                cmd.Parameters.AddWithValue("@1", membertemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteMemberByName(string firstname, string lastname)//Used to delete member records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Member.members WHERE firstname = @firstname AND lastname = @lastname", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<Role> GetAllRoles()//Used to gather all role records from my sql database
        {
            List<Role> roles = new List<Role>();
            string sqlString = "SELECT * FROM Role.roles";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int roleid = Convert.ToInt32(reader["roleID"]);
                        string rolename = reader["rolename"].ToString();
                        roles.Add(new Role(roleid, rolename));
                    }
                }

            }
            return roles;

        }

        public int UpdateRoleName(int roleID, string rolename)//Used to update the rolename field from role records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Role.roles SET rolename = @rolesname WHERE roleID = @roleID", conn))
            {
                cmd.Parameters.AddWithValue("@rolename", rolename);
                cmd.Parameters.AddWithValue("@roleID", roleID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertRole(Role roletemp)//Used to insert new roles into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Role.roles (rolename) VALUES (@rolename); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@rolename", roletemp.Rolename);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteRoleByName(string rolename)//Used to delete role records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Role.roles WHERE rolename = @rolename", conn))
            {
                cmd.Parameters.AddWithValue("@rolename", rolename);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public List<Sessionbooking> GetAllSessions()//Used to gather all session records from my sql database
        {
            List<Sessionbooking> sessionbookings = new List<Sessionbooking>();
            string sqlString = "SELECT * FROM Session.sessionbooking";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int sessionID = Convert.ToInt32(reader["sessionID"]);
                        int instructorID = Convert.ToInt32(reader["instructorID"]);
                        int classtypeID = Convert.ToInt32(reader["classtypeID"]);
                        int memberID = Convert.ToInt32(reader["memberID"]);
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);

                        sessionbookings.Add(new Sessionbooking(sessionID, instructorID, classtypeID, memberID, gymID, sessiondate));
                    }
                }

            }
            return sessionbookings;

        }

        public int UpdateSessionDate(int sessionID, DateTime sessiondate)//Used to update the sessiondate field from session records
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.sessionbooking SET sessiondate = @sessiondate WHERE sessionID = @sessionID", conn))
            {
                cmd.Parameters.AddWithValue("@sessiondate", sessiondate);
                cmd.Parameters.AddWithValue("@sessionID", sessionID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertSession(Sessionbooking sessionbookingtemp)//Used to insert new sessions into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.sessionbooking (instructorID, classtypeID, memberID, gymID, sessiondate) VALUES (@instructorID, @classtypeID, @memberID, @gymID, @sessiondate); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructorID", sessionbookingtemp.Instructor_id);
                cmd.Parameters.AddWithValue("@classtypeID", sessionbookingtemp.Classtype_id);
                cmd.Parameters.AddWithValue("@memberID", sessionbookingtemp.Member_id);
                cmd.Parameters.AddWithValue("@gymID", sessionbookingtemp.Gym_id);
                cmd.Parameters.AddWithValue("@sessiondate", sessionbookingtemp.Sessiondate);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteSessionByID(int sessionID)//Used to delete session records from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.sessionbooking WHERE sessionID = @sessionID", conn))
            {
                cmd.Parameters.AddWithValue("@sessionID", sessionID);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        

        public bool IsUserValid(string username, int password) // Used to check if what the user inputted was a valid username and password
        {
            var query = "SELECT * FROM Member.members WHERE username = @username AND password = @password";
            var command = new SqlCommand(query, conn);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);


            bool hasRows=false;
            try
            {
                using (var reader = command.ExecuteReader())
                {
                    hasRows = reader.HasRows;
                }

                return hasRows;
            }
            catch (SqlException e)
            {
                Console.WriteLine("sql error\n");
                Console.WriteLine(e.Message);
                return hasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured\n");
                Console.WriteLine(ex.Message);
                return hasRows;
            }

        }

        public int GetUserRole(string username, int password) //This is used to get the role from the inputted username and password from the user
        {
            var query = "SELECT roleID FROM Member.members WHERE username = @username AND password = @password UNION " +
                "SELECT roleID FROM Gym.gyms WHERE username = @username AND password = @password UNION " +
                "SELECT roleID FROM Session.instructor WHERE username = @username AND password = @password";

            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["roleID"]);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public int GetMemberID(string username, int password)//This is used to get the ID from the member
        {
            var query = "SELECT memberID FROM Member.members WHERE username = @username AND password = @password";

            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["memberID"]);
                    }
                    else
                    {
                        return 0;
                    }
                }

                
            }
            
        }

        public int GetGymID(string username, int password)//Used to get the ID from the gym
        {
            var query = "SELECT gymID FROM Gym.gyms WHERE username = @username AND password = @password";

            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["gymID"]);
                    }
                    else
                    {
                        return 0;
                    }
                }


            }

        }

        public int GetInstructorID(string username, int password)//Used to get the ID from the instructor
        {
            var query = "SELECT instructorID FROM Session.instructor WHERE username = @username AND password = @password";

            using (var command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["instructorID"]);
                    }
                    else
                    {
                        return 0;
                    }
                }


            }

        }

        public void ViewMemberSessions(int memberID) //Used to view all sessions that the member is signed up for from my database
        {

            string sqlstring = "Select Member.members.firstname, Member.members.lastname, Gym.gyms.gymname, Session.instructor.instructorname, Session.classtype.classtype, Session.classtype.classprice, Session.sessionbooking.sessiondate From Session.sessionbooking, Session.instructor, Session.classtype, Member.members, Gym.gyms Where Session.sessionbooking.instructorID = Session.instructor.instructorID And Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.sessionbooking.memberID = Member.members.memberID And Session.sessionbooking.gymID = Gym.gyms.gymID And Member.members.memberID = @memberID;";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {

                cmd.Parameters.AddWithValue("@memberID", memberID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string gymname = reader["gymname"].ToString();
                        string instructorname = reader["instructorname"].ToString();
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}, {gymname}, {instructorname}, {classtype}, {classprice}, {sessiondate}");
                        Console.WriteLine();
                        
                        
                    }
                    
                }

            }

        }

        public void ViewGymSessions(int gymID) //Used to view all sessions that the gym is hosting from my database
        {

            string sqlstring = "Select Member.members.firstname, Member.members.lastname, Gym.gyms.gymname, Session.instructor.instructorname, Session.classtype.classtype, Session.classtype.classprice, Session.sessionbooking.sessiondate From Session.sessionbooking, Session.instructor, Session.classtype, Member.members, Gym.gyms Where Session.sessionbooking.instructorID = Session.instructor.instructorID And Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.sessionbooking.memberID = Member.members.memberID And Session.sessionbooking.gymID = Gym.gyms.gymID And Gym.gyms.gymID = @gymID;";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {

                cmd.Parameters.AddWithValue("@gymID", gymID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string gymname = reader["gymname"].ToString();
                        string instructorname = reader["instructorname"].ToString();
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}, {gymname}, {instructorname}, {classtype}, {classprice}, {sessiondate}");
                        Console.WriteLine();


                    }

                }

            }

        }

        public int InsertGymSession(Sessionbooking sessionbookingtemp) //Used to insert new sessions on behalf of the gym
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.sessionbooking (instructorID, classtypeID, memberID, gymID, sessiondate) VALUES (@instructorID, @classtypeID, @memberID, @gymID, @sessiondate); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructorID", sessionbookingtemp.Instructor_id);
                cmd.Parameters.AddWithValue("@classtypeID", sessionbookingtemp.Classtype_id);
                cmd.Parameters.AddWithValue("@memberID", sessionbookingtemp.Member_id);
                cmd.Parameters.AddWithValue("@gymID", sessionbookingtemp.Gym_id);
                cmd.Parameters.AddWithValue("@sessiondate", sessionbookingtemp.Sessiondate);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void ViewGymMembers(int gymID) //Used to view all members that belong to a certain gym from my databse
        {
            string sqlstring = "Select Member.members.firstname, Member.members.lastname From Member.members Where gymID = @gymID";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {

                cmd.Parameters.AddWithValue("@gymID", gymID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}");
                        Console.WriteLine();


                    }

                }

            }
        }

        public int DeleteGymMember(string firstname, string lastname, int gymID) //Used to delete members that belong to a certain gym from my database
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Member.members WHERE firstname = @firstname AND lastname = @lastname And gymID = @gymID", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@gymID", gymID);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public void ViewGymInstructors(int gymID) //Used to view all instructors that belong to a certain gym
        {
            string sqlstring = "Select Session.instructor.instructorname From Session.instructor Where gymID = @gymID";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {

                cmd.Parameters.AddWithValue("@gymID", gymID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string firstname = reader["instructorname"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}");
                        Console.WriteLine();


                    }

                }

            }
        }

        public int DeleteGymInstructor(string instructorname, int gymID) //Used to delete an instructor that belongs to a certain gym from my databsae
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.instructor WHERE instructorname = @instructorname And gymID = @gymID", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructorname);
                cmd.Parameters.AddWithValue("@gymID", gymID);
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No record found with that ID.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 547) // Foreign key violation
                    {
                        Console.WriteLine("Error: Cannot delete this record because it is referenced in another table.");
                    }
                    else
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return 0;
            }
        }

        public void ViewInstructorSessions(int instructorID) //Used to view all sessions that an instructor is hosting
        {

            string sqlstring = "Select Member.members.firstname, Member.members.lastname, Gym.gyms.gymname, Session.instructor.instructorname, Session.classtype.classtype, Session.classtype.classprice, Session.sessionbooking.sessiondate From Session.sessionbooking, Session.instructor, Session.classtype, Member.members, Gym.gyms Where Session.sessionbooking.instructorID = Session.instructor.instructorID And Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.sessionbooking.memberID = Member.members.memberID And Session.sessionbooking.gymID = Gym.gyms.gymID And Session.instructor.instructorID = @instructorID;";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {

                cmd.Parameters.AddWithValue("@instructorID", instructorID);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string gymname = reader["gymname"].ToString();
                        string instructorname = reader["instructorname"].ToString();
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}, {gymname}, {instructorname}, {classtype}, {classprice}, {sessiondate}");
                        Console.WriteLine();


                    }

                }

            }

        }

        public int RegisterMember(Member membertemp) //Made to register new member's into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Member.members (firstname, lastname,phonenumber, emailaddress, username, password, roleID) VALUES (@firstname, @lastname, @phonenumber, @emailaddress, @username, @password, @1); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", membertemp.Firstname);
                cmd.Parameters.AddWithValue("@lastname", membertemp.Lastname);
                cmd.Parameters.AddWithValue("@phonenumber", membertemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", membertemp.Emailaddress);
                cmd.Parameters.AddWithValue("@username", membertemp.User_name);
                cmd.Parameters.AddWithValue("@password", membertemp.Password);
                cmd.Parameters.AddWithValue("@1", membertemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int RegisterGym(Gym gymtemp)//Made to register new gym's into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Gym.gyms (gymname, streetaddress, countryID, cityID, suburbID, phonenumber, emailaddress, password, roleID) " +
                "VALUES (@gymname, @streetaddress, @countryID, @cityID, @suburbID, @phonenumber, @emailaddress, @password, @2); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@gymname", gymtemp.Gym_name);
                cmd.Parameters.AddWithValue("@streetaddress", gymtemp.Streetaddress);
                cmd.Parameters.AddWithValue("@countryID", gymtemp.Country_id);
                cmd.Parameters.AddWithValue("@cityID", gymtemp.City_id);
                cmd.Parameters.AddWithValue("@suburbID", gymtemp.Suburb_id);
                cmd.Parameters.AddWithValue("@phonenumber", gymtemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", gymtemp.Emailaddress);
                cmd.Parameters.AddWithValue("@password", gymtemp.Password);
                cmd.Parameters.AddWithValue("@2", gymtemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int RegisterAdmin(Member membertemp)//Made to register new admin's into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Member.members (firstname, lastname,phonenumber, emailaddress, username, password, roleID) VALUES (@firstname, @lastname, @phonenumber, @emailaddress, @username, @password, @3); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", membertemp.Firstname);
                cmd.Parameters.AddWithValue("@lastname", membertemp.Lastname);
                cmd.Parameters.AddWithValue("@phonenumber", membertemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", membertemp.Emailaddress);
                cmd.Parameters.AddWithValue("@username", membertemp.User_name);
                cmd.Parameters.AddWithValue("@password", membertemp.Password);
                cmd.Parameters.AddWithValue("@3", membertemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int RegisterInstructor(Instructor instructortemp)//Made to register new instructors's into my database
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.instructor (instructorname, gymID, phonenumber, emailaddress, username, password, roleID) VALUES (@instructorname, @gymID, @phonenumber, @emailaddress, @username, @password, @4); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructortemp.Instructor_name);
                cmd.Parameters.AddWithValue("@gymID", instructortemp.Gym_id);
                cmd.Parameters.AddWithValue("@phonenumber", instructortemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", instructortemp.Emailaddress);
                cmd.Parameters.AddWithValue("@username", instructortemp.User_name);
                cmd.Parameters.AddWithValue("@password", instructortemp.Password);
                cmd.Parameters.AddWithValue("@4", instructortemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<Member> Simple1QryMemberName() //Created to gather records from my database according to the criteria of simpleqry1
        {
            List<Member> members = new List<Member>();
            string sqlstring = "SELECT * FROM Member.members";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("MemberID: Firstname: Lastname: ");
                    while (reader.Read())
                    {
                        int memberID = Convert.ToInt32(reader["memberID"]);
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["roleID"]);
                        members.Add(new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID));
                    }
                }

            }
            return members;
        }

        public List<ClassType> Simple2QryClassTypes()//Created to gather records from my database according to the criteria of simpleqry2
        {
            List<ClassType> classtypes = new List<ClassType>();
            string sqlstring = "Select * From Session.classtype";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("ClassType:  ClassPrice: ");
                    while (reader.Read())
                    {
                        int classtypeID = Convert.ToInt32(reader["classtypeID"]);
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        classtypes.Add(new ClassType(classtypeID, classtype, classprice));
                    }
                }

            }
            return classtypes;
        }

        public List<Member> Simple3QryMemberContactDetails()//Created to gather records from my database according to the criteria of simpleqry3
        {
            List<Member> members = new List<Member>();
            string sqlstring = "SELECT * FROM Member.members";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("MemberID: Firstname: Lastname: Phonenumber: Emailaddress: ");
                    while (reader.Read())
                    {
                        int memberID = Convert.ToInt32(reader["memberID"]);
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["roleID"]);
                        members.Add(new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID));
                    }
                }

            }
            return members;
        }


        public void Simple4QryGymLocation()//Created to gather records from my database according to the criteria of simpleqry4
        {
            
            string sqlstring = "Select Gym.gyms.gymname, Gym.gyms.streetaddress, Location.suburb.suburbname, Location.city.cityname, Location.country.countryname From Gym.gyms, Location.suburb, Location.city, Location.country Where Gym.gyms.suburbID = Location.suburb.suburbID And Gym.gyms.cityID = Location.city.cityID And Gym.gyms.countryID = Location.country.countryID;";
            
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Gym: StreetAddress: Suburb: City: Country: ");
                    while (reader.Read())
                    {
                        string gymname = reader["gymname"].ToString();
                        string streetaddress = reader["streetaddress"].ToString();
                        string suburbname = reader["suburbname"].ToString();
                        string cityname = reader["cityname"].ToString();
                        string countryname = reader["countryname"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"{gymname}, {streetaddress}, {suburbname}, {cityname}, {countryname}");
                        Console.WriteLine();
                    }
                }
            }
        }

        public void Simple5QrySessionDetails()//Created to gather records from my database according to the criteria of simpleqry5
        {

            string sqlstring = "Select Member.members.firstname, Member.members.lastname, Gym.gyms.gymname, Session.instructor.instructorname, Session.classtype.classtype, Session.classtype.classprice, Session.sessionbooking.sessiondate From Session.sessionbooking, Session.instructor, Session.classtype, Member.members, Gym.gyms Where Session.sessionbooking.instructorID = Session.instructor.instructorID And Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.sessionbooking.memberID = Member.members.memberID And Session.sessionbooking.gymID = Gym.gyms.gymID;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Firstname:  Lastname:  Gym:  Instructor:  ClassType:  ClassPrice:  Sessiondate: ");
                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string gymname = reader["gymname"].ToString();
                        string instructorname = reader["instructorname"].ToString();
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}, {gymname}, {instructorname}, {classtype}, {classprice}, {sessiondate}");
                        Console.WriteLine();
                    }
                }

            }
            
        }

        public void Advanced1QryClassesUnder31()//Created to gather records from my database according to the criteria of advancedquery1
        {
            string sqlstring = "Select DISTINCT classtype, classprice From Session.classtype Where classprice <= '30' Order By classprice ASC;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("ClassType:  ClassPrice: ");
                    while (reader.Read())
                    {
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        Console.WriteLine();
                        Console.WriteLine($"{classtype}, {classprice}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Advanced2QryInstructorsStartingWithA()//Created to gather records from my database according to the criteria of advancedquery2
        {
            string sqlstring = "Select DISTINCT si.instructorname From Session.instructor as si, Session.classtype as sc, Session.sessionbooking as ss Where si.instructorID = ss.instructorID And si.instructorname LIKE 'a%';";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Instructors: ");
                    while (reader.Read())
                    {
                        string instructorname = reader["instructorname"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"{instructorname}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Advanced3QryTop5MostExpensiveClasses()//Created to gather records from my database according to the criteria of advancedquery3
        {
            string sqlstring = "Select Top 5 classtype, classprice From Session.classtype Order By classprice DESC;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("ClassType:  ClassPrice: ");
                    while (reader.Read())
                    {
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                        Console.WriteLine();
                        Console.WriteLine($"{classtype}, {classprice}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Advanced4QryMembersWithGmailOrOutlook()//Created to gather records from my database according to the criteria of advancedquery4
        {
            string sqlstring = "Select firstname, lastname, emailaddress From Member.members Where emailaddress LIKE '%gmail%' OR emailaddress LIKE '%outlook%';";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Firstname:  Lastname:  Emailaddress: ");
                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string emailaddress = reader["emailaddress"].ToString();
                        Console.WriteLine();
                        Console.WriteLine($"{firstname}, {lastname}, {emailaddress}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Advanced5QrySessionsAfter27April()//Created to gather records from my database according to the criteria of advancedquery5
        {
            string sqlstring = "Select sessionID, sessiondate From Session.sessionbooking Where sessiondate > '2025-04-27 14:00:00.123' Order By sessionID;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("SessionID:  SessionDate: ");
                    while (reader.Read())
                    {
                        int sessionID = Convert.ToInt32(reader["sessionID"]);
                        DateTime sessiondate = Convert.ToDateTime(reader["sessiondate"]);
                        Console.WriteLine();
                        Console.WriteLine($"{sessionID}, {sessiondate}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Complex1QryInstructorsWithSessions()//Created to gather records from my database according to the criteria of complexqry1
        {
            string sqlstring = "Select Session.instructor.instructorname, COUNT(sessionID) as sessioncount From Session.sessionbooking, Session.instructor WHERE Session.sessionbooking.instructorID = Session.instructor.instructorID Group By Session.instructor.instructorname;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Instructorname:  sessioncount: ");
                    while (reader.Read())
                    {
                        string instructorname = reader["instructorname"].ToString();
                        int sessioncount = Convert.ToInt32(reader["sessioncount"]);
                        Console.WriteLine();
                        Console.WriteLine($"{instructorname}, {sessioncount}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Complex2QryRevenuePerClassType()//Created to gather records from my database according to the criteria of complexqry2
        {
            string sqlstring = "Select Session.classtype.classtype, SUM(Session.classtype.classprice) as totalrevenue, AVG(Session.classtype.classprice) as averagerevenue From Session.sessionbooking, Session.classtype Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID Group By Session.classtype.classtype;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Class type: Total Revenue: Average Revenue: ");
                    while (reader.Read())
                    {
                        string classtype = reader["classtype"].ToString();
                        int totalrevenue = Convert.ToInt32(reader["totalrevenue"]);
                        int averagerevenue = Convert.ToInt32(reader["averagerevenue"]);
                        Console.WriteLine();
                        Console.WriteLine($"{classtype}, {totalrevenue}, {averagerevenue}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Complex3QrySessionsUnder30()//Created to gather records from my database according to the criteria of complexqry3
        {
            string sqlstring = "Select COUNT(Session.sessionbooking.sessionID) as sessionsunder30dollars From Session.sessionbooking, Session.classtype Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.classtype.classprice < '30';";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Sessions Under $30: ");
                    while (reader.Read())
                    {
                        int sessionsunder30dollars = Convert.ToInt32(reader["sessionsunder30dollars"]);
                        Console.WriteLine();
                        Console.WriteLine($"{sessionsunder30dollars}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Complex4QryGymRevenue()//Created to gather records from my database according to the criteria of complexqry4
        {
            string sqlstring = "Select Gym.gyms.gymname as Gym, SUM(Session.classtype.classprice) as totalrevenue, AVG(Session.classtype.classprice) as averagerevenuepersession From Session.sessionbooking, Session.classtype, Gym.gyms Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID And Session.sessionbooking.gymID = Gym.gyms.gymID Group By Gym.gyms.gymname;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Gym:  Total Revenue:  Average Revenue Per Session: ");
                    while (reader.Read())
                    {
                        string Gym = reader["Gym"].ToString();
                        int totalrevenue = Convert.ToInt32(reader["totalrevenue"]);
                        int averagerevenuepersession = Convert.ToInt32(reader["averagerevenuepersession"]);
                        Console.WriteLine();
                        Console.WriteLine($"{Gym}, {totalrevenue}, {averagerevenuepersession}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void Complex5QryMemberSessionBooked()//Created to gather records from my database according to the criteria of complexqry5
        {
            string sqlstring = "Select Member.members.firstname as membername, Member.members.emailaddress as emailaddress, COUNT(sessionID) as sessionsbooked From Session.sessionbooking, Member.members Where Session.sessionbooking.memberID = Member.members.memberID Group By Member.members.emailaddress, Member.members.firstname;";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine();
                    Console.WriteLine("Membername:  Emailaddress:  Sessionsbooked: ");
                    while (reader.Read())
                    {
                        string membername = reader["membername"].ToString();
                        string emailaddress = reader["emailaddress"].ToString();
                        int sessionsbooked = Convert.ToInt32(reader["sessionsbooked"]);
                        Console.WriteLine();
                        Console.WriteLine($"{membername}, {emailaddress}, {sessionsbooked}");
                        Console.WriteLine();
                    }
                }

            }
        }

        public void CloseConnection() //Used to close the connection to my database
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }

    }
}
