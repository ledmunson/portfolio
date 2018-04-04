using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBobs.DTO;

namespace PapaBobs.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(DTO.DTOOrder order)
        {
            decimal cost = 0.0M;
            var prices = getPizzaPrices();
            cost += calculateSizeCost(order, prices);
            cost += calculateCrustCost(order, prices);
            cost += calculateToppings(order, prices);
            return cost;
        }

        private static decimal calculateToppings(DTOOrder order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            cost += (order.Sausage) ? prices.SausageCost : 0M;
            cost += (order.Pepperoni) ? prices.PepperoniCost : 0M;
            cost += (order.Onions) ? prices.OnionsCost : 0M;
            cost += (order.GreenPeppers) ? prices.GreenPeppersCost : 0M;
            return cost;
        }

        private static decimal calculateCrustCost(DTOOrder order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case Crust.Regular:
                    cost = prices.RegularCrustCost;
                    break;
                case Crust.Thin:
                    cost = prices.ThinCrustCost;
                    break;
                case Crust.Thick:
                    cost = prices.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal calculateSizeCost(DTOOrder order, DTO.PizzaPriceDTO prices)
        {
            decimal cost = 0.0M;
            switch (order.Size)
            {
                case Size.Small:
                    cost = prices.SmallSizeCost;
                    break;
                case Size.Medium:
                    cost = prices.MediumSizeCost;
                    break;
                case Size.Large:
                    cost = prices.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static DTO.PizzaPriceDTO getPizzaPrices()
        {
            var prices = Persistence.PizzaPriceRepository.GetPizzaPrices();
            return prices;
        }
    }
}
