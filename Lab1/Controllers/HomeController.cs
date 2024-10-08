using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Lab1.Models;

namespace Lab1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(string op, double? a, double? b)
    {
        Operator operation;
        if (!Enum.TryParse(op, true, out operation))
        {
            operation = Operator.Unknown;
        }
        
        if (a == null || b == null)
        {
            ViewBag.Message = "Brak wartości dla a lub b!";
            ViewBag.Result = "N/A";
            ViewBag.Op = GetOperatorSymbol(operation);
            return View();
        }

        double result = 0;

        switch (operation)
        {
            case Operator.Add:
                result = a.Value + b.Value;
                break;
            case Operator.Sub:
                result = a.Value - b.Value;
                break;
            case Operator.Mul:
                result = a.Value * b.Value;
                break;
            case Operator.Div:
                if (b.Value != 0)
                {
                    result = a.Value / b.Value;
                }
                else
                {
                    ViewBag.Message = "Nie można dzielić przez zero!";
                    ViewBag.Result = "N/A";
                    return View();
                }
                break;
            default:
                ViewBag.Message = "Nieznany operator!";
                ViewBag.Result = "N/A";
                return View();
        }

        ViewBag.A = a;
        ViewBag.B = b;
        ViewBag.Result = result;
        ViewBag.Op = GetOperatorSymbol(operation);
        return View();
    }



    public enum Operator
    {
        Unknown, Add, Mul, Sub, Div
    }
    public string GetOperatorSymbol(Operator op)
    {
        return op switch
        {
            Operator.Add => "+",
            Operator.Sub => "-",
            Operator.Mul => "*",
            Operator.Div => "/",
            _ => "?"
        };
    }





    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
