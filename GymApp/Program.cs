using Azure.Identity;
using GymApp;
using GymApp.DBFile.Model;
using GymApp.View;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GymApp
{
    public class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\samka\\OneDrive - Avondale College\\12TPISQL\\GymApp\\GymApp\\DBFile\\GymDatabase\\source\\repos\\ac147451\\GymDatabase\\GymDatabase\\SQLScripts\\SQL Scripts\\GymDatabase.mdf\";Integrated Security=True;Connect Timeout=30";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();

            while (true)
            {

                string choice = view.MainMenu();

                switch (choice)
                {
                    case "1":
                        int roleID = login();
                        if (roleID == 1)
                        {
                        while (roleID == 1)
                        {
                            MemberMenu(); // Calling the Member Menu Method if their role is a member
                        }
                        }
                        else if (roleID == 2)
                        {
                        while (roleID == 2)
                        {
                            GymMenu();
                        }
                        }
                        else if (roleID == 3)
                        {
                        while (roleID == 3)
                        {
                            AdminMenu();
                        }

                        }
                        else if (roleID == 4)
                        {
                        while (roleID == 4)
                        {
                            InstructorMenu();
                        }
                        }
                        else
                        {
                            Console.WriteLine("Unknown role. Please try again");
                        }
                        break;

                    case "2": //Register Menu
                        {
                            string choice1 = view.RegisterMenu();
                            switch (choice1)
                            {
                                case "1":

                                    RegisterMember();
                                    break;

                                case "2":

                                    RegisterGym();
                                    break;

                                case "3":
                                    RegisterAdmin();
                                    break;

                                case "4":
                                    RegisterInstructor();
                                    break;
                                default:
                                    Console.WriteLine("Invalid Registration choice");
                                    break;
                            }
                            Console.WriteLine("Registration complete. Please login now");
                            Console.WriteLine("Press any Key to continue: ");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

            }
        }

        static void MemberMenu()
        {
            char close;
            string choice2 = view.MemberMenu();
            switch (choice2)
            {
                case "1":
                    {
                        ViewMemberSessions();
                        view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                        close = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();
                        if (close == 'N')
                        {
                            storageManager.CloseConnection();
                            Environment.Exit(0);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }

                case "2":
                    {

                        break;
                    }
            }
            
        }

        static void GymMenu()
        {
            string choice2 = view.GymMenu();
            switch (choice2)
            {
                case "1":
                    {
                        char close;
                        string choice1 = view.GymSessionsMenu();

                        switch (choice1)
                        {
                            case "1":
                                {
                                    ViewGymSessions();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    InsertNewGymSession();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                        }
                        break;
                    }

                case "2":
                    {
                        char close;
                        string choice1 = view.GymMembersMenu();

                        switch (choice1)
                        {
                            case "1":
                                {
                                    ViewGymMembers();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    InsertNewGymMember();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "3":
                                {
                                    DeleteGymMember();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                        break;
                        
                    }

                case "3":
                    {
                        char close;
                        string choice1 = view.GymInstructorsMenu();

                        switch (choice1)
                        {
                            case "1":
                                {
                                    ViewGymInstructors();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    InsertNewGymInstructor();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "3":
                                {
                                    DeleteGymInstructor();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                        }
                        break;
                    }
            }

        }

        static void InstructorMenu()
        {
            char close;
            string choice2 = view.InstructorMenu();
            switch (choice2)
            {
                case "1":
                    {
                        ViewInstructorSessions();
                        view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                        close = char.Parse(Console.ReadLine().ToUpper());
                        Console.Clear();
                        if (close == 'N')
                        {
                            storageManager.CloseConnection();
                            Environment.Exit(0);
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }

                case "2":
                    {
                        break;
                    }
            }

        }

        static void AdminMenu()
        {
            string choice2 = view.DisplayAdminMenu();
            switch (choice2)
            {
                case "1": //Gym Table
                    {
                        char close;
                        string choice1 = view.GymTableMenu();

                        switch (choice1)
                        {
                            case "1":
                                {

                                    List<Gym> gyms = storageManager.GetAllGyms();
                                    view.DisplayGyms(gyms);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateGymName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;
                                

                            case "3":
                                {
                                    InsertNewGym();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "4":
                                {
                                    DeleteGymByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }                              
                                break;
                        }


                    }
                    break;

                case "2": //Country Table
                    {
                        char close;
                        string choice1 = view.CountryMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Country> countries = storageManager.GetAllCountries();
                                    view.DisplayCountries(countries);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateCountryName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                                break;

                            case "3":
                                {
                                    InsertNewCountry();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                                break;

                            case "4":
                                {
                                    DeleteCountryByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                                break;
                        }

                    }
                    break;

                case "3": //City Table
                    {
                        char close;
                        string choice1 = view.CityMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<City> cities = storageManager.GetAllCities();
                                    view.DisplayCities(cities);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateCityName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewCity();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteCityByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "4": //Suburb Table
                    {
                        char close;
                        string choice1 = view.SuburbMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Suburb> suburbs = storageManager.GetAllSuburbs();
                                    view.DisplaySuburbs(suburbs);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateSuburbName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewSuburb();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteSuburbByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "5": //Instructor Table
                    {
                        char close;
                        string choice1 = view.InstructorTableMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Instructor> instructors = storageManager.GetAllInstructors();
                                    view.DisplayInstructors(instructors);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateInstructorName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                
                                break;

                            case "3":
                                {
                                    InsertNewInstructor();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteInstructorByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "6": //Classtype Table
                    {
                        char close;
                        string choice1 = view.ClasstypeMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<ClassType> classtypes = storageManager.GetAllClasstypes();
                                    view.DisplayClasstypes(classtypes);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateClasstypeName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewClasstype();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteClasstype();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "7": //Member Table
                    {
                        char close;
                        string choice1 = view.MemberTableMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Member> members = storageManager.GetAllMembers();
                                    view.DisplayMembers(members);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateMemberFirstName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewMember();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteMemberByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "8": //Role Table
                    {
                        char close;
                        string choice1 = view.RoleMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Role> roles = storageManager.GetAllRoles();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateRoleName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewRole();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteRoleByName();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;

                case "9": //Sessionbooking Table
                    {
                        char close;
                        string choice1 = view.SessionbookingMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Sessionbooking> sessionbookings = storageManager.GetAllSessions();
                                    view.DisplaySessions(sessionbookings);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    UpdateSessionDate();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "3":
                                {
                                    InsertNewSession();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;

                            case "4":
                                {
                                    DeleteSessionByID();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                break;
                        }

                    }
                    break;


                case "10": //Queries
                    {
                        char close;
                        string choice1 = view.QueryMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Member> members = storageManager.Simple1QryMemberName();
                                    view.Simple1QryMemberName(members);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "2":
                                {
                                    List<ClassType> classtypes = storageManager.Simple2QryClassTypes();
                                    view.Simple2QryClassTypes(classtypes);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "3":
                                {
                                    List<Member> members = storageManager.Simple3QryMemberContactDetails();
                                    view.Simple3QryMemberContactDetails(members);
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "4":
                                {
                                    storageManager.Simple4QryGymLocation();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "5":
                                {
                                    storageManager.Simple5QrySessionDetails();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "6":
                                {
                                    storageManager.Advanced1QryClassesUnder31();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "7":
                                {
                                    storageManager.Advanced2QryInstructorsStartingWithA();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "8":
                                {
                                    storageManager.Advanced3QryTop5MostExpensiveClasses();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "9":
                                {
                                    storageManager.Advanced4QryMembersWithGmailOrOutlook();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "10":
                                {
                                    storageManager.Advanced5QrySessionsAfter27April();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "11":
                                {
                                    storageManager.Complex1QryInstructorsWithSessions();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "12":
                                {
                                    storageManager.Complex2QryRevenuePerClassType();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "13":
                                {
                                    storageManager.Complex3QrySessionsUnder30();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "14":
                                {
                                    storageManager.Complex4QryGymRevenue();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                            case "15":
                                {
                                    storageManager.Complex5QryMemberSessionBooked();
                                    view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program");
                                    close = char.Parse(Console.ReadLine().ToUpper());
                                    Console.Clear();
                                    if (close == 'N')
                                    {
                                        storageManager.CloseConnection();
                                        Environment.Exit(0);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                break;

                        }
                        break;

                    }

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
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
            view.DisplayMessage("Enter the phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter the emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter your username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the gym's pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 2;
            int gymID = 0;
            Gym gym1 = new Gym(gymID, gymname, streetaddress, countryID, cityID, suburbID, phonenumber, emailaddress, username, password, roleID);
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
            view.DisplayMessage("Enter the gym ID that the instructor is with: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter the new instructor's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter the new instructor's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the new instructor's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the new instructors's password pin: ");
            int password = view.GetIntInput();
            int roleID = 4;
            int instructorID = 0;
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
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
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter the new member's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the member's gym ID: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter the new member's username: ");         
            string username = view.GetInput();
            view.DisplayMessage("Enter the new member's password pin: ");
            int password = view.GetIntInput();
            int memberID = 0;
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, 1);
            int generatedID = storageManager.InsertMember(member1);
            view.DisplayMessage($"New member inserted with ID: {generatedID}");

        }

        private static void DeleteMemberByName()
        {
            view.DisplayMessage("Enter the member's firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter the member's lastname: ");
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

        private static (string username, int password) UsernamePassword()
        {
            (string username, int password) = view.LoginMenu();

            return (username, password);
        }

        private static int login()
        {
            int roleID;

            do
            {
                (string username, int password) = UsernamePassword();
                roleID = storageManager.GetUserRole(username, password);

                if (roleID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }
            } while (roleID == 0);
            return (roleID);
        }

        private static void ViewMemberSessions()
        {
            int memberID;

            do
            {
                (string username, int password) = UsernamePassword();
                memberID = storageManager.GetMemberID(username, password);
                storageManager.ViewMemberSessions(memberID);

                if (memberID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (memberID == 0);
           
        }
        
        private static void ViewGymSessions()
        {
            int gymID;

            do
            {
                (string username, int password) = UsernamePassword();
                gymID = storageManager.GetGymID(username, password);
                storageManager.ViewGymSessions(gymID);

                if (gymID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (gymID == 0);

        }

        private static void InsertNewGymSession()
        {
            (string username, int password) = UsernamePassword();
            view.DisplayMessage("Enter the instructor's ID: ");
            int instructorID = view.GetIntInput();
            view.DisplayMessage("Enter the classtype's ID: ");
            int classtypeID = view.GetIntInput();
            view.DisplayMessage("Enter the member's ID: ");
            int memberID = view.GetIntInput();
            view.DisplayMessage("Enter the sessiondate: Year - Month - Day Hour:Minute:Second.123");
            DateTime sessiondate = view.GetDateTimeInput();
            int gymID = storageManager.GetGymID(username, password);
            int sessionID = 0;
            Sessionbooking sessionbooking1 = new Sessionbooking(sessionID, instructorID, classtypeID, memberID, gymID, sessiondate);
            int generatedID = storageManager.InsertGymSession(sessionbooking1);
            view.DisplayMessage($"New session inserted with ID: {generatedID}");

        }

        private static void ViewGymMembers()
        {
            int gymID;

            do
            {
                (string username, int password) = UsernamePassword();
                gymID = storageManager.GetGymID(username, password);
                storageManager.ViewGymMembers(gymID);

                if (gymID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (gymID == 0);

        }

        private static void InsertNewGymMember()
        {
            view.DisplayMessage("Enter the new member's firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter the new member's lastname: ");
            string lastname = view.GetInput();
            view.DisplayMessage("Enter the new member's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter the new member's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the new member's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the new member's password pin: ");
            int password = view.GetIntInput();
            int memberID = 0;
            int gymID = storageManager.GetGymID(username, password);
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, 1);
            int generatedID = storageManager.InsertMember(member1);
            view.DisplayMessage($"New member inserted with ID: {generatedID}");

        }

        private static void DeleteGymMember()
        {

                (string username, int password) = UsernamePassword();
                view.DisplayMessage("Enter the member's firstname: ");
                string firstname = view.GetInput();
                view.DisplayMessage("Enter the member's lastname: ");
                string lastname = view.GetInput();
                int gymID = storageManager.GetGymID(username, password);
                int rowsAffected = storageManager.DeleteGymMember(firstname, lastname, gymID);
                if (rowsAffected == 0)
                {
                    view.DisplayMessage("Invalid member, please log back in after closing this app and retry");
                }
                else
                {
                    view.DisplayMessage($"Rows Affected: {rowsAffected}");
                }
        }

        private static void ViewGymInstructors()
        {
            int gymID;

            do
            {
                (string username, int password) = UsernamePassword();
                gymID = storageManager.GetGymID(username, password);
                storageManager.ViewGymInstructors(gymID);

                if (gymID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (gymID == 0);

        }

        private static void InsertNewGymInstructor()
        {
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();
            view.DisplayMessage("Enter the new instructor's phonenumber: ");
            int phonenumber = view.GetIntInput();
            view.DisplayMessage("Enter the new instructor's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the new instructor's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the new instructors's password pin: ");
            int password = view.GetIntInput();
            int roleID = 4;
            int gymID = storageManager.GetGymID(username, password);
            int instructorID = 0;
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.InsertInstructor(instructor1);
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}");

        }

        private static void DeleteGymInstructor()
        {
            (string username, int password) = UsernamePassword();
            view.DisplayMessage("Enter the instructor name to delete: ");
            string instructorname = view.GetInput();
            int gymID = storageManager.GetGymID(username, password);
            int rowsAffected = storageManager.DeleteGymInstructor(instructorname, gymID);
            if (rowsAffected == 0)
            {
                view.DisplayMessage("Invalid member, please log back in after closing this app and retry");
            }
            else
            {
                view.DisplayMessage($"Rows Affected: {rowsAffected}");
            }
        }

        private static void ViewInstructorSessions()
        {
            int instructorID;

            do
            {
                (string username, int password) = UsernamePassword();
                instructorID = storageManager.GetInstructorID(username, password);
                storageManager.ViewInstructorSessions(instructorID);

                if (instructorID == 0)
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

            } while (instructorID == 0);

        }


        private static void RegisterMember()
        {
            view.DisplayMessage("Enter your firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter your lastname: ");
            string lastname = view.GetInput();
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter your gym's ID: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 1;
            int memberID = 0;
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID);
            int generatedID = storageManager.RegisterMember(member1);
            view.DisplayMessage($"New member inserted with ID: {generatedID}");
        }
        
        private static void RegisterGym()
        {
            view.DisplayMessage("Enter your gym's name: ");
            string gymname = view.GetInput();
            view.DisplayMessage("Enter your gym's street address: ");
            string streetaddress = view.GetInput();
            view.DisplayMessage("Enter the country ID where your gym is located: ");
            int countryID = view.GetIntInput();
            view.DisplayMessage("Enter the city ID where your gym is located: ");
            int cityID = view.GetIntInput();
            view.DisplayMessage("Enter the suburb ID where your gym is located: ");
            int suburbID = view.GetIntInput();
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter your gym's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 2;
            int gymID = 0;
            Gym gym1 = new Gym(gymID, gymname, streetaddress, countryID, cityID, suburbID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.RegisterGym(gym1);
            view.DisplayMessage($"New gym inserted with ID: {generatedID}");
        }
        
        private static void RegisterAdmin()
        {
            view.DisplayMessage("Enter your firstname: ");
            string firstname = view.GetInput();
            view.DisplayMessage("Enter your lastname: ");
            string lastname = view.GetInput();
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 3;
            int memberID = 0;
            int gymID = 1;
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID);
            int generatedID = storageManager.RegisterAdmin(member1);
            view.DisplayMessage($"New admin inserted with ID: {generatedID}");
        }
        
        private static void RegisterInstructor()
        {
            view.DisplayMessage("Enter your name: ");
            string instructorname = view.GetInput();
            view.DisplayMessage("Enter the gymID of the gym you work for: ");
            int gymID = view.GetIntInput();
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 4;
            int instructorID = 0;
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.RegisterInstructor(instructor1);
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}");
        }




    }
}






/*
   case "5":
                    exit = true;
                    break;
*/

/*
        private static void login()
        {
            bool valid = false;
            do
            {
                (string username, int password) = view.LoginMenu();
                valid = storageManager.IsUserValid(username, password);
                

            } while (!valid);

        }
*/
/*
private static (string username, int password, int roleID) login()
{

    (string username, int password) = UsernamePassword();
    int roleID = getrole();

    return (username, password, roleID);
}
*/