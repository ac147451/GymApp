﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using GymApp.DBFile.Model;

namespace GymApp.View
{
    public class ConsoleView
    {
        public string DisplayMenu()
        {
            Console.WriteLine("Welcome to my Gym");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Gym Table");
            Console.WriteLine("2. Country Table");
            Console.WriteLine("3. City Table");
            Console.WriteLine("4. Suburb Table");
            Console.WriteLine("5. Instructor Table");
            Console.WriteLine("6. Classtype Table");
            Console.WriteLine("7. Member Table");
            Console.WriteLine("8. Role Table");
            Console.WriteLine("9. Sessionbooking Table");
            Console.WriteLine("Please choose a table to change: ");


            return Console.ReadLine();
        }

        public string GymMenu()
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Gym");
            Console.WriteLine("2. Update a gym's name by gymID");
            Console.WriteLine("3. Insert a new gym");
            Console.WriteLine("4. Delete a gym by gymname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string CountryMenu()
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Country");
            Console.WriteLine("2. Update a countries name by countryID");
            Console.WriteLine("3. Insert a new country");
            Console.WriteLine("4. Delete a country by countryname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string CityMenu()
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in City");
            Console.WriteLine("2. Update a cities name by cityID");
            Console.WriteLine("3. Insert a new city");
            Console.WriteLine("4. Delete a city by cityname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string SuburbMenu()
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Suburb");
            Console.WriteLine("2. Update a suburbs name by suburbID");
            Console.WriteLine("3. Insert a new suburb");
            Console.WriteLine("4. Delete a suburb by suburbname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string InstructorMenu()
        {
            //Console.Clear();
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Instructor");
            Console.WriteLine("2. Update an instructors name by instructorID");
            Console.WriteLine("3. Insert a new instructor");
            Console.WriteLine("4. Delete an instructor by instructorname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public void DisplayGyms(List<Gym> gyms)
        {
            foreach (Gym gym in gyms)
            {
                Console.WriteLine($"{gym.Gym_id}, {gym.Gym_name}");
            }
        }

        public void DisplayCountries(List<Country> countries)
        {
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Country_id}, {country.Country_name}");
            }
        }

        public void DisplayCities(List<City> cities)
        {
            foreach (City city in cities)
            {
                Console.WriteLine($"{city.City_id}, {city.City_name}");
            }
        }

        public void DisplaySuburbs(List<Suburb> suburbs)
        {
            foreach (Suburb suburb in suburbs)
            {
                Console.WriteLine($"{suburb.Suburb_id}, {suburb.Suburb_name}");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }

        public int GetIntInput()
        {
            return int.Parse(Console.ReadLine());
        }

    }
}
