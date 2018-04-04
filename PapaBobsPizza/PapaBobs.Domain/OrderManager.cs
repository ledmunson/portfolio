using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;

namespace PapaBobs.Domain
{
    public class OrderManager
    {
        public static void CreateOrder(DTOOrder dTOOrder)
        {
            //Validation
            if (dTOOrder.Name.Trim().Length == 0)
                throw new Exception("Name is required.");

            if (dTOOrder.Address.Trim().Length == 0)
                throw new Exception("Address is required.");

            if (dTOOrder.Zip.Trim().Length == 0)
                throw new Exception("Zip is required.");

            if (dTOOrder.Phone.Trim().Length == 0)
                throw new Exception("Phone is required.");


            dTOOrder.OrderId = Guid.NewGuid();
            dTOOrder.TotalCost = PizzaPriceManager.CalculateCost(dTOOrder);

            Persistence.OrdersRepository.CreateOrder(dTOOrder);
        }

        public static void CompleteOrder(Guid orderID)
        {
            Persistence.OrdersRepository.CompleteOrder(orderID);
        }

        public static object GetOrders()
        {
            return Persistence.OrdersRepository.GetOrders();   
        }
    }
}
