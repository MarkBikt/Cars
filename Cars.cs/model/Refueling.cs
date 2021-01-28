using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    public class Refueling : IDataErrorInfo
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
                    case "Price":
                        if (Price < 0)
                        {
                            error = "Поле не может отрицательным!";
                        }
                        break;
                    case "Volume":
                        if (Volume <= 0)
                        {
                            error = "Поле не может быть меньше либо равено нулю!";
                        }
                        break;
                    case "CarMileage":
                        if (CarMileage < 0)
                        {
                            error = "Поле не может быть отрицательным!";
                        }
                        break;                  
                }
                return error;
            }
        }

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
        public override string ToString()
        {
            return $"Заправлено: {Volume} Потрачено: {Price}  Цена за литр: {PriceOneLiter}";
        }
    }
}
