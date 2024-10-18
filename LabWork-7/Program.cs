using System;

namespace LabWork_7
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Strategy
            DeliveryContext deliveryContext = new DeliveryContext();

            Console.WriteLine("Выберите тип доставки: 1 - Стандартная, 2 - Экспресс, 3 - Международная, 4 - Ночная");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    deliveryContext.SetShippingStrategy(new StandardShippingStrategy());
                    break;
                case "2":
                    deliveryContext.SetShippingStrategy(new ExpressShippingStrategy());
                    break;
                case "3":
                    deliveryContext.SetShippingStrategy(new InternationalShippingStrategy());
                    break;
                case "4":
                    deliveryContext.SetShippingStrategy(new NightShippingStrategy());
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;

            }
            Console.WriteLine("Введите вес посылки (кг):");
            decimal weight = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Введите расстояние доставки (км):");
            decimal distance = Convert.ToDecimal(Console.ReadLine());

            if (weight < 0 || distance < 0)
                Console.WriteLine("Введены неправильные данные!");
            else
            {
                decimal cost = deliveryContext.CalculateCost(weight, distance);
                Console.WriteLine($"Стоимость доставки: {cost:C}");
            }

            //Observer
            WeatherStation weatherStation = new WeatherStation();

            // Создаем несколько наблюдателей
            WeatherDisplay mobileApp = new WeatherDisplay("Мобильное приложение");
            WeatherDisplay digitalBillboard = new WeatherDisplay("Электронное табло");
            EmailObserver email = new EmailObserver("Adam@gmail.com");

            // Регистрируем наблюдателей в системе
            weatherStation.RegisterObserver(mobileApp);
            weatherStation.RegisterObserver(digitalBillboard);
            weatherStation.RegisterObserver(email);

            // Изменяем температуру на станции, что приводит к уведомлению наблюдателей
            weatherStation.SetTemperature(25.0f);
            weatherStation.SetTemperature(30.0f);

            // Убираем один из дисплеев и снова меняем температуру
            weatherStation.RemoveObserver(digitalBillboard);
            weatherStation.SetTemperature(28.0f);

            weatherStation.SetTemperature(-65.0f);
            weatherStation.RemoveObserver(digitalBillboard);

        }
    }
}