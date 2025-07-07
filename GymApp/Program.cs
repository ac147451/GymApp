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
        private static StorageManager storageManager;//declaring this vairable to connect to storagemanager.cs
        private static ConsoleView view;//declaring this vairable to connect to storagemanager.cs
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\samka\\OneDrive - Avondale College\\12TPISQL\\GymApp\\GymApp\\DBFile\\GymDatabase\\source\\repos\\ac147451\\GymDatabase\\GymDatabase\\SQLScripts\\SQL Scripts\\GymDatabase.mdf\";Integrated Security=True;Connect Timeout=30";
            //connecting to my sql database
            storageManager = new StorageManager(connectionString); //declaring this vairable to connect to storagemanager.cs
            view = new ConsoleView(); //declaring this vairable to connect to storagemanager.cs

            while (true)
            {

                string choice = view.MainMenu(); //declaring the variable 'choice' to call the main menu from console view

                switch (choice)//Calling the main menu / login or register menu
                {
                    case "1":
                        Console.Clear();
                        int roleID = login(); //Calling the login menu to gather the user's roleID
                        if (roleID == 1)
                        {
                        while (roleID == 1)
                        {
                                Console.Clear();
                                MemberMenu(); // Calling the Member Menu Method if their role is 1
                        }
                        }
                        else if (roleID == 2)
                        {
                        while (roleID == 2)
                        {
                                Console.Clear();
                                GymMenu();// Calling the Gym Menu Method if their role is 2
                            }
                        }
                        else if (roleID == 3)
                        {
                        while (roleID == 3)
                        {
                                Console.Clear();
                            AdminMenu();// Calling the Admin Menu Method if their role is 3
                            }

                        }
                        else if (roleID == 4)
                        {
                        while (roleID == 4)
                        {
                                Console.Clear();
                                InstructorMenu();// Calling the Instructor Menu Method if their role is 4
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unknown role. Please try again"); //If their role if anything other than 1,2,3 or 4 it will loop back to the login method
                        }
                        break;

                    case "2": //Register Menu
                        {
                            Console.Clear();
                            string choice1 = view.RegisterMenu();//declaring the variable 'choice1' to call the register menu from console view
                            switch (choice1)//Calling the register menu
                            {
                                case "1":
                                    Console.Clear();
                                    RegisterMember(); //Calling the register member method
                                    break;

                                case "2":
                                    Console.Clear();
                                    RegisterGym(); //Calling the register gym method
                                    break;

                                case "3":
                                    Console.Clear();
                                    RegisterAdmin();//Calling the register admin method
                                    break;

                                case "4":
                                    Console.Clear();
                                    RegisterInstructor();//Calling the register instructor method
                                    break;
                                default:
                                    Console.WriteLine("Invalid Registration choice"); //displays message if they picked anything else other than 1,2,3 or 4
                                    break;
                            }
                            Console.WriteLine();
                            Console.WriteLine("Registration complete. Please login now");
                            Console.WriteLine("Press any Key to continue: "); //Loops back to the main menu to allow the user to login
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    default:
                        Console.WriteLine("Invalid option. Please try again."); //message for invalid inputs
                        break;
                }

            }
        }

        static void MemberMenu() //Member menu method
        {
            char close;
            string choice2 = view.MemberMenu(); 
            switch (choice2)//Displaying member menu from console view
            {
                case "1":
                    {
                        ViewMemberSessions(); //Calling the viewmembersessions method
                        view.DisplayMessage("Enter 'Y' if you would like to go back to the Main Menu, or Type 'N' if you want to Close this program"); // Allowing the user to either go back to the main menu, or close the program *Is the same for all of the following
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

            }
            
        }

        static void GymMenu() //Gym menu method
        {
            string choice2 = view.GymMenu(); 
            switch (choice2)//Displaying the gym menu from console view
            {
                case "1":
                    {
                        char close;
                        string choice1 = view.GymSessionsMenu();

                        switch (choice1)//Displaying member menu from console view
                        {
                            case "1":
                                {
                                    ViewGymSessions(); //Calling the viewgymsessions method
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
                                    InsertNewGymSession(); //Calling the insertnewgymsession method
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

                        switch (choice1) //Displaying the gymmember menu from console view
                        {
                            case "1":
                                {
                                    ViewGymMembers(); //Calling the viewgym members method
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
                                    InsertNewGymMember(); //Calling the insertnewgymmember method
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
                                    DeleteGymMember(); //Calling the deletegymmember method
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

                        switch (choice1)//Displaying the gym instructor menu from console view
                        {
                            case "1":
                                {
                                    ViewGymInstructors(); //Calling the viewgyminstructors method
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
                                    InsertNewGymInstructor(); //Calling the insertnewgyminstructor method
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
                                    DeleteGymInstructor(); //Calling the deletegyminstructor method
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

        static void InstructorMenu() //Instructor menu method
        {
            char close;
            string choice2 = view.InstructorMenu();
            switch (choice2) //Displaying the instructors menu
            {
                case "1":
                    {
                        ViewInstructorSessions(); //Calling the viewinstructor sessions method
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
            }

        }

        static void AdminMenu() //Admin menu method
        {
            string choice2 = view.DisplayAdminMenu();
            switch (choice2) //Displaying the admin menu 
            {
                case "1": //Gym Table
                    {
                        Console.Clear();
                        char close;
                        string choice1 = view.GymTableMenu();

                        switch (choice1) //Displaying the gymtablemenu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Gym> gyms = storageManager.GetAllGyms(); //Calling the GetAllGyms from storage manager
                                    view.DisplayGyms(gyms); //Calling the DisplayGyms from console view and returning gyms
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
                                    Console.Clear();
                                    UpdateGymName(); //Calling thw UpdateGymName method
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
                                    Console.Clear();
                                    InsertNewGym();//Calling this method
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
                                    Console.Clear();
                                    DeleteGymByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.CountryMenu();
                        switch (choice1)//Displaying the country menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Country> countries = storageManager.GetAllCountries();//Calling the GetAllCountries from storage manager
                                    view.DisplayCountries(countries);//Calling the Displaycountries from console view and returning countries
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
                                    Console.Clear();
                                    UpdateCountryName();//Calling this method
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
                                    Console.Clear();
                                    InsertNewCountry();//Calling this method
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
                                    Console.Clear();
                                    DeleteCountryByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.CityMenu();
                        switch (choice1)//Displaying the city menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<City> cities = storageManager.GetAllCities();//Calling the GetAllCities from storage manager
                                    view.DisplayCities(cities);//Calling the DisplayCities from console view and returning cities
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
                                    Console.Clear();
                                    UpdateCityName(); //Calling this method
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
                                    Console.Clear();
                                    InsertNewCity();//Calling this method
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
                                    Console.Clear();
                                    DeleteCityByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.SuburbMenu();
                        switch (choice1)//Displaying the suburb menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Suburb> suburbs = storageManager.GetAllSuburbs();//Calling the GetAllSuburbs from storage manager
                                    view.DisplaySuburbs(suburbs);//Calling the DisplaySuburbs from console view and returning that value 'suburbs'
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
                                    Console.Clear();
                                    UpdateSuburbName(); //Calling this method
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
                                    Console.Clear();
                                    InsertNewSuburb();//Calling this method
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
                                    Console.Clear();
                                    DeleteSuburbByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.InstructorTableMenu();
                        switch (choice1)//Displaying the instructor menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Instructor> instructors = storageManager.GetAllInstructors();//Calling the GetAllInstructors from storage manager
                                    view.DisplayInstructors(instructors);//Calling the DisplayInstructors from console view and returning that value 'instructors'
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
                                    Console.Clear();
                                    UpdateInstructorName(); //Calling this method
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
                                    Console.Clear();
                                    InsertNewInstructor();//Calling this method
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
                                    Console.Clear();
                                    DeleteInstructorByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.ClasstypeMenu();
                        switch (choice1)//Displaying the classtype menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<ClassType> classtypes = storageManager.GetAllClasstypes();//Calling the GetAllClasstypes from storage manager
                                    view.DisplayClasstypes(classtypes);//Calling the DisplayClasstypes from console view and returning that value 'classtypes'
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
                                    Console.Clear();
                                    UpdateClasstypeName(); //Calling this method
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
                                    Console.Clear();
                                    InsertNewClasstype();//Calling this method
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
                                    Console.Clear();
                                    DeleteClasstype();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.MemberTableMenu();
                        switch (choice1)//Displaying the member menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Member> members = storageManager.GetAllMembers();//Calling the GetAllMembers from storage manager
                                    view.DisplayMembers(members);//Calling the DisplayMembers from console view and returning that value 'members'
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
                                    Console.Clear();
                                    UpdateMemberFirstName();//Calling this method
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
                                    Console.Clear();
                                    InsertNewMember();//Calling this method
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
                                    Console.Clear();
                                    DeleteMemberByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.RoleMenu();
                        switch (choice1)//Displaying the  rolemenu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Role> roles = storageManager.GetAllRoles();//Calling the GetAllRoles from storage manager
                                    view.DisplayRoles(roles);//Calling the DisplayRoles from console view and returning that value 'roles'
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
                                    Console.Clear();
                                    UpdateRoleName();//Calling this method
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
                                    Console.Clear();
                                    InsertNewRole();//Calling this method
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
                                    Console.Clear();
                                    DeleteRoleByName();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.SessionbookingMenu();
                        switch (choice1)//Displaying the sessionbooking menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Sessionbooking> sessionbookings = storageManager.GetAllSessions();//Calling the GetAllSessions from storage manager
                                    view.DisplaySessions(sessionbookings);//Calling the DisplaySessions from console view and returning that value 'sessionbookings'
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
                                    Console.Clear();
                                    UpdateSessionDate(); //Calling this method
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
                                    Console.Clear();
                                    InsertNewSession();//Calling this method
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
                                    Console.Clear();
                                    DeleteSessionByID();//Calling this method
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
                        Console.Clear();
                        char close;
                        string choice1 = view.QueryMenu();
                        switch (choice1)//Displaying the query menu method
                        {
                            case "1":
                                {
                                    Console.Clear();
                                    List<Member> members = storageManager.Simple1QryMemberName();//Calling Simple1QryMemberName from storage manager
                                    view.Simple1QryMemberName(members);//Calling the SimpleQryMemberName method from console view and returning that value 'members'
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
                                    Console.Clear();
                                    List<ClassType> classtypes = storageManager.Simple2QryClassTypes();//Calling Simple2QryClasstypes from storage manager
                                    view.Simple2QryClassTypes(classtypes);//Calling the Simple2QryClassTypes method from console view and returning that value 'classtypes'
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
                                    Console.Clear();
                                    List<Member> members = storageManager.Simple3QryMemberContactDetails();//Calling Simple3QryMemberContactDetails from storage manager
                                    view.Simple3QryMemberContactDetails(members);//Calling the Simple3QryMemberContactDetails method from console view and returning that value 'members'
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
                                    Console.Clear();
                                    storageManager.Simple4QryGymLocation(); //Calling simple qry 4 from storage manager
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
                                    Console.Clear();
                                    storageManager.Simple5QrySessionDetails();//Calling simple qry 5 from storage manager
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
                                    Console.Clear();
                                    storageManager.Advanced1QryClassesUnder31();//Calling advanced qry 1 from storage manager
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
                                    Console.Clear();
                                    storageManager.Advanced2QryInstructorsStartingWithA();//Calling advanced qry 2 from storage manager
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
                                    Console.Clear();
                                    storageManager.Advanced3QryTop5MostExpensiveClasses();//Calling advanced qry 3 from storage manager
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
                                    Console.Clear();
                                    storageManager.Advanced4QryMembersWithGmailOrOutlook();//Calling advanced qry 4 from storage manager
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
                                    Console.Clear();
                                    storageManager.Advanced5QrySessionsAfter27April();//Calling advanced qry 5 from storage manager
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
                                    Console.Clear();
                                    storageManager.Complex1QryInstructorsWithSessions();//Calling complex qry 1 from storage manager
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
                                    Console.Clear();
                                    storageManager.Complex2QryRevenuePerClassType();//Calling complex qry 2 from storage manager
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
                                    Console.Clear();
                                    storageManager.Complex3QrySessionsUnder30();//Calling complex qry 3 from storage manager
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
                                    Console.Clear();
                                    storageManager.Complex4QryGymRevenue();//Calling complex qry 4 from storage manager
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
                                    Console.Clear();
                                    storageManager.Complex5QryMemberSessionBooked();//Calling complex qry 5 from storage manager
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
                    Console.WriteLine("Invalid option. Please try again."); //Message for if the user inputs something other than what is expected
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
            view.DisplayMessage("Enter the new instructors's pin (4-8 digits): ");
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
            view.DisplayMessage("Enter the new member's pin (4-8 digits): ");
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
                    Console.WriteLine("Invalid username or pin. Please try again.");
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
                    Console.WriteLine("Invalid username or pin. Please try again.");
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
                    Console.WriteLine("Invalid username or pin. Please try again.");
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
                    Console.WriteLine("Invalid username or pin. Please try again.");
                }

            } while (gymID == 0);

        }

        private static void InsertNewGymMember()
        {
            (string username1, int password1) = UsernamePassword();
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
            view.DisplayMessage("Enter the new member's pin (4-8 digits): ");
            int password = view.GetIntInput();
            int memberID = 0;
            int gymID = storageManager.GetGymID(username1, password1);
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
            (string username1, int password1) = UsernamePassword();
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();
            view.DisplayMessage("Enter the new instructor's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();
            view.DisplayMessage("Enter the new instructor's emailaddress: ");
            string emailaddress = view.GetInput();
            view.DisplayMessage("Enter the new instructor's username: ");
            string username = view.GetInput();
            view.DisplayMessage("Enter the new instructors's pin (4-8 digits): ");
            int password = view.GetIntInput();
            int roleID = 4;
            int gymID = storageManager.GetGymID(username1, password1);
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
                    Console.WriteLine("Invalid username or pin. Please try again.");
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