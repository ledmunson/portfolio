using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBobs.DTO
{
    public class DTOOrder
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
        public PaymentType PaymentType { get; set; }
        public bool Completed { get; set; }

    }


    public enum Size
    {
        Small,
        Medium,
        Large
    }

    public enum Crust
    {
        Regular,
        Thin,
        Thick
    }

    public enum PaymentType
    {
        Cash,
        Credit
    }
}
