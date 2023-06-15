using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Результат вычисления
    /// </summary>
    public class CalculationResult
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Результат
        /// </summary>
        public decimal Result { get; set; }
    }

}
