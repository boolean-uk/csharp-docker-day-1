using System.Linq;
using exercise.pizzashopapi.Models;
using Microsoft.AspNetCore.Builder;

namespace exercise.pizzashopapi.Data
{
    public static class Seeder
    {
        public async static void SeedPizzaShopApi(this WebApplication app)
        {
            using(var db = new DataContext())
            {
                if(!db.Customers.Any())
                {
                    db.Add(new Customer() { Name="Nigel" });
                    db.Add(new Customer() { Name = "Dave" });
                    await db.SaveChangesAsync();
                }
                if(!db.Pizzas.Any())
                {
                    db.Add(new Pizza() { Name = "Cheese & Pineapple" });
                    db.Add(new Pizza() { Name = "Vegan Cheese Tastic" });
                    await db.SaveChangesAsync();

                }
                if (!db.DeliveryDrivers.Any())
                {
                    db.Add(new DeliveryDriver() { Name = "Hello" });
                    db.Add(new DeliveryDriver() { Name = "Bob" });
                    await db.SaveChangesAsync();

                }
                if (!db.Orders.Any())
                {
                    db.Add(new Order() { CustomerId = 1, PizzaId = 1, DeliveryDriverId = 1 });

                    db.Add(new Order() { CustomerId = 2, PizzaId = 2, DeliveryDriverId = 2});
                    await db.SaveChangesAsync();
                }

                //order data
                if(1==1)
                {

                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
