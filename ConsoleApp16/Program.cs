using System;
using System.Collections.Generic;
using System.Linq;

class Good
{
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
}

class Program
{
    static void Main()
    {
        List<Good> goods1 = new List<Good>()
        {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" },
            new Good()  { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good()  { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good()  { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good()  { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good()  { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
        };

        var OveMobil1000 = goods1.Where(g => g.Category == "Mobile" && g.Price > 1000);
        Console.WriteLine("Товары категории Mobile, цена которых превышает 1000 грн:");
        foreach (var mobile in OveMobil1000)
            Console.WriteLine($"- {mobile.Title}, {mobile.Price}");

        var OverNotKitchen1000 = goods1.Where(g => g.Category != "Kitchen" && g.Price > 1000)
                                       .Select(g => new { g.Title, g.Price });

        Console.WriteLine("\nНазвание и цена товаров, не относящихся к Kitchen, с ценой > 1000:");
        foreach (var item in OverNotKitchen1000)
            Console.WriteLine($"- {item.Title}, {item.Price}");

        var averagePrice = goods1.Average(g => g.Price);
        Console.WriteLine($"\nСреднее значение всех цен товаров: {averagePrice}");

        var uniCategories = goods1.Select(g => g.Category).Distinct();
        Console.WriteLine("\nСписок категорий без повторений:");
        foreach (var category in uniCategories)
            Console.WriteLine($"- {category}");

        var sortedGoods = goods1.OrderBy(g => g.Title).Select(g => new { g.Title, g.Category });
        Console.WriteLine("\nНазвания и категории товаров в алфавитном порядке:");
        foreach (var item in sortedGoods)
            Console.WriteLine($"- {item.Title} ({item.Category})");

        var carAndMobileCount = goods1.Count(g => g.Category == "Car" || g.Category == "Mobile");
        Console.WriteLine($"\nСуммарное количество товаров категорий Car и Mobile: {carAndMobileCount}");

        var categoryCounts = goods1.GroupBy(g => g.Category)
                                   .Select(group => new { Category = group.Key, Count = group.Count() });

        Console.WriteLine("\nСписок категорий и количество товаров каждой категории:");
        foreach (var category in categoryCounts)
            Console.WriteLine($"- {category.Category}: {category.Count}");
    }
}
