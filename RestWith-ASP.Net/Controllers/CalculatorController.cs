using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWith_ASP.Net.Controllers
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

        [HttpGet("/{firstNumber}/{operation}/{secondNumber}")]
        public IActionResult Exec(string firstNumber, string operation, string secondNumber)
        {
            double n1, n2;
            if (IsNumeric(firstNumber, out n1) && IsNumeric(secondNumber, out n2))
            {
                double sum = 0;

                switch (operation)
                {
                    case "+":
                        sum = n1 + n2;
                        break;
                    case "-":
                        sum = n1 - n2;
                        break;
                    case "*":
                        sum = n1 * n2;
                        break;
                    case "/":
                        sum = n1 / n2;
                        break;

                    default:
                        return BadRequest("Invalid Operation");
                }
             

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Input");
        }



        private bool IsNumeric(string str, out double value)
        {

            return double.TryParse(str, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out value);
        }
    }
}
