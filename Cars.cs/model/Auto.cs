using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.cs.model
{
    /// <summary>
    /// Автомобиль
    /// </summary>
    public class Auto : IDataErrorInfo
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
        public double CarMileage { get; set; }
        /// <summary>
        /// Объем топлива в баке
        /// </summary>
        public double FuelVolume { get; set; }

        public string Error => throw new NotImplementedException();

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "CarBrand":
                        if(CarBrand == null)
                        {
                            error = "Поле не может быть пустым!";
                        }
                        break;
                    case "CarModel":
                        if(CarModel == null)
                        {
                            error = "Поле не может быть пустым!";
                        }
                        break;
                    case "GosNumber":
                        if(GosNumber == null || GosNumber.Length > 9)
                        {
                            error = "Поле не может быть пустым!";
                        }
                        break;
                    case "AutoYear":
                        if(AutoYear > DateTime.Now.Year || AutoYear < 1900)
                        {
                            error = "Дата выпуска не может быть больше настоящего времени или меньше 1900 года!";
                        }
                        break;
                    case "Color":
                        if(Color == null)
                        {
                            error = "Цвет не может быть пустым!";
                        }
                        break;
                    case "CarMileage":
                        if(CarMileage < 0)
                        {
                            error = "Пробег не может быть меньше нуля!";
                        }
                        break;
                    case "FuelVolume":
                        if(CarMileage <= 0)
                        {
                            error = "Объем бака не может быть меньше или равен нулю!";
                        }
                        break;

                }
                return error;
            }
        }

        /// <summary>
        /// Список запчастей
        /// </summary>
        public List<SparePart> SpareParts = new List<SparePart>();
        /// <summary>
        /// Список услуг
        /// </summary>
        public List<Service> Services = new List<Service>();
        /// <summary>
        /// Список заправок
        /// </summary>
        public List<Refueling> Refuelings = new List<Refueling>();

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
        public Auto(string carBrand, string carModel, string gosNumber, int autoYear, string color, double carMileage, double fuelVolume)
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

        public override string ToString()
        {
            return $"{CarBrand} {CarModel} {GosNumber}";
        }
    }
}
