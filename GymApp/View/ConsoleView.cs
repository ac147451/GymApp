﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Identity;
using GymApp.DBFile.Model;

namespace GymApp.View
{
    public class ConsoleView
    {
        public string MainMenu() // Login / Register Menu
        {
            Console.WriteLine("Welcome to my Database");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Login: ");
            Console.WriteLine("2. Register: ");
            Console.WriteLine("Please choose one");

            return Console.ReadLine();
        }

        public (string username, int password) LoginMenu() //Menu to Login
        {
            Console.WriteLine("Please enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your pin: ");
            int password = Convert.ToInt32(Console.ReadLine());

            return (username, password);
            
        }

        public string RegisterMenu() //Menu to Register
        {
            Console.WriteLine("Who are you?");
            Console.WriteLine("1. A Member of a gym");
            Console.WriteLine("2. A Gym");
            Console.WriteLine("3. Admin");
            Console.WriteLine("4. Class Instructor for a gym");
            Console.WriteLine("Please choose one of the above: ");

            return Console.ReadLine();
        }

        public string MemberMenu() //Menu for Members
        {
            Console.WriteLine("Welcome Member");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View which sessions you are signed up for ");
            Console.WriteLine("Please choose what you want to do: ");

            return Console.ReadLine();
        }

        public string GymMenu() //Menu For Gyms
        {
            Console.WriteLine("Welcome Gym");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. Manage Sessions");
            Console.WriteLine("2. Manage Members");
            Console.WriteLine("3. Manage Instructors");
            Console.WriteLine("Choose a table to manage: ");

            return Console.ReadLine();
        }

        public string GymSessionsMenu() //Menu for Gyms to manage their sessions
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View All Sessions");
            Console.WriteLine("2. Insert a new session");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string GymMembersMenu() // Menu for Gyms to manage their members
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all members");
            Console.WriteLine("2. Insert a new member");
            Console.WriteLine("3. Delete a member of your gym");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string GymInstructorsMenu() //Menu for Gyms to manage their instructors
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all Instructors");
            Console.WriteLine("2. Insert a new instructor");
            Console.WriteLine("3. Delete an instructor of your gym");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string DisplayAdminMenu() //Menu For Admins
        {
            Console.WriteLine("Welcome Admin");
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
            Console.WriteLine("10. Queries");
            Console.WriteLine("Please choose a table to manage or query: ");


            return Console.ReadLine();
        }
        
        public string InstructorMenu() //Menu for Instructors
        {
            Console.WriteLine("Welcome Instructor");
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View which sessions you are instructing ");
            Console.WriteLine("Please choose what you want to do: ");

            return Console.ReadLine();
        }

        public string GymTableMenu() //Menu for Admin to manage the Gym table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Gym");
            Console.WriteLine("2. Update a gym's name by gymID");
            Console.WriteLine("3. Insert a new gym");
            Console.WriteLine("4. Delete a gym by gymname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string CountryMenu() //Menu for Admin to manage the Country table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Country");
            Console.WriteLine("2. Update a countries name by countryID");
            Console.WriteLine("3. Insert a new country");
            Console.WriteLine("4. Delete a country by countryname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string CityMenu() //Menu for Admin to manage the City table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in City");
            Console.WriteLine("2. Update a cities name by cityID");
            Console.WriteLine("3. Insert a new city");
            Console.WriteLine("4. Delete a city by cityname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string SuburbMenu() //Menu for Admin to manage the Suburb table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Suburb");
            Console.WriteLine("2. Update a suburbs name by suburbID");
            Console.WriteLine("3. Insert a new suburb");
            Console.WriteLine("4. Delete a suburb by suburbname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string InstructorTableMenu() //Menu for Admin to manage the Instructor table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all records in Instructor");
            Console.WriteLine("2. Update an instructors name by instructorID");
            Console.WriteLine("3. Insert a new instructor");
            Console.WriteLine("4. Delete an instructor by instructorname");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string ClasstypeMenu() //Menu for Admin to manage the Classtype table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all classtypes");
            Console.WriteLine("2. Update a classtype by classtypeID");
            Console.WriteLine("3. Insert a new classtype");
            Console.WriteLine("4. Delete a classtype by the name of the classtype");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string MemberTableMenu() //Menu for Admin to manage the Member table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all members");
            Console.WriteLine("2. Update a member's first name by memberID");
            Console.WriteLine("3. Insert a new member");
            Console.WriteLine("4. Delete a member by the name of the member");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string RoleMenu() //Menu for Admin to manage the Role table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all roles");
            Console.WriteLine("2. Update a role's name by roleID");
            Console.WriteLine("3. Insert a role");
            Console.WriteLine("4. Delete a role by the name of the role");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string SessionbookingMenu() //Menu for Admin to manage the Sessionbooking table
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. View all sessions");
            Console.WriteLine("2. Update a session's date by sessionID");
            Console.WriteLine("3. Insert a new session");
            Console.WriteLine("4. Delete a session by sessionID");
            Console.WriteLine("Select an option: ");

            return Console.ReadLine();
        }

        public string QueryMenu() //Menu for Admin to manage the Queries
        {
            Console.WriteLine("Menu: ");
            Console.WriteLine("1. QryMemberNames");
            Console.WriteLine("2. QryClassTypes");
            Console.WriteLine("3. QryMemberContactDetails");
            Console.WriteLine("4. QryGymLocations");
            Console.WriteLine("5. QrySessionDetails");
            Console.WriteLine("6. QryClassesUnder$31");
            Console.WriteLine("7. QryInstructorsStartingWithTheLetter'A'");
            Console.WriteLine("8. QryTop5MostExpensiveClasses");
            Console.WriteLine("9. QryMembersWithGmailOrOutlook");
            Console.WriteLine("10. QrySessionsAfter27April");
            Console.WriteLine("11. QryInstructorsWithSessions");
            Console.WriteLine("12. QryRevenuePerClassType");
            Console.WriteLine("13. QryAmountOfSessionsUnder$30");
            Console.WriteLine("14. QryGymRevenue");
            Console.WriteLine("15. QryMemberSessionsBooked");

            return Console.ReadLine();
        }
        public void DisplayGyms(List<Gym> gyms) //Used to Display Gyms
        {
            foreach (Gym gym in gyms)
            {
                Console.WriteLine($"{gym.Gym_id}, {gym.Gym_name}, {gym.Streetaddress}");
            }
        }

        public void DisplayCountries(List<Country> countries)//Used to Display Countries
        {
            foreach (Country country in countries)
            {
                Console.WriteLine($"{country.Country_id}, {country.Country_name}");
            }
        }

        public void DisplayCities(List<City> cities)//Used to Display Cities
        {
            foreach (City city in cities)
            {
                Console.WriteLine($"{city.City_id}, {city.City_name}");
            }
        }

        public void DisplaySuburbs(List<Suburb> suburbs)//Used to Display Suburbs
        {
            foreach (Suburb suburb in suburbs)
            {
                Console.WriteLine($"{suburb.Suburb_id}, {suburb.Suburb_name}");
            }
        }

        public void DisplayInstructors(List<Instructor> instructors)//Used to Display Instructors
        {
            foreach (Instructor instructor in instructors)
            {
                Console.WriteLine($"{instructor.Instructor_id}, {instructor.Instructor_name}");
            }
        }

        public void DisplayClasstypes(List<ClassType> classtypes)//Used to Display Classtypes
        {
            foreach (ClassType classtype in classtypes)
            {
                Console.WriteLine($"{classtype.Classtype_id}, {classtype.Classtype}, {classtype.Classprice}");
            }
        }

        public void DisplayMembers(List<Member> members)//Used to Display Members
        {
            foreach (Member member in members)
            {
                Console.WriteLine($"{member.Member_id}, {member.Firstname}, {member.Lastname}, {member.Phonenumber}, {member.Emailaddress}");
            }
        }

        public void Simple1QryMemberName(List<Member> members)//Used to Display SimpleQry1
        {
            foreach (Member member in members)
            {
                Console.WriteLine($"{member.Member_id}, {member.Firstname}, {member.Lastname}");
            }
        }

        public void Simple2QryClassTypes(List<ClassType> classtypes)//Used to Display SimpleQry2
        {
            foreach (ClassType classtype in classtypes)
            {
                Console.WriteLine($"{classtype.Classtype}, {classtype.Classprice}");
            }
        }

        public void Simple3QryMemberContactDetails(List<Member> members)//Used to Display SimpleQry3
        {
            foreach (Member member in members)
            {
                Console.WriteLine($"{member.Member_id}, {member.Firstname}, {member.Lastname}, {member.Phonenumber}, {member.Emailaddress}");
            }
        }

        public void DisplayRoles(List<Role> roles)//Used to Display Roles
        {
            foreach (Role role in roles)
            {
                Console.WriteLine($"{role.Role_id}, {role.Rolename}");
            }
        }

        public void DisplaySessions(List<Sessionbooking> sessionbookings)//Used to Display Sessions
        {
            foreach (Sessionbooking sessionbooking in sessionbookings)
            {
                Console.WriteLine($"{sessionbooking.Session_id}, {sessionbooking.Sessiondate}");
            }
        }

        public void DisplayMessage(string message)//Used to display messages
        {
            Console.WriteLine(message);
        }

        public string GetInput()//Used to gather input
        {
            return Console.ReadLine();
        }

        public int GetIntInput()//Used to gather int inputs
        {
            return int.Parse(Console.ReadLine());
        }

        public Int64 GetInt64Input()//Used to gather phonenumbers
        {
            return Int64.Parse(Console.ReadLine());
        }

        public DateTime GetDateTimeInput()//Used to gather datetime fields
        {
            return DateTime.Parse(Console.ReadLine());
        }

    }
}
