using GymApp;
using GymApp.DBFile.Model;
using GymApp.View;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Threading.Channels;

namespace GymApp
{
    public class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\svkai\\OneDrive - Avondale College\\12TPISQL\\GymApp\\GymApp\\DBFile\\GymDatabase\\source\\repos\\ac147451\\GymDatabase\\GymDatabase\\SQLScripts\\SQL Scripts\\GymDatabase.mdf\";Integrated Security=True;Connect Timeout=30;Encrypt=True";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();
            string choice = view.MainMenu();

            switch (choice)
            {
                case "1":
                    {

                        login();

                        switch (choice)
                        {
                            case "1":
                                {
                                    string choice2 = view.MemberMenu();
                                    switch (choice2)
                                    {
                                        case "1":
                                            {

                                                break;
                                            }

                                        case "2":
                                            {
                                                break;
                                            }
                                    }
                                    break;
                                }

                            case "2":
                                {
                                    string choice2 = view.GymMenu();
                                    switch (choice2)
                                    {
                                        case "1":
                                            {

                                                break;
                                            }

                                        case "2":
                                            {
                                                break;
                                            }
                                    }
                                    break;
                                }
                            case "3":
                                {
                                    string choice2 = view.DisplayAdminMenu();
                                    switch (choice2)
                                    {
                                        case "1": //Gym Table
                                            {
                                                string choice1 = view.GymTableMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Gym> gyms = storageManager.GetAllGyms();
                                                            view.DisplayGyms(gyms);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateGymName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewGym();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteGymByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "2": //Country Table
                                            {
                                                string choice1 = view.CountryMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Country> countries = storageManager.GetAllCountries();
                                                            view.DisplayCountries(countries);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateCountryName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewCountry();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteCountryByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "3": //City Table
                                            {
                                                string choice1 = view.CityMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<City> cities = storageManager.GetAllCities();
                                                            view.DisplayCities(cities);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateCityName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewCity();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteCityByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "4": //Suburb Table
                                            {
                                                string choice1 = view.SuburbMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Suburb> suburbs = storageManager.GetAllSuburbs();
                                                            view.DisplaySuburbs(suburbs);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateSuburbName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewSuburb();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteSuburbByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "5": //Instructor Table
                                            {
                                                string choice1 = view.InstructorMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Instructor> instructors = storageManager.GetAllInstructors();
                                                            view.DisplayInstructors(instructors);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateInstructorName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewInstructor();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteInstructorByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "6": //Classtype Table
                                            {
                                                string choice1 = view.ClasstypeMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<ClassType> classtypes = storageManager.GetAllClasstypes();
                                                            view.DisplayClasstypes(classtypes);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateClasstypeName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewClasstype();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteClasstype();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "7": //Member Table
                                            {
                                                string choice1 = view.MemberTableMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Member> members = storageManager.GetAllMembers();
                                                            view.DisplayMembers(members);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateMemberFirstName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewMember();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteMemberByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "8": //Role Table
                                            {
                                                string choice1 = view.RoleMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Role> roles = storageManager.GetAllRoles();
                                                            view.DisplayRoles(roles);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateRoleName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewRole();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteRoleByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "9": //Sessionbooking Table
                                            {
                                                string choice1 = view.SessionbookingMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<Sessionbooking> sessionbookings = storageManager.GetAllSessions();
                                                            view.DisplaySessions(sessionbookings);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateSessionDate();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewSession();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteSessionByID();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "10": //User Table
                                            {
                                                string choice1 = view.UserMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            List<User> users = storageManager.GetAllUsers();
                                                            view.DisplayUsers(users);
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;

                                                    case "2":
                                                        UpdateUserName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "3":
                                                        InsertNewUser();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;

                                                    case "4":
                                                        DeleteUserByName();
                                                        view.DisplayMessage("Enter any button to go back to Main Menu");
                                                        Console.ReadLine();
                                                        Console.Clear();
                                                        view.DisplayAdminMenu();
                                                        break;
                                                }

                                            }
                                            break;

                                        case "11": //Queries
                                            {
                                                string choice1 = view.QueryMenu();
                                                switch (choice1)
                                                {
                                                    case "1":
                                                        {
                                                            Simple1QryMemberName();
                                                            view.DisplayMessage("Enter any button to go back to Main Menu");
                                                            Console.ReadLine();
                                                            Console.Clear();
                                                            view.DisplayAdminMenu();
                                                        }
                                                        break;
                                                }

                                            }
                                            break;

                                        default:
                                            Console.WriteLine("Invalid option. Please try again.");
                                            break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
                case "2": //Register Menu
                    {
                        InsertNewUser();
                        view.DisplayMessage("Enter any button to go back to Main Menu");
                        Console.ReadLine();
                        Console.Clear();
                        view.DisplayAdminMenu();
                        break;
                    }
                
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            storageManager.CloseConnection();
        }
        
        private static void UpdateGymName()
        {

            view.DisplayMessage("Enter the gymID to update: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter the new gym name: ");
            string gymname = view.GetInput();
            int rowsAffected = storageManager.UpdateGymName(gymID, gymname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewGym()
        {
            view.DisplayMessage("Enter the new gym name: ");
            string gymname = view.GetInput();
            view.DisplayMessage("Enter the street address: ");
            string streetaddress = view.GetInput();
            view.DisplayMessage("Enter the country ID: ");
            int countryID = view.GetIntInput();
            view.DisplayMessage("Enter the city ID: ");
            int cityID = view.GetIntInput();
            view.DisplayMessage("Enter the suburb ID: ");
            int suburbID = view.GetIntInput();
            int gymID = 0;
            Gym gym1 = new Gym(gymID, gymname, streetaddress, countryID, cityID, suburbID);
            int generatedID = storageManager.InsertGym(gym1);
            view.DisplayMessage($"New gym inserted with ID: {generatedID}");

        }

        private static void DeleteGymByName()
        {
            view.DisplayMessage("Enter the gym name to delete: ");
            string gymname = view.GetInput();
            int rowsAffected = storageManager.DeleteGymByName(gymname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateCountryName()
        {

            view.DisplayMessage("Enter the countryID to update: ");
            int countryID = view.GetIntInput();
            view.DisplayMessage("Enter the new country name: ");
            string countryname = view.GetInput();
            int rowsAffected = storageManager.UpdateCountryName(countryID, countryname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewCountry()
        {
            view.DisplayMessage("Enter the new country name: ");
            string countryname = view.GetInput();
            int countryID = 0;
            Country country1 = new Country(countryID, countryname);
            int generatedID = storageManager.InsertCountry(country1);
            view.DisplayMessage($"New country inserted with ID: {generatedID}");

        }

        private static void DeleteCountryByName()
        {
            view.DisplayMessage("Enter the country name to delete: ");
            string countryname = view.GetInput();
            int rowsAffected = storageManager.DeleteCountryByName(countryname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateCityName()
        {

            view.DisplayMessage("Enter the cityID to update: ");
            int cityID = view.GetIntInput();
            view.DisplayMessage("Enter the new city name: ");
            string cityname = view.GetInput();
            int rowsAffected = storageManager.UpdateCityName(cityID, cityname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewCity()
        {
            view.DisplayMessage("Enter the new city name: ");
            string cityname = view.GetInput();
            int cityID = 0;
            City city1 = new City(cityID, cityname);
            int generatedID = storageManager.InsertCity(city1);
            view.DisplayMessage($"New city inserted with ID: {generatedID}");

        }

        private static void DeleteCityByName()
        {
            view.DisplayMessage("Enter the city name to delete: ");
            string cityname = view.GetInput();
            int rowsAffected = storageManager.DeleteCityByName(cityname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateSuburbName()
        {

            view.DisplayMessage("Enter the suburbID to update: ");
            int suburbID = view.GetIntInput();
            view.DisplayMessage("Enter the new suburb name: ");
            string suburbname = view.GetInput();
            int rowsAffected = storageManager.UpdateSuburbName(suburbID, suburbname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewSuburb()
        {
            view.DisplayMessage("Enter the new suburb name: ");
            string suburbname = view.GetInput();
            int suburbID = 0;
            Suburb suburb1 = new Suburb(suburbID, suburbname);
            int generatedID = storageManager.InsertSuburb(suburb1);
            view.DisplayMessage($"New suburb inserted with ID: {generatedID}");

        }

        private static void DeleteSuburbByName()
        {
            view.DisplayMessage("Enter the suburb name to delete: ");
            string suburbname = view.GetInput();
            int rowsAffected = storageManager.DeleteSuburbByName(suburbname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateInstructorName()
        {

            view.DisplayMessage("Enter the instructorID to update: ");
            int instructorID = view.GetIntInput();
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();
            int rowsAffected = storageManager.UpdateInstructorName(instructorID, instructorname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewInstructor()
        {
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();
            int instructorID = 0;
            Instructor instructor1 = new Instructor(instructorID, instructorname);
            int generatedID = storageManager.InsertInstructor(instructor1);
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}");

        }

        private static void DeleteInstructorByName()
        {
            view.DisplayMessage("Enter the instructor name to delete: ");
            string instructorname = view.GetInput();
            int rowsAffected = storageManager.DeleteInstructorByName(instructorname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateClasstypeName()
        {

            view.DisplayMessage("Enter the classtypeID to update: ");
            int classtypeID = view.GetIntInput();
            view.DisplayMessage("Enter the new classtype name: ");
            string classtype = view.GetInput();
            int rowsAffected = storageManager.UpdateClasstypeName(classtypeID, classtype);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewClasstype()
        {
            view.DisplayMessage("Enter the new classtype: ");
            string classtype = view.GetInput();
            view.DisplayMessage("Enter the price of the new classtype: ");
            int classprice = view.GetIntInput();
            int classtypeID = 0;
            ClassType classtype1 = new ClassType(classtypeID, classtype, classprice);
            int generatedID = storageManager.InsertClasstype(classtype1);
            view.DisplayMessage($"New class type inserted with ID: {generatedID}");

        }

        private static void DeleteClasstype()
        {
            view.DisplayMessage("Enter the classtype to delete: ");
            string classtype = view.GetInput();
            int rowsAffected = storageManager.DeleteClasstype(classtype);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateMemberFirstName()
        {

            view.DisplayMessage("Enter the memberID to update: ");
            int memberID = view.GetIntInput();
            view.DisplayMessage("Enter the new member's first name: ");
            string firstname = view.GetInput();
            int rowsAffected = storageManager.UpdateMemberFirstName(memberID, firstname);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewMember()
        {
            view.DisplayMessage("Enter the new member's firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter the new member's lastname: ");
            string lastname = view.GetInput();
            view.DisplayMessage("Enter the new member's phonenumber: ");
            int phonenumber = view.GetIntInput();
            view.DisplayMessage("Enter the new member's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the new member's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the new member's password pin: ");
            int password = view.GetIntInput();
            int memberID = 0;
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, username, password, 1);
            int generatedID = storageManager.InsertMember(member1);
            view.DisplayMessage($"New member inserted with ID: {generatedID}");

        }

        private static void DeleteMemberByName()
        {
            view.DisplayMessage("Enter the member's firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter the member's lastnamename: ");
            string lastname = view.GetInput();
            int rowsAffected = storageManager.DeleteMemberByName(firstname, lastname);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateRoleName()
        {

            view.DisplayMessage("Enter the roleID to update: ");
            int roleID = view.GetIntInput();
            view.DisplayMessage("Enter the new role name: ");
            string rolename = view.GetInput();
            int rowsAffected = storageManager.UpdateRoleName(roleID, rolename);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewRole()
        {
            view.DisplayMessage("Enter the new role name: ");
            string rolename = view.GetInput();
            int roleID = 0;
            Role role1 = new Role(roleID, rolename);
            int generatedID = storageManager.InsertRole(role1);
            view.DisplayMessage($"New role inserted with ID: {generatedID}");

        }

        private static void DeleteRoleByName()
        {
            view.DisplayMessage("Enter the role name to delete: ");
            string rolename = view.GetInput();
            int rowsAffected = storageManager.DeleteRoleByName(rolename);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateSessionDate()
        {

            view.DisplayMessage("Enter the sessionID to update: ");
            int sessionID = view.GetIntInput();
            view.DisplayMessage("Enter the session date: ");
            DateTime sessiondate = view.GetDateTimeInput();
            int rowsAffected = storageManager.UpdateSessionDate(sessionID, sessiondate);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewSession()
        {
            view.DisplayMessage("Enter the instructor's ID: ");
            int instructorID = view.GetIntInput();
            view.DisplayMessage("Enter the classtype's ID: ");
            int classtypeID = view.GetIntInput();
            view.DisplayMessage("Enter the member's ID: ");
            int memberID = view.GetIntInput();
            view.DisplayMessage("Enter the gym's ID: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter the sessiondate: ");
            DateTime sessiondate = view.GetDateTimeInput();
            int sessionID = 0;
            Sessionbooking sessionbooking1 = new Sessionbooking(sessionID, instructorID, classtypeID, memberID, gymID, sessiondate);
            int generatedID = storageManager.InsertSession(sessionbooking1);
            view.DisplayMessage($"New session inserted with ID: {generatedID}");

        }

        private static void DeleteSessionByID()
        {
            view.DisplayMessage("Enter the sessionID to delete: ");
            int sessionID = view.GetIntInput();
            int rowsAffected = storageManager.DeleteSessionByID(sessionID);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void UpdateUserName()
        {

            view.DisplayMessage("Enter the userID to update: ");
            int userID = view.GetIntInput();
            view.DisplayMessage("Enter the new user name: ");
            string username = view.GetInput();
            int rowsAffected = storageManager.UpdateUserName(userID, username);
            view.DisplayMessage($"Rows affected: {rowsAffected}");
        }

        private static void InsertNewUser()
        {
            view.DisplayMessage("Enter the new user name: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the password: ");
            int password = view.GetIntInput();
            view.DisplayMessage("Enter the role ID: ");
            int roleID = view.GetIntInput();
            int userID = 0;
            User user1 = new User(userID, username, password, roleID);
            int generatedID = storageManager.InsertUser(user1);
            view.DisplayMessage($"New user inserted with ID: {generatedID}");

        }

        private static void DeleteUserByName()
        {
            view.DisplayMessage("Enter the user name to delete: ");
            string username = view.GetInput();
            int rowsAffected = storageManager.DeleteUserByName(username);
            view.DisplayMessage($"Rows Affected: {rowsAffected}");
        }

        private static void Simple1QryMemberName()
        {
            storageManager.Simple1QryMemberName();
        }

        private static void login()
        {
            bool valid = false;
            do
            {
                (string username, int password) = view.LoginMenu();
                valid = storageManager.IsUserValid(username, password);
                

            } while (!valid);
            
            
        }


    }
}






/*
   case "5":
                    exit = true;
                    break;
*/