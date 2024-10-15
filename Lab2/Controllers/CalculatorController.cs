using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpPost]
        public IActionResult Result([FromForm] Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            
            Console.WriteLine("DivideByZero: " + model.DivideByZero);
            Console.WriteLine("Operator: " + model.Operator);
            Console.WriteLine("Wartość Y: " + model.Y);

            return View(model);
        }
        
        public IActionResult Form()
        {
            return View();
        }
    }
}