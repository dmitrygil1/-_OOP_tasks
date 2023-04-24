using System;
// Класс Транспортное средство
public class Transport
{
    // Скрытые поля
    private string name;
    private double distance;
    private double pricePerKm;

    // Конструкторы без параметров и с параметрами
    public Transport()
    {
        this.name = "";
        this.distance = 0.0;
        this.pricePerKm = 0.0;
    }
    public Transport(string name, double distance, double pricePerKm)
    {
        this.name = name;
        this.distance = distance;
        this.pricePerKm = pricePerKm;
    }

    // Свойства
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public double Distance
    {
        get { return distance; }
        set { distance = value; }
    }
    public double PricePerKm
    {
        get { return pricePerKm; }
        set { pricePerKm = value; }
    }

    // Метод вывода полей
    public void Print()
    {
        Console.WriteLine("Название: {0}", name);
        Console.WriteLine("Расстояние: {0} км", distance);
        Console.WriteLine("Цена за 1 км: {0} руб.", pricePerKm);
    }

    // Метод для расчета стоимости проезда
    public double GetCost()
    {
        return distance * pricePerKm;
    }
}

// Тестирующая программа
class Program
{
    static void Main(string[] args)
    {
        // Создаем объекты класса Transport
        Transport transport1 = new Transport("Машина", 100.0, 10.0);
        Transport transport2 = new Transport("Автобус", 200.0, 5.0);

        // Выводим поля объектов
        transport1.Print();
        Console.WriteLine("Стоимость проезда: {0} руб.", transport1.GetCost());

        Console.WriteLine();

        transport2.Print();
        Console.WriteLine("Стоимость проезда: {0} руб.", transport2.GetCost());

        Console.ReadKey();
    }
}

// Вывод программы:
// Название: Машина
// Расстояние: 100 км
// Цена за 1 км: 10 руб.
// Стоимость проезда: 1000 руб.

// Название: Автобус
// Расстояние: 200 км
// Цена за 1 км: 5 руб.
// Стоимость проезда: 1000 руб.
