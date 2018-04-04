using FinalExercise_V3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalExercise_V3.Models;

namespace FinalExercise_V3.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        ProductsDbEntities OrderDb = new ProductsDbEntities();

        public TblOrder Add(TblOrder item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            // TO DO : Code to save record into database
            ProductsDbEntities OrderDb = new ProductsDbEntities();
            OrderDb.TblOrders.Add(item);
            OrderDb.SaveChanges();
            return item;

        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database

           TblOrder orders = OrderDb.TblOrders.Find(id);
           OrderDb.TblOrders.Remove(orders);
           OrderDb.SaveChanges();

           return true;
        }

        public TblOrder Get(int id)
        {
            return OrderDb.TblOrders.Find(id);
        }

        public IEnumerable<TblOrder> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return OrderDb.TblOrders;
        }

        public bool Update(TblOrder item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            // TO DO : Code to update record into database

            var orders = OrderDb.TblOrders.Single(a => a.Id == item.Id);
            orders.Product = item.Product;
            orders.Category = item.Category;
            orders.Subtotal = item.Subtotal;
            orders.Quantity = item.Quantity;
            OrderDb.SaveChanges();

            return true;
        }
    }
}