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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\samka\\OneDrive - Avondale College\\12TPIHandIn (3)\\12TPIHandIn\\GymDatabasePublish\\GymDatabase.mdf\";Integrated Security=True;Connect Timeout=30";
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
                        int roleID = Roleid(); //Calling the login menu to gather the user's roleID
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
                        close = char.Parse(Console.ReadLine().ToUpper()); //takes char input and converts it to upper case letters
                        Console.Clear(); //clears the page
                        if (close == 'N') //If the user chose 'N' will close the sql connection
                        {
                            storageManager.CloseConnection();
                            Environment.Exit(0);
                        }
                        else //If not, will continue on with the menu loop
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
            int gymID = view.GetIntInput(); //Grabs user input for gymID
            view.DisplayMessage("Enter the new gym name: ");
            string gymname = view.GetInput();//Grabs user input for gymname
            int rowsAffected = storageManager.UpdateGymName(gymID, gymname); //Calls method from storage manager and returns gymID and gymname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}"); //Displays how many records were affected
        }

        private static void InsertNewGym()
        {
            view.DisplayMessage("Enter the new gym name: ");
            string gymname = view.GetInput();//Grabs user input for gymname
            view.DisplayMessage("Enter the street address: ");
            string streetaddress = view.GetInput();//Grabs user input for streetaddress
            view.DisplayMessage("Enter the country ID: ");
            int countryID = view.GetIntInput();//Grabs user input for countryID
            view.DisplayMessage("Enter the city ID: ");
            int cityID = view.GetIntInput(); //Grabs user input for cityID
            view.DisplayMessage("Enter the suburb ID: ");
            int suburbID = view.GetIntInput();//Grabs user input for suburbID
            view.DisplayMessage("Enter the phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();//Grabs user input for phonenumber
            view.DisplayMessage("Enter the emailaddress: ");
            string emailaddress = view.GetInput();//Grabs user input for emailaddress
            view.DisplayMessage("Enter your username: ");
            string username = view.GetInput();//Grabs user input for username
            view.DisplayMessage("Enter the gym's pin (4-8 digits): ");
            int password = view.GetIntInput();//Grabs user input for password
            int roleID = 2; //Automatically makes roleID 2 as it is a gym
            int gymID = 0; //Defaults gymID as 0
            Gym gym1 = new Gym(gymID, gymname, streetaddress, countryID, cityID, suburbID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.InsertGym(gym1); //Calls method from storage manager and returns value gym1
            view.DisplayMessage($"New gym inserted with ID: {generatedID}"); //Displays variable to show the new gym's ID

        }

        private static void DeleteGymByName()
        {
            view.DisplayMessage("Enter the gym name to delete: ");
            string gymname = view.GetInput();//Grabs user input for gymname
            int rowsAffected = storageManager.DeleteGymByName(gymname);//Calls method from storage manager and returns gymname field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateCountryName()
        {

            view.DisplayMessage("Enter the countryID to update: ");
            int countryID = view.GetIntInput();//Grabs user input for countryID
            view.DisplayMessage("Enter the new country name: ");
            string countryname = view.GetInput();//Grabs user input for countryname
            int rowsAffected = storageManager.UpdateCountryName(countryID, countryname);//Calls method from storage manager and returns countryID and countryname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewCountry()
        {
            view.DisplayMessage("Enter the new country name: ");
            string countryname = view.GetInput();//Grabs user input for countryname
            int countryID = 0;//Defaults countryID as 0
            Country country1 = new Country(countryID, countryname);
            int generatedID = storageManager.InsertCountry(country1);//Calls method from storage manager and returns value country1
            view.DisplayMessage($"New country inserted with ID: {generatedID}");//Displays variable to show the new countries ID

        }

        private static void DeleteCountryByName()
        {
            view.DisplayMessage("Enter the country name to delete: ");
            string countryname = view.GetInput();//Grabs user input for countryname
            int rowsAffected = storageManager.DeleteCountryByName(countryname);//Calls method from storage manager and returns countryname field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateCityName()
        {

            view.DisplayMessage("Enter the cityID to update: ");
            int cityID = view.GetIntInput();//Grabs user input for cityID
            view.DisplayMessage("Enter the new city name: ");
            string cityname = view.GetInput();//Grabs user input for cityname
            int rowsAffected = storageManager.UpdateCityName(cityID, cityname);//Calls method from storage manager and returns cityID and cityname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewCity()
        {
            view.DisplayMessage("Enter the new city name: ");
            string cityname = view.GetInput();//Grabs user input for cityname
            int cityID = 0;//Defaults cityID as 0
            City city1 = new City(cityID, cityname);
            int generatedID = storageManager.InsertCity(city1);//Calls method from storage manager and returns value city1
            view.DisplayMessage($"New city inserted with ID: {generatedID}");//Displays variable to show the new cities ID

        }

        private static void DeleteCityByName()
        {
            view.DisplayMessage("Enter the city name to delete: ");
            string cityname = view.GetInput();//Grabs user input for cityname
            int rowsAffected = storageManager.DeleteCityByName(cityname);//Calls method from storage manager and returns cityname field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateSuburbName()
        {

            view.DisplayMessage("Enter the suburbID to update: ");
            int suburbID = view.GetIntInput();//Grabs user input for suburbID
            view.DisplayMessage("Enter the new suburb name: ");
            string suburbname = view.GetInput();//Grabs user input for suburbname
            int rowsAffected = storageManager.UpdateSuburbName(suburbID, suburbname);//Calls method from storage manager and returns suburbID and suburbname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewSuburb()
        {
            view.DisplayMessage("Enter the new suburb name: ");
            string suburbname = view.GetInput();//Grabs user input for suburbname
            int suburbID = 0;//Defaults suburbID as 0
            Suburb suburb1 = new Suburb(suburbID, suburbname);
            int generatedID = storageManager.InsertSuburb(suburb1);//Calls method from storage manager and returns value suburb1
            view.DisplayMessage($"New suburb inserted with ID: {generatedID}");//Displays variable to show the new suburbs ID

        }

        private static void DeleteSuburbByName()
        {
            view.DisplayMessage("Enter the suburb name to delete: ");
            string suburbname = view.GetInput();//Grabs user input for suburbname
            int rowsAffected = storageManager.DeleteSuburbByName(suburbname);//Calls method from storage manager and returns suburbname field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateInstructorName()
        {

            view.DisplayMessage("Enter the instructorID to update: ");
            int instructorID = view.GetIntInput();//Grabs user input for instructorID
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();//Grabs user input for instructorname
            int rowsAffected = storageManager.UpdateInstructorName(instructorID, instructorname);//Calls method from storage manager and returns instructorID and instructorname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewInstructor()
        {
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();//Grabs user input for instructorname
            view.DisplayMessage("Enter the gym ID that the instructor is with: ");
            int gymID = view.GetIntInput();//Grabs user input for gymID
            view.DisplayMessage("Enter the new instructor's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();//Grabs user input for phonenumber
            view.DisplayMessage("Enter the new instructor's emailaddress: ");
            string emailaddress = view.GetInput();//Grabs user input for emailaddress
            view.DisplayMessage("Enter the new instructor's username: ");
            string username = view.GetInput();//Grabs user input for username
            view.DisplayMessage("Enter the new instructors's pin (4-8 digits): ");
            int password = view.GetIntInput();//Grabs user input for password/pin
            int roleID = 4;//Automatically makes roleID 4 as it is an instructor
            int instructorID = 0;//Defaults instructorID as 0
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.InsertInstructor(instructor1);//Calls method from storage manager and returns value instructor1
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}");//Displays variable to show the new instructors ID

        }

        private static void DeleteInstructorByName()
        {
            view.DisplayMessage("Enter the instructor name to delete: ");
            string instructorname = view.GetInput();//Grabs user input for instructorname
            int rowsAffected = storageManager.DeleteInstructorByName(instructorname);//Calls method from storage manager and returns instructorname field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateClasstypeName()
        {

            view.DisplayMessage("Enter the classtypeID to update: ");
            int classtypeID = view.GetIntInput();//Grabs user input for classtypeID
            view.DisplayMessage("Enter the new classtype name: ");
            string classtype = view.GetInput();//Grabs user input for classtypename
            int rowsAffected = storageManager.UpdateClasstypeName(classtypeID, classtype);//Calls method from storage manager and returns classtypeID and classtype fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewClasstype()
        {
            view.DisplayMessage("Enter the new classtype: ");
            string classtype = view.GetInput();//Grabs user input for classtype
            view.DisplayMessage("Enter the price of the new classtype: ");
            int classprice = view.GetIntInput();//Grabs user input for classprice
            int classtypeID = 0;//Defaults instructorID as 0
            ClassType classtype1 = new ClassType(classtypeID, classtype, classprice);
            int generatedID = storageManager.InsertClasstype(classtype1);//Calls method from storage manager and returns value classtype1
            view.DisplayMessage($"New class type inserted with ID: {generatedID}");//Displays variable to show the new classtypes ID

        }

        private static void DeleteClasstype()
        {
            view.DisplayMessage("Enter the classtype to delete: ");
            string classtype = view.GetInput();//Grabs user input for classtype
            int rowsAffected = storageManager.DeleteClasstype(classtype);//Calls method from storage manager and returns classtype field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateMemberFirstName()
        {

            view.DisplayMessage("Enter the memberID to update: ");
            int memberID = view.GetIntInput();//Grabs user input for memberID
            view.DisplayMessage("Enter the new member's first name: ");
            string firstname = view.GetInput();//Grabs user input for firstname
            int rowsAffected = storageManager.UpdateMemberFirstName(memberID, firstname);//Calls method from storage manager and returns memberID and firstname fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewMember()
        {
            view.DisplayMessage("Enter the new member's firstname: ");
            string firstname = view.GetInput();//Grabs user input for firstname
            view.DisplayMessage("Enter the new member's lastname: ");
            string lastname = view.GetInput();//Grabs user input for lastname
            view.DisplayMessage("Enter the new member's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();//Grabs user input for phonenumber
            view.DisplayMessage("Enter the new member's emailaddress: ");
            string emailaddress = view.GetInput();//Grabs user input for emailaddress
            view.DisplayMessage("Enter the member's gym ID: ");
            int gymID = view.GetIntInput();//Grabs user input for gymID
            view.DisplayMessage("Enter the new member's username: ");         
            string username = view.GetInput();//Grabs user input for username
            view.DisplayMessage("Enter the new member's pin (4-8 digits): ");
            int password = view.GetIntInput();//Grabs user input for password
            int memberID = 0;//Defaults memberID as 0
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, 1);
            int generatedID = storageManager.InsertMember(member1);//Calls method from storage manager and returns value member1
            view.DisplayMessage($"New member inserted with ID: {generatedID}");//Displays variable to show the new members ID

        }

        private static void DeleteMemberByName()
        {
            view.DisplayMessage("Enter the member's firstname: ");
            string firstname = view.GetInput();//Grabs user input for firstname
            view.DisplayMessage("Enter the member's lastname: ");
            string lastname = view.GetInput();//Grabs user input for lastname
            int rowsAffected = storageManager.DeleteMemberByName(firstname, lastname);//Calls method from storage manager and returns firstname and lastname fields
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateRoleName()
        {

            view.DisplayMessage("Enter the roleID to update: ");
            int roleID = view.GetIntInput();//Grabs user input for roleID
            view.DisplayMessage("Enter the new role name: ");
            string rolename = view.GetInput();//Grabs user input for rolename
            int rowsAffected = storageManager.UpdateRoleName(roleID, rolename);//Calls method from storage manager and returns roleID and rolename fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewRole()
        {
            view.DisplayMessage("Enter the new role name: ");
            string rolename = view.GetInput();//Grabs user input for rolename
            int roleID = 0;//Defaults roleID as 0
            Role role1 = new Role(roleID, rolename);
            int generatedID = storageManager.InsertRole(role1);//Calls method from storage manager and returns value role1
            view.DisplayMessage($"New role inserted with ID: {generatedID}");//Displays variable to show the new roles ID

        }

        private static void DeleteRoleByName()
        {
            view.DisplayMessage("Enter the role name to delete: ");
            string rolename = view.GetInput();//Grabs user input for rolename
            int rowsAffected = storageManager.DeleteRoleByName(rolename);//Calls method from storage manager and returns rolename field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void UpdateSessionDate()
        {

            view.DisplayMessage("Enter the sessionID to update: ");
            int sessionID = view.GetIntInput();//Grabs user input for sessionID
            view.DisplayMessage("Enter the new session date: ");
            DateTime sessiondate = view.GetDateTimeInput();//Grabs user input for sessiondate
            int rowsAffected = storageManager.UpdateSessionDate(sessionID, sessiondate);//Calls method from storage manager and returns sessionID and sessiondate fields
            view.DisplayMessage($"Rows affected: {rowsAffected}");//Displays how many records were affected
        }

        private static void InsertNewSession()
        {
            view.DisplayMessage("Enter the instructor's ID: ");
            int instructorID = view.GetIntInput();//Grabs user input for instructorID
            view.DisplayMessage("Enter the classtype's ID: ");
            int classtypeID = view.GetIntInput();//Grabs user input for classtypeID
            view.DisplayMessage("Enter the member's ID: ");
            int memberID = view.GetIntInput();//Grabs user input for memberID
            view.DisplayMessage("Enter the gym's ID: ");
            int gymID = view.GetIntInput();//Grabs user input for gymID
            view.DisplayMessage("Enter the sessiondate: ");
            DateTime sessiondate = view.GetDateTimeInput();//Grabs user input for sessiondate
            int sessionID = 0;//Defaults roleID as 0
            Sessionbooking sessionbooking1 = new Sessionbooking(sessionID, instructorID, classtypeID, memberID, gymID, sessiondate);
            int generatedID = storageManager.InsertSession(sessionbooking1);//Calls method from storage manager and returns value sessionbooking1
            view.DisplayMessage($"New session inserted with ID: {generatedID}");//Displays variable to show the new sessions ID

        }

        private static void DeleteSessionByID()
        {
            view.DisplayMessage("Enter the sessionID to delete: ");
            int sessionID = view.GetIntInput();//Grabs user input for sessionID
            int rowsAffected = storageManager.DeleteSessionByID(sessionID);//Calls method from storage manager and returns sessionID field
            view.DisplayMessage($"Rows Affected: {rowsAffected}");//Displays how many records were affected
        }

        private static (string username, int password) login() //Method used to take login details
        {
            (string username, int password) = view.LoginMenu(); //Calls the Login menu and returns input for the username and password

            return (username, password); //returns username and password values
        }

        private static int Roleid()
        {
            int roleID; //declaring roleID

            do
            {
                (string username, int password) = login(); //takes the username and password values from login()
                roleID = storageManager.GetUserRole(username, password); //Runs storagemanager method to obtain the user's roleID

                if (roleID == 0) //If user's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or pin. Please try again."); //Displays error message
                }
            } while (roleID == 0);//do-while loop to keep looping method while the roleID is incorrect
            return (roleID); //returns roleID value
        }

        private static void ViewMemberSessions()
        {
            int memberID; //declaring memberID

            do
            {
                (string username, int password) = login(); //calls login method and return username and password details
                memberID = storageManager.GetMemberID(username, password); //Calls method from storage manager to capture the memberID from the username and password fields
                storageManager.ViewMemberSessions(memberID); //Calls another method from storage manager and returns memberID value

                if (memberID == 0) //If member's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or pin. Please try again."); //DIsplays error message
                }

            } while (memberID == 0);//do-while loop to keep looping method while the memberID is incorrect

        }
        
        private static void ViewGymSessions()
        {
            int gymID;//declaring gymID

            do
            {
                (string username, int password) = login();//calls login method and return username and password details
                gymID = storageManager.GetGymID(username, password);//Calls method from storage manager to capture the gymID from the username and password fields
                storageManager.ViewGymSessions(gymID);//Calls another method from storage manager and returns memberID value

                if (gymID == 0)//If gym's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or pin. Please try again.");//DIsplays error message
                }

            } while (gymID == 0); //do-while loop to keep looping method while the gymID is incorrect

        }

        private static void InsertNewGymSession()
        {
            (string username, int password) = login(); //calls login method and returns username and password fields
            view.DisplayMessage("Enter the instructor's ID: ");
            int instructorID = view.GetIntInput(); //Gathers user's input for instructor ID
            view.DisplayMessage("Enter the classtype's ID: ");
            int classtypeID = view.GetIntInput();//Gathers user's input for classtypeID
            view.DisplayMessage("Enter the member's ID: ");
            int memberID = view.GetIntInput();//Gathers user's input for memberID
            view.DisplayMessage("Enter the sessiondate: Year - Month - Day Hour:Minute:Second.123");
            DateTime sessiondate = view.GetDateTimeInput();//Gathers user's input for sessiondate
            int gymID = storageManager.GetGymID(username, password); //Calls the GetGymID method from storage manager to obtain the gymID from the username and password
            int sessionID = 0; //Defaults session ID as 0
            Sessionbooking sessionbooking1 = new Sessionbooking(sessionID, instructorID, classtypeID, memberID, gymID, sessiondate);
            int generatedID = storageManager.InsertGymSession(sessionbooking1); //Calls method from storage manager and returns sessionbooking1 value
            view.DisplayMessage($"New session inserted with ID: {generatedID}"); //Displays the sessions new ID

        }

        private static void ViewGymMembers()
        {
            int gymID;

            do
            {
                (string username, int password) = login();//calls login method and returns username and password fields
                gymID = storageManager.GetGymID(username, password);//Calls the GetGymID method from storage manager to obtain the gymID from the username and password
                storageManager.ViewGymMembers(gymID); //Calls this method from storage manager to view all members that have the same gymID as the user's gymID

                if (gymID == 0)//If gym's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or pin. Please try again.");//DIsplays error message
                }

            } while (gymID == 0);//do-while loop to keep looping method while the gymID is incorrect

        }

        private static void InsertNewGymMember()
        {
            (string username1, int password1) = login();//calls login method and returns username and password fields
            view.DisplayMessage("Enter the new member's firstname: ");
            string firstname = view.GetInput();//Gathers user's input for firstname
            view.DisplayMessage("Enter the new member's lastname: ");
            string lastname = view.GetInput();//Gathers user's input for lastname
            view.DisplayMessage("Enter the new member's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();//Gathers user's input for phonenumber
            view.DisplayMessage("Enter the new member's emailaddress: ");
            string emailaddress = view.GetInput();//Gathers user's input for emailaddress
            view.DisplayMessage("Enter the new member's username: ");
            string username = view.GetInput();//Gathers user's input for username
            view.DisplayMessage("Enter the new member's pin (4-8 digits): ");
            int password = view.GetIntInput();//Gathers user's input for password
            int memberID = 0; //Defaults memberID as 0
            int gymID = storageManager.GetGymID(username1, password1); //Calls the GetGymID method from storage manager to obtain the gymID from the username and password
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, 1);
            int generatedID = storageManager.InsertMember(member1);//Calls method from storage manager and returns member1 value
            view.DisplayMessage($"New member inserted with ID: {generatedID}");//Displays the new member's ID

        }

        private static void DeleteGymMember()
        {

                (string username, int password) = login();//calls login method and returns username and password fields
                view.DisplayMessage("Enter the member's firstname: ");
                string firstname = view.GetInput();//Gathers user's input for firstname
            view.DisplayMessage("Enter the member's lastname: ");
                string lastname = view.GetInput();//Gathers user's input for lastname
            int gymID = storageManager.GetGymID(username, password);//Calls the GetGymID method from storage manager to obtain the gymID from the username and password
            int rowsAffected = storageManager.DeleteGymMember(firstname, lastname, gymID); //Calls deletegymmember method from storage manager and returns firstname, lastname, and gymID fields
                if (rowsAffected == 0)//If gym's ID stays 0, meaning the username and password doesn't currently exist in the database
            {
                    view.DisplayMessage("Invalid member, please log back in after closing this app and retry"); //Error Message
                }
                else //If gym's ID changes then will show how many records were altered in the database
                {
                    view.DisplayMessage($"Rows Affected: {rowsAffected}");
                }
        }

        private static void ViewGymInstructors()
        {
            int gymID;//declaring gymID

            do
            {
                (string username, int password) = login();//calls login method and returns username and password fields
                gymID = storageManager.GetGymID(username, password);//Calls the GetGymID method from storage manager to obtain the gymID from the username and password
                storageManager.ViewGymInstructors(gymID); //Calls method from storage manager and returns gymID field

                if (gymID == 0)//If gym's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or password. Please try again."); //Error message
                }

            } while (gymID == 0);//Will continue loop if gymID stays invalid

        }

        private static void InsertNewGymInstructor()
        {
            (string username1, int password1) = login();//calls login method and returns username and password fields
            view.DisplayMessage("Enter the new instructor name: ");
            string instructorname = view.GetInput();//Gathers user's input for instructorname
            view.DisplayMessage("Enter the new instructor's phonenumber: ");
            Int64 phonenumber = view.GetInt64Input();//Gathers user's input for phonenumber
            view.DisplayMessage("Enter the new instructor's emailaddress: ");
            string emailaddress = view.GetInput();//Gathers user's input for emailaddress
            view.DisplayMessage("Enter the new instructor's username: ");
            string username = view.GetInput();//Gathers user's input for username
            view.DisplayMessage("Enter the new instructors's pin (4-8 digits): ");
            int password = view.GetIntInput();//Gathers user's input for password
            int roleID = 4; //automatically declaring roleID as 4 as it is an instructor
            int gymID = storageManager.GetGymID(username1, password1);//Calls the GetGymID method from storage manager to obtain the gymID from the username and password
            int instructorID = 0; //Defaults instructorID as 0
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.InsertInstructor(instructor1); //Calls insertinstructor method from storage manager and returns isntructor1 value
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}"); //Displays the new instructor's ID

        }

        private static void DeleteGymInstructor()
        {
            (string username, int password) = login();//calls login method and returns username and password fields
            view.DisplayMessage("Enter the instructor name to delete: ");
            string instructorname = view.GetInput();//Gathers user's input for instructorname
            int gymID = storageManager.GetGymID(username, password);//Calls the GetGymID method from storage manager to obtain the gymID from the username and password
            int rowsAffected = storageManager.DeleteGymInstructor(instructorname, gymID);//Calls deletegymmember method from storage manager and returns instructorname and gymID fields
            if (rowsAffected == 0)//If rows affected stays 0, meaning no instructor was found
            {
                view.DisplayMessage("Invalid instructor, please log back in after closing this app and retry");//Error message
            }
            else//If gym's ID changes then will show how many records were altered in the database
            {
                view.DisplayMessage($"Rows Affected: {rowsAffected}"); //Displays how many records were altered
            }
        }

        private static void ViewInstructorSessions()
        {
            int instructorID;//declaring instructorID variable

            do
            {
                (string username, int password) = login();//calls login method and returns username and password fields
                instructorID = storageManager.GetInstructorID(username, password);//Calls the GetInstructorID method from storage manager to obtain the instructorID from the username and password
                storageManager.ViewInstructorSessions(instructorID);//Calls method from storage manager and returns instructorID field

                if (instructorID == 0)//If instructor's ID stays 0, meaning the username and password doesn't currently exist in the database
                {
                    Console.WriteLine("Invalid username or pin. Please try again.");//Error message
                }

            } while (instructorID == 0);//Will continue loop if instructorID stays invalid

        }


        private static void RegisterMember()
        {
            view.DisplayMessage("Enter your firstname: ");
            string firstname = view.GetInput(); //Takes user input for firstname
            view.DisplayMessage("Enter your lastname: ");
            string lastname = view.GetInput();//Takes user input for lastname
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();//Takes user input for phonenumber
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();//Takes user input for emailaddress
            view.DisplayMessage("Enter your gym's ID: ");
            int gymID = view.GetIntInput();//Takes user input for gymID
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();//Takes user input for username
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();//Takes user input for password
            int roleID = 1; //Manually making the roleID 1 as we're registering a member
            int memberID = 0; //making the memberID 0 as a default
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID);
            int generatedID = storageManager.RegisterMember(member1); //Calls method from storage manager and returns member1
            view.DisplayMessage($"New member inserted with ID: {generatedID}"); //Displays the new member's ID
        }
        
        private static void RegisterGym()
        {
            view.DisplayMessage("Enter your gym's name: ");
            string gymname = view.GetInput();//Takes user input for gymname
            view.DisplayMessage("Enter your gym's street address: ");
            string streetaddress = view.GetInput();//Takes user input for streetaddress
            view.DisplayMessage("Enter the country ID where your gym is located: ");
            int countryID = view.GetIntInput();//Takes user input for countryID
            view.DisplayMessage("Enter the city ID where your gym is located: ");
            int cityID = view.GetIntInput();//Takes user input for cityID
            view.DisplayMessage("Enter the suburb ID where your gym is located: ");
            int suburbID = view.GetIntInput();//Takes user input for suburbID
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();//Takes user input for phonenumber
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();//Takes user input for emailaddress
            view.DisplayMessage("Enter your gym's username: ");
            string username = view.GetInput();//Takes user input for username
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();//Takes user input for pin 
            int roleID = 2; //Making the roleID 2 as we're registering a gym
            int gymID = 0;//Default gymID is 0
            Gym gym1 = new Gym(gymID, gymname, streetaddress, countryID, cityID, suburbID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.RegisterGym(gym1); //Calling method from storage manager and returning gym1
            view.DisplayMessage($"New gym inserted with ID: {generatedID}"); //displaying the gym's new ID
        }
        
        private static void RegisterAdmin()
        {
            view.DisplayMessage("Enter your firstname: ");
            string firstname = view.GetInput();//Takes user input for firstname
            view.DisplayMessage("Enter your lastname: ");
            string lastname = view.GetInput();//Takes user input for lastname
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();//Takes user input for phonenumber
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();//Takes user input for emailaddress
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();//Takes user input for username
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();//Takes user input for password
            int roleID = 3; //Making the roleID 3 as we're registering an admin
            int memberID = 0; //Default memberID is 0
            int gymID = 1; //Default gymID is 1
            Member member1 = new Member(memberID, firstname, lastname, phonenumber, emailaddress, gymID, username, password, roleID);
            int generatedID = storageManager.RegisterAdmin(member1);//Calling method from storage manager and returning member1
            view.DisplayMessage($"New admin inserted with ID: {generatedID}"); //displaying the gym's new ID
        }
        
        private static void RegisterInstructor()
        {
            view.DisplayMessage("Enter your name: ");
            string instructorname = view.GetInput();//Takes user input for instructorname
            view.DisplayMessage("Enter the gymID of the gym you work for: ");
            int gymID = view.GetIntInput();//Takes user input for gymID
            view.DisplayMessage("Enter your phonenumber (no spaces in between): ");
            Int64 phonenumber = view.GetInt64Input();//Takes user input for phonenumber
            view.DisplayMessage("Enter your emailaddress: ");
            string emailaddress = view.GetInput();//Takes user input for emailaddress
            view.DisplayMessage("Enter your user name: ");
            string username = view.GetInput();//Takes user input for username
            view.DisplayMessage("Enter your pin (4-8 digits): ");
            int password = view.GetIntInput();//Takes user input for password
            int roleID = 4; //Making the roleID 4
            int instructorID = 0; //Defaulting the instructor ID as 0
            Instructor instructor1 = new Instructor(instructorID, instructorname, gymID, phonenumber, emailaddress, username, password, roleID);
            int generatedID = storageManager.RegisterInstructor(instructor1); //Calling RegisterInstructor from storage manager and returning instructor1
            view.DisplayMessage($"New instructor inserted with ID: {generatedID}");//Displaying the instructor's new ID
        }




    }
}