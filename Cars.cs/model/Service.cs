using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class Service
    {
        public int Id { get; set; }
        /// <summary>
        /// Название услуги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Стоимость услуги
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Создание услуги
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="price">Цена</param>

        public Service()
        {

        }
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
