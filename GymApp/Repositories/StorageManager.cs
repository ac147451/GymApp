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
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int role_id = Convert.ToInt32(reader["roleID"]);

                        gyms.Add(new Gym(gymid, gymname, streetaddress, countryid, cityid, suburbid, phonenumber, emailaddress, password, role_id));
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
                        int instructorid = Convert.ToInt32(reader["instructorID"]);
                        string instructorname = reader["instructorname"].ToString();
                        int gymID = Convert.ToInt32(reader["gymID"]);
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["role_id"]);
                        instructors.Add(new Instructor(instructorid, instructorname, gymID, phonenumber, emailaddress, username, password, roleID));
                    }
                }

            }
            return instructors;

        }

        public int UpdateInstructorName(int instructorID, string instructorname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.instructor SET instructorname = @instructorname WHERE instructorID = @instructorID", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructorname);
                cmd.Parameters.AddWithValue("@instructorID", instructorID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertInstructor(Instructor instructortemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.instructor (instructorname) VALUES (@instructorname); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructorname", instructortemp.Instructor_name);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteInstructorByName(string instructorname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.instructor WHERE instructorname = @instructorname", conn))
            {
                cmd.Parameters.AddWithValue("@instructor", instructorname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<ClassType> GetAllClasstypes()
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

        public int UpdateClasstypeName(int classtypeID, string classtype)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.classtype SET classtype = @classtype WHERE classtypeID = @classtypeID", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtype);
                cmd.Parameters.AddWithValue("@classtypeID", classtypeID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertClasstype(ClassType classtypetemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.classtype (classtype) VALUES (@classtype); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtypetemp.Classtype);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteClasstype(string classtype)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.classtype WHERE classtype = @classtype", conn))
            {
                cmd.Parameters.AddWithValue("@classtype", classtype);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Member> GetAllMembers()
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
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["role_id"]);
                        members.Add(new Member(memberID, firstname, lastname, phonenumber, emailaddress, username, password, roleID));
                    }
                }

            }
            return members;

        }

        public int UpdateMemberFirstName(int memberID, string firstname)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Member.members SET firstname = @firstname WHERE memberID = @memberID", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@memberID", memberID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertMember(Member membertemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Member.members (firstname, lastname, phonenumber, emailaddress) VALUES (@firstname, @lastname, @phonenumber, @emailaddress); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", membertemp.Firstname);
                cmd.Parameters.AddWithValue("@lastname", membertemp.Lastname);
                cmd.Parameters.AddWithValue("@phonenumber", membertemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", membertemp.Emailaddress);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteMemberByName(string firstname, string lastname)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Member.members WHERE firstname = @firstname AND lastname = @lastname", conn))
            {
                cmd.Parameters.AddWithValue("@firstname", firstname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Role> GetAllRoles()
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

        public int UpdateRoleName(int roleID, string rolename)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Role.roles SET rolename = @rolesname WHERE roleID = @roleID", conn))
            {
                cmd.Parameters.AddWithValue("@rolename", rolename);
                cmd.Parameters.AddWithValue("@roleID", roleID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertRole(Role roletemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Role.roles (rolename) VALUES (@rolename); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@rolename", roletemp.Rolename);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteRoleByName(string rolename)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Role.roles WHERE rolename = @rolename", conn))
            {
                cmd.Parameters.AddWithValue("@role", rolename);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Sessionbooking> GetAllSessions()
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

        public int UpdateSessionDate(int sessionID, DateTime sessiondate)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Session.sessionbooking SET sessiondate = @sessiondate WHERE sessionID = @sessionID", conn))
            {
                cmd.Parameters.AddWithValue("@sessiondate", sessiondate);
                cmd.Parameters.AddWithValue("@sessionID", sessionID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertSession(Sessionbooking sessionbookingtemp)
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

        public int DeleteSessionByID(int sessionID)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Session.sessionbooking WHERE sessionID = @sessionID", conn))
            {
                cmd.Parameters.AddWithValue("@sessionID", sessionID);
                return cmd.ExecuteNonQuery();
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            string sqlString = "SELECT * FROM Login.users";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int userid = Convert.ToInt32(reader["userID"]);
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleid = Convert.ToInt32(reader["roleID"]);
                        users.Add(new User(userid, username, password, roleid));
                    }
                }

            }
            return users;

        }

        public int UpdateUserName(int userID, string username)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE Login.users SET username = @username WHERE userID = @userID", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userID", userID);
                return cmd.ExecuteNonQuery();
            }
        }

        public int InsertUser(User usertemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Login.users (username, password, roleID) VALUES (@username, @password, @roleID); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@username", usertemp.User_name);
                cmd.Parameters.AddWithValue("@password", usertemp.Password);
                cmd.Parameters.AddWithValue("@roleID", usertemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int DeleteUserByName(string username)
        {
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Login.users WHERE username = @username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                return cmd.ExecuteNonQuery();
            }
        }

        public bool IsUserValid(string username, int password)
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

        public int GetUserRole(string username, int password)
        {
            var query = "SELECT roleID FROM Member.members WHERE username = @username AND password = @password";
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

        public int RegisterMember(Member membertemp)
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

        public int RegisterGym(Gym gymtemp)
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

        public int RegisterAdmin(Member membertemp)
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

        public int RegisterInstructor(Instructor instructortemp)
        {
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Session.instructor (instructorname, gymID, phonenumber, emailaddress, username, password, roleID) VALUES (@instructorname, @gymID, @phonenumber, @emailaddress, @username, @password, @4); SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@instructor", instructortemp.Instructor_name);
                cmd.Parameters.AddWithValue("@gymID", instructortemp.Gym_id);
                cmd.Parameters.AddWithValue("@phonenumber", instructortemp.Phonenumber);
                cmd.Parameters.AddWithValue("@emailaddress", instructortemp.Emailaddress);
                cmd.Parameters.AddWithValue("@username", instructortemp.User_name);
                cmd.Parameters.AddWithValue("@password", instructortemp.Password);
                cmd.Parameters.AddWithValue("@4", instructortemp.Role_id);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public List<Member> Simple1QryMemberName()
        {
            List<Member> members = new List<Member>();
            string sqlstring = "Select memberID, firstname, lastname From Member.members";
            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
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
                        string username = reader["username"].ToString();
                        int password = Convert.ToInt32(reader["password"]);
                        int roleID = Convert.ToInt32(reader["role_id"]);
                        members.Add(new Member(memberID, firstname, lastname, phonenumber, emailaddress, username, password, roleID));
                    }
                }

            }
            return members;
        }

        public void Simple2QryClassTypes()
        {
            string sqlstring = "Select classtype, classprice From Session.classtype";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string classtype = reader["classtype"].ToString();
                        int classprice = Convert.ToInt32(reader["classprice"]);
                    }
                }

            }
        }

        public void Simple3QryMemberContactDetails()
        {
            string sqlstring = "Select firstname, lastname, phonenumber, emailaddress From Member.members";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);
                        string emailaddress = reader["emailaddress"].ToString();

                    }
                }

            }
        }

        public void Simple4QryGymLocation()
        {
            string sqlstring = "Select " +
                "Gym.gyms.gymname as Gym, " +
                "Gym.gyms.streetaddress as Street, " +
                "Location.suburb.suburbname as Suburb, " +
                "Location.city.cityname as City," +
                "Location.country.countryname as Country" +
                "From Gym.gyms, Location.suburb, Location.city, Location.country" +
                "Where Gym.gyms.suburbID = Location.suburb.suburbID" +
                "And Gym.gyms.cityID = Location.city.cityID" +
                "And Gym.gyms.countryID = Location.country.countryID";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string gymname = reader["gymname"].ToString();
                        string streetaddress = reader["streetaddress"].ToString();
                        string suburbname = reader["suburbname"].ToString();
                        string cityname = reader["cityname"].ToString();
                        string countryname = reader["countryname"].ToString();

                    }
                }

            }
        }

        public void Simple5QrySessionDetails()
        {
            string sqlstring = "Select " +
                "Member.members.firstname as Firstname," +
                "Member.members.lastname as Lastname," +
                "Gym.gyms.gymname as Gym," +
                "Session.instructor.instructorname as Instructor," +
                "Session.classtype.classtype as Class," +
                "Session.classtype.classprice as Price," +
                "Session.sessionbooking.sessiondate as Bookingtime" +
                "From Session.sessionbooking, Session.instructor, Session.classtype, Member.members, Gym.gyms" +
                "Where Session.sessionbooking.instructorID = Session.instructor.instructorID" +
                "And Session.sessionbooking.classtypeID = Session.classtype.classtypeID" +
                "And Session.sessionbooking.memberID = Member.members.memberID" +
                "And Session.sessionbooking.gymID = Gym.gyms.gymID";

            using (SqlCommand cmd = new SqlCommand(sqlstring, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstname = reader["firstname"].ToString();
                        string lastname = reader["lastname"].ToString();
                        string gymnamename = reader["gymname"].ToString();
                        int phonenumber = Convert.ToInt32(reader["phonenumber"]);

                    }
                }

            }
            
        }

        public void Advanced1QryClassesUnder31()
        {
            string sqlstring = "Select DISTINCT classtype, classprice" +
                "From Session.classtype" +
                "Where classprice <= '30'" +
                "Order By classprice ASC";
        }

        public void Advanced2QryInstructorsStartingWithA()
        {
            string sqlstring = "Select DISTINCT si.instructorname" +
                "From Session.instructor as si, Session.classtype as sc, Session.sessionbooking as ss" +
                "Where si.instructorID = ss.instructorID " +
                "And si.instructorname LIKE 'a%'";
        }

        public void Advanced3QryTop5MostExpensiveClasses()
        {
            string sqlstring = "Select Top 5 classtype as Class, classprice as Price " +
                "From Session.classtype" +
                "Order By classprice DESC";
        }

        public void Advanced4QryMembersWithGmailOrOutlook()
        {
            string sqlstring = "Select firstname, lastname, emailaddress" +
                "From Member.members" +
                "Where emailaddress LIKE '%gmail%'" +
                "OR emailaddress LIKE '%outlook%'";
        }

        public void Advanced5QrySessionsAfter27April()
        {
            string sqlstring = "Select sessionID, sessiondate" +
                "From Session.sessionbooking" +
                "Where sessiondate > '2025-04-27 14:00:00.123'" +
                "Order By sessionID";
        }

        public void Complex1QryInstructorsWithSessions()
        {
            string sqlstring = "Select" +
                "Session.instructor.instructorname as instructor, " +
                "COUNT(sessionID) as sessioncount" +
                "From Session.sessionbooking, Session.instructor" +
                "WHERE Session.sessionbooking.instructorID = Session.instructor.instructorID" +
                "Group By Session.instructor.instructorname";
        }

        public void Complex2QryRevenuePerClassType()
        {
            string sqlstring = "Select" +
                "Session.classtype.classtype," +
                "SUM(Session.classtype.classprice) as totalrevenue," +
                "AVG(Session.classtype.classprice) as averagerevenue" +
                "From Session.sessionbooking, Session.classtype" +
                "Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID" +
                "Group By Session.classtype.classtype";
        }

        public void Complex3QrySessionsUnder30()
        {
            string sqlstring = "Select COUNT(Session.sessionbooking.sessionID) as sessionsunder30dollars" +
                "From Session.sessionbooking, Session.classtype" +
                "Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID" +
                "And Session.classtype.classprice < '30'";
        }

        public void Complex4QryGymRevenue()
        {
            string sqlstring = "Select" +
                "Gym.gyms.gymname as Gym," +
                "SUM(Session.classtype.classprice) as totalrevenue," +
                "AVG(Session.classtype.classprice) as averagerevenuepersession" +
                "From Session.sessionbooking, Session.classtype, Gym.gyms" +
                "Where Session.sessionbooking.classtypeID = Session.classtype.classtypeID" +
                "And Session.sessionbooking.gymID = Gym.gyms.gymID" +
                "Group By Gym.gyms.gymname";
        }

        public void Complex5QryMemberSessionBooked()
        {
            string sqlstring = "Select Member.members.firstname as membername, Member.members.emailaddress as emailaddress, COUNT(sessionID) as sessionsbooked" +
                "From Session.sessionbooking, Member.members" +
                "Where Session.sessionbooking.memberID = Member.members.memberID" +
                "Group By Member.members.emailaddress, Member.members.firstname";
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
