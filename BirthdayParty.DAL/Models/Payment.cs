﻿using System;
using System.Collections.Generic;

namespace BirthdayParty.DAL;

public partial class Payment
{
    public int PaymentId { get; set; }

    public decimal TotalPrice { get; set; }

    public string PaymentStatus { get; set; }

    public decimal DepositMoney { get; set; }

    public int BookingId { get; set; }
}