﻿using System;
using System.Collections.Generic;

namespace BirthdayParty.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceName { get; set; }

    public decimal ServicePrice { get; set; }

    public int PackageId { get; set; }

    public virtual ICollection<BookingService> BookingServices { get; set; } = new List<BookingService>();

    public virtual Package Package { get; set; }
}
