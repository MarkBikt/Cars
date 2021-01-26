using Cars.cs.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.Controller
{
    public static class ControllerAuto
    {
        /// <summary>
        /// Списко автомобилей
        /// </summary>
        public static ObservableCollection<Auto> Cars = new ObservableCollection<Auto>();
        /// <summary>
        /// Потрачено на авто за все время
        /// </summary>
        public static double PriceAll { get; set; } = 0;
      
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
        public static void Add(string carBrand, string carModel, string gosNumber, int autoYear, string color, double carMilage, double fuelVolume)
        {
            var auto = new Auto(carBrand, carModel, gosNumber, autoYear, color, carMilage, fuelVolume);
            Cars.Add(auto);
            SaveCar(auto);
        }

        /// <summary>
        /// Добавление замены запчасти
        /// </summary>
        public static void AddSparePart(string name, double price, double repPrice, Auto car)
        {
            if (car == null)
            {
                throw new ArgumentException($"{nameof(car)} не может быть пустым", nameof(car));
            }
           
            car.SpareParts.Add(new SparePart(name, price, repPrice));
            PriceAll += price;
            PriceAll += repPrice;
        }
        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <param name="gosNumber"></param>
        public static void AddService(string name, double price, Auto car)
        {
            if (car == null)
            {
                throw new ArgumentException($"{nameof(car)} не может быть пустым", nameof(car));
            }
            
            car.Services.Add(new Service(name, price));
            PriceAll += price;
        }
        /// <summary>
        /// добавление заправки
        /// </summary>
        /// <param name="gosNumber">гос. номер</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объем в литрах</param>
        public static void AddRefueling(double price, double volume, double carMileage, Auto car)
        {

            if (car == null)
            {
                throw new ArgumentException($"{nameof(car)} не может быть пустым", nameof(car));
            }

            car.Refuelings.Add(new Refueling(price, volume, carMileage));
            PriceAll += price;
        }
        /// <summary>
        /// Сохранение
        /// </summary>
        public static void SaveCar<T>(T item) where T: class
        {
            using (CarsContext db = new CarsContext())
            {
                db.Set<T>().Add(item);
                
               
                db.SaveChanges();
            }
            
        }

        /// <summary>
        /// Загрузка
        /// </summary>
        public static void Load()
        {
            using (CarsContext db = new CarsContext())
            {
                var cars = db.Cars;
                foreach (var item in cars)
                {
                    Cars.Add(item);
                }           
            }
        }
    }
}
