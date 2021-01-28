using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    /// <summary>
    /// Запчасти
    /// </summary>
    public class SparePart : IDataErrorInfo
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

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Name":
                        if (Name == null)
                        {
                            error = "Поле не может быть пустым!";
                        }
                        break;
                    case "Price":
                        if (Price < 0)
                        {
                            error = "Поле не может отрицательным!";
                        }
                        break;
                }
                return error;
            }
        }

        public int? AutoId { get; set; }
        public virtual Auto Auto { get; set; }


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
        public SparePart(string name, double price)
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
        }

        public override string ToString()
        {
            return $"{Name}  {Price}руб.";
        }
    }
}
