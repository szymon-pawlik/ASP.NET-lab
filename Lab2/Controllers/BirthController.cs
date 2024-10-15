using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab2.Controllers
{
    public class BirthController : Controller
    {
        // GET: Wyświetla formularz
        public IActionResult Form()
        {
            return View();
        }

        // POST: Obsługuje przesłane dane z formularza
        [HttpPost]
        public IActionResult Result([FromForm] Birth model)
        {
            if (!model.IsValid())
            {
                return View("Error"); // Jeśli dane są nieprawidłowe, wyświetl widok błędu
            }

            return View(model); // Przekazanie modelu do widoku wynikowego
        }
    }
}