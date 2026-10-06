using Microsoft.AspNetCore.Mvc;
namespace Calculator.Controllers
{
    public enum Operation
    {
        Add, Subtract, Multiply, Divide
    }
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(double num1, double
       num2, Operation operation)
        {
            double result = 0;
            string errore = null;
            switch (operation)
            {
                case Operation.Add:
                    result = num1 + num2;
                    break;
                case Operation.Subtract:
                    result = num1 - num2;
                    break;
                case Operation.Multiply:
                    result = num1 * num2;
                    break;
                case Operation.Divide:
                    if (num2 == 0)
                    {
                        errore = "Деление на ноль";
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
            }
            if (errore != null)
            {
                ViewBag.Error = errore;
            }
            else
            {
                ViewBag.Result = result;
            }
                return View("~/Views/Home/Index.cshtml"); ;
        }
    }
}