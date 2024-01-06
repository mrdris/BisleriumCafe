using BisleriumCafe.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BisleriumCafe.Data.Provider;
public static class CoffeeService
{
    private static void SaveAll(Guid userId, List<CoffeeItem> todos)
    {
        string appDataDirectoryPath = FilePath.GetAppDirectoryPath();
        string coffeeFilePath = FilePath.GetCoffeeFilePath(userId);

        if (!Directory.Exists(appDataDirectoryPath))
        {
            Directory.CreateDirectory(appDataDirectoryPath);
        }

        var json = JsonSerializer.Serialize(todos);
        File.WriteAllText(coffeeFilePath, json);
    }

    public static List<CoffeeItem> GetAll(Guid userId)
    {
        string CoffeeFilePath = FilePath.GetCoffeeFilePath(userId);
        if (!File.Exists(CoffeeFilePath))
        {
            return new List<CoffeeItem>();
        }

        var json = File.ReadAllText(CoffeeFilePath);

        return JsonSerializer.Deserialize<List<CoffeeItem>>(json);
    }

    public static List<CoffeeItem> Create(Guid userId, string coffeeName, string price, DateTime orderedAt)
    {
        //if (dueDate < DateTime.Today)
        //{
        //    throw new Exception("Due date must be in the future.");
        //}

        List<CoffeeItem> coffeeBills = GetAll(userId);
        coffeeBills.Add(new CoffeeItem
        {
            coffeeName = coffeeName,
            price = price,
            orderedAt = orderedAt,
        });
        SaveAll(userId, coffeeBills);
        return coffeeBills;
    }

    public static List<CoffeeItem> Delete(Guid userId, Guid id)
    {
        List<CoffeeItem> coffeeBills = GetAll(userId);
        CoffeeItem coffeeInfo = coffeeBills.FirstOrDefault(x => x.Id == id);

        if (coffeeBills == null)
        {
            throw new Exception("Todo not found.");
        }

        coffeeBills.Remove(coffeeInfo);
        SaveAll(userId, coffeeBills);
        return coffeeBills;
    }

    public static void DeleteByUserId(Guid userId)
    {
        string todosFilePath = FilePath.GetCoffeeFilePath(userId);
        if (File.Exists(todosFilePath))
        {
            File.Delete(todosFilePath);
        }
    }

    public static List<CoffeeItem> Update(Guid userId, Guid id, string coffeeName, string price, DateTime orderedAt)
    {
        List<CoffeeItem> coffeeBills = GetAll(userId);
       CoffeeItem coffeeToUpdate = coffeeBills.FirstOrDefault(x => x.Id == id);

        if (coffeeToUpdate == null)
        {
            throw new Exception("Todo not found.");
        }

        coffeeToUpdate.coffeeName = coffeeName;
        coffeeToUpdate.price = price;
        SaveAll(userId, coffeeBills);
        return coffeeBills;
    }
}


