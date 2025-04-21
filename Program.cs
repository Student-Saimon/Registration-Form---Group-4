using System;
using MySql.Data.MySqlClient;

namespace RegistrationForm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Registration Form");

            Console.Write("Enter your whole name: ");
            string wholeName = Console.ReadLine();

            Console.Write("Enter your student number: ");
            string studentNumber = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter your cellphone number: ");
            string cellphoneNumber = Console.ReadLine();

            // Update with your actual MySQL server information
            string connectionString = "Server=YOUR_SERVER;Database=YOUR_DATABASE;Uid=YOUR_USERNAME;Pwd=YOUR_PASSWORD;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (WholeName, StudentNumber, Age, CellphoneNumber) VALUES (@WholeName, @StudentNumber, @Age, @CellphoneNumber)";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@WholeName", wholeName);
                    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@CellphoneNumber", cellphoneNumber);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Student registered successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
