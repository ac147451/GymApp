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
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\ac147451\\OneDrive - Avondale College\\12TPISQL\\GymApp\\GymApp\\DBFile\\GymDatabase\\source\\repos\\ac147451\\GymDatabase\\GymDatabase\\SQLScripts\\SQL Scripts\\GymApp Database.mdf\";Integrated Security=True;Connect Timeout=30";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1": //Gym Table
                    {
                        string choice1 = view.GymMenu();
                        switch (choice1)
                        {
                            case "1":
                                {
                                    List<Gym> gyms = storageManager.GetAllGyms();
                                    view.DisplayGyms(gyms);
                                    view.DisplayMessage("Enter any button to go back to Main Menu");
                                    Console.ReadLine();
                                    Console.Clear();
                                    view.DisplayMenu();
                                }
                                break;

                            case "2":
                                UpdateGymName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "3":
                                InsertNewGym();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "4":
                                DeleteGymByName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
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
                                    view.DisplayMenu();
                                }
                                break;

                            case "2":
                                UpdateCountryName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "3":
                                InsertNewCountry();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "4":
                                DeleteCountryByName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
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
                                    view.DisplayMenu();
                                }
                                break;

                            case "2":
                                UpdateCityName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "3":
                                InsertNewCity();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "4":
                                DeleteCityByName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
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
                                    view.DisplayMenu();
                                }
                                break;

                            case "2":
                                UpdateSuburbName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "3":
                                InsertNewSuburb();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;

                            case "4":
                                DeleteSuburbByName();
                                view.DisplayMessage("Enter any button to go back to Main Menu");
                                Console.ReadLine();
                                Console.Clear();
                                view.DisplayMenu();
                                break;
                        }

                    }
                    break;

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

    }
}






/*
   case "5":
                    exit = true;
                    break;
*/