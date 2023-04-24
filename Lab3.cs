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

    // Виртуальный метод вывода полей
    public virtual void Print()
    {
        Console.WriteLine("Название: {0}", name);
        Console.WriteLine("Расстояние: {0} км", distance);
        Console.WriteLine("Цена за 1 км: {0} руб.", pricePerKm);
    }

    // Виртуальный метод для расчета стоимости проезда
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

    // Переопределенный метод для вывода полей
    public override void Print()
    {
        base.Print();
        Console.WriteLine("Высота: {0} км", height);
        Console.WriteLine("Скорость: {0} км/ч", speed);
    }

    // Переопределенный метод для расчета стоимости проезда (увеличиваем на 100*h*v)
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

    // Переопределенный метод для вывода полей
    public override void Print()
    {
        base.Print();
        Console.WriteLine("Количество палуб: {0}", numOfDecks);
        Console.WriteLine("Номер палубы: {0}", deckNum);
    }

    // Переопределенный метод для расчета стоимости проезда (увеличиваем на k2% для палуб №3-4)
    public override double GetCost()
    {
        if (deckNum == 3 || deckNum == 4)
        {
            pricePerKm += pricePerKm * numOfDecks * 0.02;
        }
        return base.GetCost();
    }
}

// Тестирующая программа
class Program
{
    static void Main(string[] args)
    {
        // Массив ссылок на объекты базового и производных классов
        Transport[] transports = new Transport[4];
        transports[0] = new Transport("Машина", 500.0, 20.0);
        transports[1] = new Airplane("Самолет", 10000.0, 100.0, 12.0, 920.0);
        transports[2] = new Transport("Автобус", 300.0, 8.0);
        transports[3] = new Ship("Корабль", 5000.0, 15.0, 6, 3);

        // Выводим поля объектов
        foreach (Transport transport in transports)
        {
            Console.WriteLine("Объект типа {0}:", transport.GetType().Name);
            transport.Print();
            Console.WriteLine("Стоимость проезда: {0} руб.", transport.GetCost());
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}
