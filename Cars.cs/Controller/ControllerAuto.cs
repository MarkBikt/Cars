using Cars.cs.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.Controller
{
    public class ControllerAuto
    {
        /// <summary>
        /// Списко автомобилей
        /// </summary>
        public List<Auto> Cars { get; set; }

        public ControllerAuto()
        {

        }
        /// <summary>
        /// Добавление автомобиля
        /// </summary>
        /// <param name="carBrand">Марка</param>
        /// <param name="carModel">Модель</param>
        /// <param name="gosNumber">Гос. номер</param>
        /// <param name="autoYear">Год выпуска</param>
        /// <param name="color">Цвет</param>
        /// <param name="carMilage">Пробег</param>
        /// <param name="fuelVolume">Объем бака</param>
        public void Add(string carBrand, string carModel, string gosNumber, int autoYear, string color, int carMilage, double fuelVolume)
        {
            Cars.Add(new Auto(carBrand, carModel, gosNumber, autoYear, color, carMilage, fuelVolume));
        }

        /// <summary>
        /// Поиск авто по гос. номеру
        /// </summary>
        /// <param name="gosNumber"></param>
        /// <returns></returns>
        public Auto TakeCar(string gosNumber)
        {
            if (string.IsNullOrWhiteSpace(gosNumber))
            {
                throw new ArgumentException($"{nameof(gosNumber)} не может быть пустым или содержать только пробел", nameof(gosNumber));
            }

            var auto = Cars.Find(F => F.GosNumber == gosNumber);
            return auto;
        }
        /// <summary>
        /// Добавление замены запчасти
        /// </summary>
        public void AddSparePart(string gosNumber, string name, double price, double repPrice)
        {
            if (string.IsNullOrWhiteSpace(gosNumber))
            {
                throw new ArgumentException($"{nameof(gosNumber)} не может быть пустым или содержать только пробел", nameof(gosNumber));
            }

            var auto = TakeCar(gosNumber);
            auto.SpareParts.Add(new SparePart(name, price, repPrice));
        }
        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <param name="gosNumber"></param>
        public void AddService(string gosNumber, string name, double price)
        {
            if (string.IsNullOrWhiteSpace(gosNumber))
            {
                throw new ArgumentException($"{nameof(gosNumber)} не может быть пустым или содержать только пробел", nameof(gosNumber));
            }

            var auto = TakeCar(gosNumber);
            auto.Services.Add(new Service(name, price));
        }
        /// <summary>
        /// добавление заправки
        /// </summary>
        /// <param name="gosNumber">гос. номер</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объем в литрах</param>
        public void AddRefueling(string gosNumber, double price, double volume)
        {

            if (string.IsNullOrWhiteSpace(gosNumber))
            {
                throw new ArgumentException($"{nameof(gosNumber)} не может быть пустым или содержать только пробел", nameof(gosNumber));
            }

            var auto = TakeCar(gosNumber);
            auto.Refuelings.Add(new Refueling(price, volume));
        }
    }
}
