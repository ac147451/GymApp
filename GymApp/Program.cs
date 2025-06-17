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
                        string choice2 = view.CountryMenu();
                        switch (choice2)
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

    }
}






/*
   case "5":
                    exit = true;
                    break;
*/