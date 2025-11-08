using Microsoft.AspNetCore.Mvc;
using MVCBooking.Models;
using System.Collections.Generic;

namespace MVCBooking.Controllers
{
    public class BookingController : Controller
    {
        // Privremena lista booking
        private static List<HotelBooking> _bookings = new List<HotelBooking>();
        private static int _nextID = 1;

        // GET: /Booking
        public IActionResult Index()
        {
            // Ako je bookings null, inicijaliziraj praznom listom
            return View(_bookings);
        }


        // GET: /Booking/Create
        public IActionResult Create()
        {
            return View(new HotelBooking());
        }

        // POST: /Booking/CreateBooking
        [HttpPost]
        public IActionResult CreateBooking(HotelBooking booking)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(booking.GuestName) || booking.RoomNumber <= 0)
            {
                return View("Create", booking);
            }

            booking.Id = _nextID++;
            _bookings.Add(booking);
            return RedirectToAction("Index");
        }
    }
}
