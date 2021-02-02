using System;
using System.ComponentModel;

namespace Cars.cs.model
{
    public class Service : IDataErrorInfo
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

        public int? AutoId { get; set; }
        public virtual Auto Auto { get; set; }

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
        public override string ToString()
        {
            return $"{Name}  {Price}руб.";
        }
    }
}
