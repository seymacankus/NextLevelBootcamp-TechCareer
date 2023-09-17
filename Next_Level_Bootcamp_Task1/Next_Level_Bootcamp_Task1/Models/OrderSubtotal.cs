using System;
using System.Collections.Generic;

namespace Next_Level_Bootcamp_Task1.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
