using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.Persistence;

namespace PapaBobs.DTO
{
    public class Orders
    {
        public System.Guid OrderId { get; set; }
        public Size Size { get; set; }
        public Crust Crust { get; set; }
        public bool Sausage { get; set; }
        public bool Pepperoni { get; set; }
        public bool Onions { get; set; }
        public bool GreenPeppers { get; set; }
        public decimal TotalCost { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public Nullable<PaymentType> PaymentType { get; set; }
        public bool Completed { get; set; }
    }
}
