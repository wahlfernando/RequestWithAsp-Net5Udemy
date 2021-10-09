using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_Net5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");

        }

        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult GetSub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");

        }

        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult GetMulti(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");

        }

        [HttpGet("divsao/{firstNumber}/{secondNumber}")]
        public IActionResult GetDiv(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");

        }

        [HttpGet("media/{firstNumber}/{secondNumber}/{tercNumber}")]
        public IActionResult GetMedia(string firstNumber, string secondNumber, string tercNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && IsNumeric(tercNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber) + ConvertToDecimal(tercNumber);
                var media = sum / 3;
                return Ok(media.ToString());
            }
            return BadRequest("Invalid Input");

        }

        [HttpGet("raiz/{firstNumber}")]
        public IActionResult Getraiz(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                double raiz;

                double valorRadicando = Convert.ToSingle(Math.Sqrt(ConvertToDouble(firstNumber)));
                
                return Ok(valorRadicando);
            }

            return BadRequest("Deu ruim");

        }


        //metodo para ver se é numérico
        private bool IsNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;
        }

        //metodo para converter para decimal
        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        //metodo para converter para double
        private double ConvertToDouble(string strNumber)
        { 
            double doubleValue;

            if (double.TryParse(strNumber, out doubleValue))
            {
                return Convert.ToDouble(strNumber, System.Globalization.CultureInfo.InvariantCulture);
            }
            return 0;
        }


    }
}
