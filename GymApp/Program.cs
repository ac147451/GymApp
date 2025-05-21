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
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"B51282CAD28FE80C2E657E4ED5124728_TABASE\\SOURCE\\REPOS\\AC147451\\GYMDATABASE\\GYMDATABASE\\SQLSCRIPTS\\SQL SCRIPTS\\GYMAPP DATABASE.MDF\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManager = new StorageManager(connectionString);
            ConsoleView view = new ConsoleView();
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

            //storageManager.Closeconnection();
           
        }

    }
}

/*
case "5":
                    exit = true;
                    break;
*/