﻿using System;
using System.Collections.Generic;

namespace BirthdayParty.DAL;

public partial class Room
{
    public int RoomId { get; set; }

    public string RoomName { get; set; }

    public int Capacity { get; set; }

    public int Price { get; set; }
}
