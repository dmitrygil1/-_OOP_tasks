using System;

// Определяем базовый класс "Транспорт" как абстрактный
public abstract class Transport
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
    //Метод вывода полей (не описывается и задается абстрактно)
    public abstract void Print();
    //Метод для рассчёта стоимости проезда - аналогично
    public abstract double GetCost();
}

// Конструкторы без параметров и с параметрами
public class Airplane : Transport
{
    private double height;
    private double speed;
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
        Console.WriteLine("Название: {0}", name);
        Console.WriteLine("Расстояние: {0} км", distance);
        Console.WriteLine("Цена за 1 км: {0} руб.", pricePerKm);
        Console.WriteLine("Высота: {0} км", height);
        Console.WriteLine("Скорость: {0} км/ч", speed);
    }
    // Переопределенный метод для расчета стоимости проезда (увеличиваем на 100*h*v)
    public override double GetCost()
    {
        return distance * pricePerKm + 100 * height * speed;
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
    public override void Print()
    {   // Создаем массив ссылок на объекты производных классов объемом 4 и располагаем их в произвольном порядке
        Console.WriteLine("Название: {0}", name);
        Console.WriteLine("Расстояние: {0} км", distance);
        Console.WriteLine("Цена за 1 км: {0} руб.", pricePerKm);
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
        return distance * pricePerKm;
    }
}

// Тестирующая программа
class Program
{
    static void Main(string[] args)
    {
        // Массив ссылок на объекты базового и производных классов
        Transport[] transports = new Transport[4];
        transports[0] = new Airplane("Самолет 1", 1000, 10, 5, 800);
        transports[1] = new Ship("Корабль 1", 2000, 5, 3, 2);
        transports[2] = new Airplane("Самолет 2", 1500, 12, 7, 1000);
        transports[3] = new Ship("Корабль 2", 3000, 4, 4, 1);
        // Вычисляем среднюю стоимость проезда на самолетах и среднюю стоимость проезда на корабле
        double airplaneCost = 0.0;
        double shipCost = 0.0;
        int airplaneCount = 0;
        int shipCount = 0;
        
        // Выводим поля объектов
        foreach (Transport transport in transports)
        {
            if (transport is Airplane)
            {
                airplaneCost += transport.GetCost();
                airplaneCount++;
            }
            else if (transport is Ship)
            {
                shipCost += transport.GetCost();
                shipCount++;
            }

            transport.Print();
        }
         // Печатаем результаты
        Console.WriteLine("Средняя стоимость проезда на самолете: {0} руб.",airplaneCost / airplaneCount);
        Console.WriteLine("Средняя стоимость проезда на корабле: {0} руб.", shipCost / shipCount);
    }
}
