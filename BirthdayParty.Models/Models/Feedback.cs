using System;
using System.Collections.Generic;

namespace BirthdayParty.DAL;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string Description { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; }
}
