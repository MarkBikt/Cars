using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class Refueling
    {
        /// <summary>
        /// Цена за литр
        /// </summary>
        public double PriceOneLiter => Price / Volume;
        /// <summary>
        /// Цена одной заправки
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Объем одной заправки
        /// </summary>
        public double Volume { get; set; }

        public Refueling(double price, double volume)
        {
            if (price >= 0 && volume > 0)
            {               
                Price = price;
                Volume = volume;
            }
            else
            {
                throw new ArgumentException("Ни один из аргументов не может быть меньше нуля");
            }
        }
    }
}
