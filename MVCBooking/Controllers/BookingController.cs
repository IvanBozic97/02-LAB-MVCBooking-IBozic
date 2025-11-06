using Microsoft.AspNetCore.Mvc;
using MVCBooking.Models;
using System.Collections.Generic;

namespace MVCBooking.Controllers
{
    public class BookingController : Controller
    {
        // Privremena lista bookinga
        private static List<HotelBooking> bookings = new List<HotelBooking>();

        // GET: /Booking
        public IActionResult Index()
        {
            // Ako je bookings null, inicijaliziraj praznom listom
            var model = bookings ?? new List<HotelBooking>();
            return View("~/Views/Shared/Index.cshtml", model);
        }


        // GET: /Booking/Create
        public IActionResult Create()
        {
            return View("~/Views/Shared/Create.cshtml", new HotelBooking());
        }

        // POST: /Booking/CreateBooking
        [HttpPost]
        public IActionResult CreateBooking(HotelBooking booking)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(booking.GuestName) || booking.RoomNumber <= 0)
            {
                return View("~/Views/Shared/Create.cshtml", booking);
            }

            booking.Id = bookings.Count + 1;
            bookings.Add(booking);
            return RedirectToAction("Index");
        }
    }
}
