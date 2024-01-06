using BisleriumCafe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Provider;
public class GlobalState
{
    public User CurrentUser { get; set; }
}
