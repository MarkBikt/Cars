using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Auto
    {      
        public int Id { get; set; }
        /// <summary>
        /// Марка автомобиля
        /// </summary>
        public string CarBrand { get; set; }
        /// <summary>
        /// Модель автомобиля
        /// </summary>
        public string CarModel { get; set; }
        /// <summary>
        /// Гос. номер автомобиля
        /// </summary>
        public string GosNumber { get; set; }
        /// <summary>
        /// Год выпуска автомобиля
        /// </summary>
        public int AutoYear { get; set; }
        /// <summary>
        /// Цвет автомобиля
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Пробег автомобиля
        /// </summary>
        public int CarMileage { get; set; }
        /// <summary>
        /// Объем топлива в баке
        /// </summary>
        public double FuelVolume { get; set; }
        /// <summary>
        /// Список запчастей
        /// </summary>
        public List<SparePart> SpareParts { get; set; }
        /// <summary>
        /// Список услуг
        /// </summary>
        public List<Service> Services { get; set; }
        /// <summary>
        /// Список заправок
        /// </summary>
        public List<Refueling> Refuelings { get; set; }

        public Auto()
        {

        }
        /// <summary>
        /// Создание нового автомобиля
        /// </summary>
        /// <param name="carBrand"></param>
        /// <param name="carModel"></param>
        /// <param name="gosNumber"></param>
        /// <param name="autoYear"></param>
        /// <param name="color"></param>
        /// <param name="carMileage"></param>
        /// <param name="fuelVolume"></param>
        public Auto(string carBrand, string carModel, string gosNumber, int autoYear, string color, int carMileage, double fuelVolume)
        {
            CarBrand = carBrand ?? throw new ArgumentNullException(nameof(carBrand));
            CarModel = carModel ?? throw new ArgumentNullException(nameof(carModel));
            GosNumber = gosNumber ?? throw new ArgumentNullException(nameof(gosNumber));
            if(autoYear <= DateTime.Now.Year)
            {
                AutoYear = autoYear;
            }
            else
            {
                throw new ArgumentException($"Год не может быть больше {DateTime.Now.Year} ", nameof(autoYear));
            }
            Color = color ?? throw new ArgumentNullException(nameof(color));
            if(carMileage >= 0)
            {
                CarMileage = carMileage;
            }
            else
            {
                throw new ArgumentException("Пробег не может быть меньше нуля ", nameof(carMileage));
            }
            
            if(fuelVolume > 0)
            {
                FuelVolume = fuelVolume;
            }
            else
            {
                throw new ArgumentException("Объем бака не может быть меньше или равен нулю", nameof(fuelVolume));
            }
        }
    }
}
