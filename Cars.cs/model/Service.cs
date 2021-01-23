using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class Service
    {
        /// <summary>
        /// Название услуги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стоимость услуги
        /// </summary>
        public double Price { get; set; }
        public Service(string name, double price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (price >= 0)
            {
                Price = price;
            }
            else
            {
                throw new ArgumentException("Цена не может быть меньше нуля", nameof(price));
            }
        }
    }
}
