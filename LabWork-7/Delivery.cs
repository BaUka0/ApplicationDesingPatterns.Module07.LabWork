using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7
{
    public interface IShippingStrategy
    {
        decimal CalculateShippingCost(decimal weight, decimal distance);
    }

    public class StandardShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m;
        }
    }
    public class ExpressShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 0.75m + distance * 0.2m) + 10; // Дополнительная плата за скорость
        }
    }
    public class InternationalShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return (weight * 1.0m + distance * 0.5m) + 15; // Дополнительные сборы за международную доставку
        }
    }
    public class NightShippingStrategy : IShippingStrategy
    {
        public decimal CalculateShippingCost(decimal weight, decimal distance)
        {
            return weight * 0.5m + distance * 0.1m + 30; // Дополнительная плата за срочность
        }
    }
    public class DeliveryContext
    {
        private IShippingStrategy _shippingStrategy;

        // Метод для установки стратегии доставки
        public void SetShippingStrategy(IShippingStrategy strategy)
        {
            _shippingStrategy = strategy;
        }

        // Метод для расчета стоимости доставки
        public decimal CalculateCost(decimal weight, decimal distance)
        {
            if (_shippingStrategy == null)
            {
                throw new InvalidOperationException("Стратегия доставки не установлена.");
            }
            return _shippingStrategy.CalculateShippingCost(weight, distance);
        }
    }


    internal class Delivery
    {
    }
}
