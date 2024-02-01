using System;
using System.Collections.Generic;

namespace BirthdayParty.DAL;

public partial class Booking
{
    public int BookingId { get; set; }

    public int UserId { get; set; }

    public int RoomId { get; set; }

    public DateTime BookingDate { get; set; }

    public string BookingStatus { get; set; }

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual Package Room { get; set; }

    public virtual User User { get; set; }
}
