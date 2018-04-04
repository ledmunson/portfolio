using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;
using System.Data.Entity;

namespace PapaBobs.Persistence
{
    public class OrdersRepository
    {
        public static List<DTO.DTOOrder> GetOrders()
        {
            var db = new PapaBobsDbEntities();
            var orders = db.Orders.Where(p => p.Completed == false).ToList();
            var ordersDTO = convertToDTO(orders);
            return ordersDTO;            
        }

        public static void CreateOrder(DTOOrder dtoOrder)
        {
            var db = new PapaBobsDbEntities();
            var order = convertToEntity(dtoOrder);
            db.Orders.Add(order);
            db.SaveChanges();
        }

        private static List<DTO.DTOOrder> convertToDTO(List<Order> orders)
        {
            var ordersDTO = new List<DTO.DTOOrder>();

            foreach (var order in orders)
            {
                var orderDTO = new DTO.DTOOrder();
                orderDTO.OrderId = order.OrderId;
                orderDTO.Crust = order.Crust;
                orderDTO.Size = order.Size;
                orderDTO.Name = order.Name;
                orderDTO.Address = order.Address;
                orderDTO.Zip = order.Zip;
                orderDTO.Phone = order.Phone;
                orderDTO.Sausage = order.Sausage;
                orderDTO.Pepperoni = order.Pepperoni;
                orderDTO.Onions = order.Onions;
                orderDTO.GreenPeppers = order.GreenPeppers;
                orderDTO.PaymentType = order.PaymentType;
                orderDTO.Completed = order.Completed;
                orderDTO.TotalCost = order.TotalCost;

                ordersDTO.Add(orderDTO);
            }
            return ordersDTO;
        }

        public static void CompleteOrder(Guid orderID)
        {
            var db = new PapaBobsDbEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderID);
            order.Completed = true;
            db.SaveChanges();
        }

        private static Order convertToEntity(DTOOrder dtoOrder)
        {
            var order = new Order();

            order.OrderId = dtoOrder.OrderId;
            order.Size = dtoOrder.Size;
            order.Crust = dtoOrder.Crust;
            order.Sausage = dtoOrder.Sausage;
            order.Pepperoni = dtoOrder.Pepperoni;
            order.Onions = dtoOrder.Onions;
            order.GreenPeppers = dtoOrder.GreenPeppers;
            order.Name = dtoOrder.Name;
            order.Address = dtoOrder.Address;
            order.Phone = dtoOrder.Phone;
            order.Zip = dtoOrder.Zip;
            order.TotalCost = dtoOrder.TotalCost;
            order.PaymentType = dtoOrder.PaymentType;
            order.Completed = dtoOrder.Completed;

            return order;
        }
    }
}
