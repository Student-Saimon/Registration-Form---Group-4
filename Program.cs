using System;
using System.Data.SqlClient;

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

            // Replace YOUR_SERVER and YOUR_DATABASE with your actual SQL Server info
            string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (WholeName, StudentNumber, Age, CellphoneNumber) VALUES (@WholeName, @StudentNumber, @Age, @CellphoneNumber)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@WholeName", wholeName);
                    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@CellphoneNumber", cellphoneNumber);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        Console
