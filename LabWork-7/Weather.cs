using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_7
{
    public interface IObserver
    {
        void Update(float temperature);
    }
    public interface ISubject
    {
        void RegisterObserver(IObserver observer);  // Регистрация наблюдателя
        void RemoveObserver(IObserver observer);    // Удаление наблюдателя
        void NotifyObservers();                     // Уведомление всех наблюдателей
    }
    public class WeatherStation : ISubject
    {
        private List<IObserver> observers;
        private float temperature;

        public WeatherStation()
        {
            observers = new List<IObserver>();
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            if (observers.Contains(observer))
                observers.Remove(observer);
            else
                Console.WriteLine("Ошибка: Попытка удалить несуществующего наблюдателя.");
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
                observer.Update(temperature);
        }

        public void SetTemperature(float newTemperature)
        {
            if (newTemperature < -60 || newTemperature > 60)
            {
                Console.WriteLine("Ошибка: Некорректное значение температуры.");
                return;
            }
            Console.WriteLine($"Изменение температуры: {newTemperature}°C");
            temperature = newTemperature;
            NotifyObservers();
        }
    }

    public class WeatherDisplay : IObserver
    {
        private string _name;

        public WeatherDisplay(string name)
        {
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} показывает новую температуру: {temperature}°C");
        }
    }

    public class EmailObserver : IObserver
    {
        private string _recipient;

        public EmailObserver(string recipient)
        {
            _recipient = recipient;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"Отправка email на {_recipient}: Температура изменилась до {temperature}°C");
        }
    }

    internal class Weather
    {
    }
}
