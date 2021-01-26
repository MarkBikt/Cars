using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    /// <summary>
    /// Запчасти
    /// </summary>
    public class SparePart
    {
        public int Id { get; set; }
        /// <summary>
        /// Название запчасти
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цена запчасти
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Стоимость замены
        /// </summary>
        public double RepPrice { get; set; }

        public SparePart()
        {

        }
        /// <summary>
        /// Создание запчасти
        /// </summary>
        /// <param name="name">Название</param>
        /// <param name="price">Цена</param>
        /// <param name="repPrice">Цена замены</param>
        /// 
        public SparePart(string name, double price, double repPrice)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if(price >= 0)
            {
                Price = price;
            }
            else
            {
                throw new ArgumentException("Цена не может быть меньше нуля", nameof(price));
            }

            if(repPrice >= 0)
            {
                RepPrice = repPrice;
            }
            else
            {
                throw new ArgumentException("Цена не может быть меньше нуля", nameof(repPrice));
            }                      
        }
    }
}
