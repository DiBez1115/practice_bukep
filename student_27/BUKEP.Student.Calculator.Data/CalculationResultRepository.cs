using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BUKEP.Student.Calculator.Data
{
    public class CalculationResultRepository
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ConnectionToCalculator"].ConnectionString;

        public void SaveCalculationResult(CalculationResult result)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string resultCalculator = result.Result;

                string request = $"INSERT INTO СalculationResults (Result) VALUES ('{resultCalculator}')";

                SqlCommand command = new SqlCommand(request, connection);

                command.ExecuteNonQuery();
                
                connection.Close();
            }

        }

        public List<CalculationResult> GetCalculationResult()
        {
            List<CalculationResult> result = new List<CalculationResult>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string request = "SELECT * FROM СalculationResults";

                SqlCommand command = new SqlCommand(request, connection);

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    result.Add(new CalculationResult { Result = reader.GetString(1) });
                }

                connection.Close();
            }

            return result;
        }

        public void ClearCalculationResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string request = string.Format("TRUNCATE TABLE СalculationResults");

                SqlCommand command = new SqlCommand(request, connection);

                command.ExecuteNonQuery();
 
                connection.Close();
            }

        }

    }

}
