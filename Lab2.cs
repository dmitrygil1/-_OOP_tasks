using System;
// Базовый класс Транспортное средство
public class Transport
{
    // Скрытые поля
    protected string name;
    protected double distance;
    protected double pricePerKm;

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
    public virtual double GetCost()
    {
        return distance * pricePerKm;
    }
}

// Класс Самолет, наследуется от базового класса
public class Airplane : Transport
{
    // Дополнительные поля
    private double height;
    private double speed;

    // Конструкторы без параметров и с параметрами
    public Airplane() : base()
    {
        this.height = 0.0;
        this.speed = 0.0;
    }
    public Airplane(string name, double distance, double pricePerKm, double height, double speed) : base(name, distance, pricePerKm)
    {
        this.height = height;
        this.speed = speed;
    }

    // Свойства
    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    public double Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    // Переопределенный метод для расчета стоимости проезда
    public override double GetCost()
    {
        return base.GetCost() + 100 * height * speed;
    }
}

// Класс Корабль, наследуется от базового класса
public class Ship : Transport
{
    // Дополнительные поля
    private int numOfDecks;
    private int deckNum;

    // Конструкторы без параметров и с параметрами
    public Ship() : base()
    {
        this.numOfDecks = 0;
        this.deckNum = 0;
    }
    public Ship(string name, double distance, double pricePerKm, int numOfDecks, int deckNum) : base(name, distance, pricePerKm)
    {
        this.numOfDecks = numOfDecks;
        this.deckNum = deckNum;
    }

    // Свойства
    public int NumOfDecks
    {
        get { return numOfDecks; }
        set { numOfDecks = value; }
    }
    public int DeckNum
    {
        get { return deckNum; }
        set { deckNum = value; }
    }

    // Переопределенный метод для расчета стоимости проезда
    public override double GetCost()
    {
        // Увеличиваем стоимость проезда на k2% для палуб №3-4
        if (deckNum == 3 || deckNum == 4)
        {
            pricePerKm += pricePerKm * numOfDecks * 0.01;
        }
        return base.GetCost();
    }
}

// Тестирующая программа
class Program
{
    static void Main(string[] args)
    {
        // Создаем объекты различных классов
        Transport transport1 = new Transport("Машина", 100.0, 10.0);
        Airplane airplane1 = new Airplane("Самолет", 1000.0, 50.0, 10.0, 900.0);
        Ship ship1 = new Ship("Корабль", 2000.0, 20.0, 5, 4);

        // Выводим поля объектов
        Console.WriteLine("Обычное транспортное средство:");
        transport1.Print();
        Console.WriteLine("Стоимость проезда: {0} руб.", transport1.GetCost());

        Console.WriteLine();

        Console.WriteLine("Самолет:");
        airplane1.Print();
        Console.WriteLine("Стоимость проезда: {0} руб.", airplane1.GetCost());

        Console.WriteLine();

        Console.WriteLine("Корабль:");
        ship1.Print();
        Console.WriteLine("Стоимость проезда: {0} руб.", ship1.GetCost());

        Console.ReadKey();
    }
}

// Вывод программы:
// Обычное транспортное средство:
// Название: Машина
// Расстояние: 100 км
// Цена за 1 км: 10 руб.
// Стоимость проезда: 1000 руб.

// Самолет:
// Название: Самолет
// Расстояние: 1000 км
// Цена за 1 км: 50 руб.
// Высота: 10 км
// Скорость: 900 км/ч
// Стоимость проезда: 450000 руб.

// Корабль:
// Название: Корабль
// Расстояние: 2000 км
// Цена за 1 км: 20 руб.
// Количество палуб: 5
// Номер палубы: 4
// Стоимость проезда: 52000 руб.
