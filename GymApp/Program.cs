using GymApp.Repositories;

namespace GymApp
{
    public class Program
    {
        private static StorageManager storageManger;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=\"GymApp Database\";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            storageManger = new StorageManager(connectionString);
        }
    }
}
