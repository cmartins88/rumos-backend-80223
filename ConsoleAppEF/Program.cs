﻿// See https://aka.ms/new-console-template for more information
using ConsoleAppEF.Data;
using ConsoleAppEF.Models;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        using (ApplicationDbContext db = new ApplicationDbContext())
        {
            // CRUD operations - Create / Read / Update / Delete

            // insert
            db.Products.Add(new()
            {
                Name = "Test",
                Description = "Test",
                Category = PRODUCT_CATEGORY.Sumos,
                Price = 0.2D
            });
            db.SaveChanges();

            // select
            var last_product = db.Products.OrderBy(p => p.Id).Last();
            var product = db.Products.Where(p => p.Id == 3).Single();

            var last_product_s = (from p in db.Products
                                  orderby p.Id
                                  select p).Last();

            var product_s = (from p in db.Products
                             where p.Id == 3
                             select p).Single();

            // update
            last_product.Name = "New product name";
            db.SaveChanges();

            // remove
            //db.Products.Remove(product);
            //db.SaveChanges();

            db.Add<Order>(new()
            {
                OrderDate = DateTime.Now,
                Description = "compra teste",
                Products = new[] { product, last_product }
            });
            db.SaveChanges();


            var product_8 = db.Products.Where(p => p.Id == 8).Include("Order").Single();
            Console.WriteLine($"Produto comprado na data: {product_8.Order.OrderDate}");



        }
    }
}