using BirthdayParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayParty.DAL.Validate
{
    public class ValidateBooking
    {
        public bool IsValid(Booking booking)
        {
            return ValidateBookingDate(booking.BookingDate);
        }

        private static bool ValidateBookingDate(DateTime bookingDate)
        {
            // Check if bookingDate is not before today + 2 days
            return bookingDate >= DateTime.Today.AddDays(2);
        }
    }
}
