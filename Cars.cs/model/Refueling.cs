using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class Refueling
    {
        public int Id { get; set; }
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
        /// <summary>
        /// Пробег
        /// </summary>
        public double CarMileage { get; set; }
        /// <summary>
        /// Заправка
        /// </summary>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объем</param>
        /// <param name="carMileage">Пробег</param>

        public Refueling()
        {

        }
        public Refueling(double price, double volume, double carMileage)
        {
            if (price >= 0 && volume > 0 && carMileage >= 0)
            {
                CarMileage = carMileage;
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
