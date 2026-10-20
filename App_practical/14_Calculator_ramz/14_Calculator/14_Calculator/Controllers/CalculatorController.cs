using _14_Calculator.Data;
using _14_Calculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Controllers;

public enum Operation { Add, Subtract, Multiply, Divide }

public class CalculatorController(CalculatorDbContext db) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.History = await db.DataInputVariants.OrderByDescending(x => x.ID_DataInputVariant).Take(20).ToListAsync();
        return View("~/Views/Home/Index.cshtml");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Calculate(double num1, double num2, Operation operation)
    {
        string? error = null;
        double result = 0;
        switch (operation)
        {
            case Operation.Add: result = num1 + num2; break;
            case Operation.Subtract: result = num1 - num2; break;
            case Operation.Multiply: result = num1 * num2; break;
            case Operation.Divide:
                if (num2 == 0) error = "Деление на ноль";
                else result = num1 / num2;
                break;
            default: error = "Неизвестная операция"; break;
        }

        if (error is not null) ViewBag.Error = error;
        else
        {
            ViewBag.Result = result;
            db.DataInputVariants.Add(new CalculationRecord
            {
                Operand_1 = num1, Operand_2 = num2, Type_operation = operation.ToString(),
                Result = result, CreatedAt = DateTime.UtcNow
            });
            await db.SaveChangesAsync();
        }
        ViewBag.History = await db.DataInputVariants.OrderByDescending(x => x.ID_DataInputVariant).Take(20).ToListAsync();
        ViewBag.Num1 = num1; ViewBag.Num2 = num2; ViewBag.Operation = operation.ToString();
        return View("~/Views/Home/Index.cshtml");
    }
}
