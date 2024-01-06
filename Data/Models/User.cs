using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BisleriumCafe.Data.Enums;
namespace BisleriumCafe.Data.Models;

public class User: IModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
    public bool HasInitialPassword { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Guid CreatedBy { get; set; }
}

    