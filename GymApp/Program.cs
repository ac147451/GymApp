using GymApp;
using GymApp.DBFile.Model;
using GymApp.View;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace GymApp
{
    public class Program
    {
        private static StorageManager storageManager;
        private static ConsoleView view;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"B51282CAD28FE80C2E657E4ED5124728_TABASE\\SOURCE\\REPOS\\AC147451\\GYMDATABASE\\GYMDATABASE\\SQLSCRIPTS\\SQL SCRIPTS\\GYMAPP DATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            view = new ConsoleView();
            string choice = view.DisplayMenu();

            switch (choice)
            {
                case "1":
                    {
                        List<Gym> gyms = storageManager.GetAllGyms();
                        view.DisplayGyms(gyms);
                    }
                    break;

                case "2":
                    UpdateGymName();
                    break;

                case "3":
                    InsertNewGym();
                    break;

                case "4":
                    DeleteGymByName();
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
            int gymID = 0;
            Gym gym1 = new Gym(gymID, gymname);
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

    }
}

/*
   case "5":
                    exit = true;
                    break;
*/