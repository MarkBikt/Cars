using Cars.cs.model;
using System;
using System.Collections.ObjectModel;

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
        public static double PriceAll { get; private set; } = 0;

        private static double newVolume = 0;
        private static double preMileage = 0;
        private static double Mileage = 0;

        /// <summary>
        /// Расход на 100 км.
        /// </summary>
        

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
            Save(auto);
        }

        /// <summary>
        /// Добавление замены запчасти
        /// </summary>
        public static void AddSparePart(string name, double price, Auto car)
        {
            if (car == null)
            {
                throw new ArgumentException($"{nameof(car)} не может быть пустым", nameof(car));
            }
            var sparePart = new SparePart(name, price) { AutoId = car.Id };
            car.SpareParts.Add(sparePart);
            
            Save(sparePart);
            PriceAll += price;            
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
            var service = new Service (name, price) {AutoId = car.Id };
            car.Services.Add(service);
           
            Save(service);
            PriceAll += price;
        }
        /// <summary>
        /// добавление заправки
        /// </summary>
        /// <param name="gosNumber">гос. номер</param>
        /// <param name="price">Цена</param>
        /// <param name="volume">Объем в литрах</param>
        public static Auto AddRefueling(double price, double volume, double carMileage, Auto car, bool check)
        {
            
            if (car == null)
            {
                throw new ArgumentException($"{nameof(car)} не может быть пустым", nameof(car));
            }
            var refueling = new Refueling(price, volume, carMileage) { AutoId = car.Id };
            car.Refuelings.Add(refueling);
            if (check == true)
            {
                newVolume += volume;
                if (preMileage != 0)
                {
                    Mileage = carMileage - preMileage;
                }
                else if (preMileage == 0)
                {
                    Mileage = carMileage - car.CarMileage;
                }

                car.AvFuel = 100 * newVolume / Mileage;

                newVolume = 0;
                preMileage = carMileage;
            }
            else if (check == false)
            {
                newVolume += volume;
            }
            Save(refueling);
            PriceAll += price;

            return car;
        }
        /// <summary>
        /// Сохранение
        /// </summary>
        public static void Save<T>(T item) where T : class
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
        public static ObservableCollection<Auto> Load()
        {
            using (CarsContext db = new CarsContext())
            {
                var cars = db.Cars;
                var services = db.Services;
                var refuelings = db.Refuelings;
                var spareParts = db.SpareParts;
                foreach (var item in cars)
                {
                    foreach (var service in services)
                    {
                        
                    }
                    foreach (var refueling in refuelings)
                    {
                        
                    }
                    foreach (var sparePart in spareParts)
                    {
                        
                    }
                    Cars.Add(item);
                }
                
                return Cars;
            }
        }
    }
}
