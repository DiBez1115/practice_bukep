using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUKEP.Student.Calculator.Data
{
    /// <summary>
    /// Класс хранящий результаты вычисления калькулятора.
    /// </summary>
    public class CalculationResult
    {
        /// <summary>
        /// Хранит ID результата.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Хранит результат вычисления.
        /// </summary>
        public decimal Result { get; set; }
    }

}
