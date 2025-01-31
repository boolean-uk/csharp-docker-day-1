﻿using exercise.pizzashopapi.Models;

namespace exercise.wwwapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using (var db = new DataContext())
            {
                if (!db.Customers.Any())
                {
                    db.Add(new Customer() { Name = "Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    db.Add(new Customer() { Name = "Espen" });
                    await db.SaveChangesAsync();
                }
                if (!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple", Price = 123.45M });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic", Price = 124.89M });
                    db.Add(new Pizza() { Name = "Prosciutto", Price = 131.90M });
                    await db.SaveChangesAsync();

                }

                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    db.Add(new Order() { CustomerId = 2, PizzaId = 1, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    db.Add(new Order() { CustomerId = 1, PizzaId = 3, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    db.Add(new Order() { CustomerId = 3, PizzaId = 3, CreatedAt = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc) });
                    await db.SaveChangesAsync();
                }

                if (!db.Toppings.Any())
                {
                    db.Add(new Topping() { Name = "Pepperoni" });
                    db.Add(new Topping() { Name = "Ham" });
                    db.Add(new Topping() { Name = "Chicken" });
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
