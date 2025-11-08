using Microsoft.AspNetCore.Mvc;
using MVCBooking.Models;

namespace MVCBooking.Controllers
{
    public class BookingController : Controller
    {
        private static readonly List<HotelBooking> _bookings = new();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_bookings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new HotelBooking());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBooking(HotelBooking booking)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", booking);
            }

            booking.Id = _nextId++;
            _bookings.Add(booking);

            return RedirectToAction(nameof(Index));
        }
    }
}