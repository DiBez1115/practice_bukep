using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace BUKEP.Student.Calculator.Data
{

    /// <summary>
    /// Класс доступа к результатам вычисления.
    /// </summary>
    public class CalculationResultRepository
    {
        /// <summary>
        /// Cтрока подключения к базе данных.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Создать новый экземпляр репозитория.
        /// </summary>
        /// <param name="connectionString">Строка подключения к базе данных.</param>
        public CalculationResultRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Сохранить результаты вычисления.
        /// </summary>
        /// <param name="result">Результат, который нужно сохранить.</param>
        public void SaveCalculationResult(CalculationResult result)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string resultCalculator = Convert.ToString(result.Result).Replace(',', '.');

                string request = $"INSERT INTO СalculationResults (Result) VALUES ('{resultCalculator}')";

                SqlCommand command = new SqlCommand(request, connection);

                command.ExecuteNonQuery();
                
                connection.Close();
            }

        }

        /// <summary>
        /// Получить все результаты вычисления.
        /// </summary>
        /// <returns>Возвращает лист с результатами.</returns>
        public List<CalculationResult> GetCalculationResult()
        {
            List<CalculationResult> result = new List<CalculationResult>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string request = "SELECT Id, Result FROM СalculationResults ORDER BY Id ASC";

                SqlCommand command = new SqlCommand(request, connection);

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    result.Add(new CalculationResult 
                    { 
                        Id = reader.GetInt32(0), 

                        Result = reader.GetDecimal(1) 
                    });

                }

                connection.Close();
            }

            return result;
        }

        /// <summary>
        /// Отчистить таблицу от данных.
        /// </summary>
        public void ClearCalculationResults()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string request = string.Format("DELETE FROM СalculationResults");

                SqlCommand command = new SqlCommand(request, connection);

                command.ExecuteNonQuery();
 
                connection.Close();
            }

        }

    }

}
