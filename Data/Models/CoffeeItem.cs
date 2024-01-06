using BisleriumCafe.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Models;

public class CoffeeItem : IModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string coffeeName { get; set; }

    public string price { get; set; }
    public DateTime orderedAt { get; set; } = DateTime.Now;
}

