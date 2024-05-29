using System;

// Клас для представлення валізи
public class Valiza
{
    // Подія для додавання об'єкту до валізи
    public event EventHandler<ObjectAddedEventArgs> ObjectAdded;

    // Поля класу
    private string color;
    private string brand;
    private double weight;
    private double volume;
    private object[] contents; // Масив об'єктів для зберігання вмісту валізи

    // Конструктор класу
    public Valiza(string color, string brand, double weight, double volume)
    {
        this.color = color;
        this.brand = brand;
        this.weight = weight;
        this.volume = volume;
        this.contents = new object[0]; // Ініціалізуємо пустий масив об'єктів
    }

    // Метод для додавання об'єктів до валізи
    public void AddObject(string name, double volume)
    {
        if (TotalVolume() + volume > this.volume)
        {
            throw new InvalidOperationException("Обсяг валізи перевищено");
        }

        // Створюємо новий масив з розміром, що на одиницю більший за поточний
        object[] newContents = new object[contents.Length + 1];
        // Копіюємо попередні об'єкти в новий масив
        Array.Copy(contents, newContents, contents.Length);
        // Додаємо новий об'єкт до кінця нового масиву
        newContents[contents.Length] = new ValizaObject(name, volume);
        // Оновлюємо вміст валізи
        contents = newContents;

        OnObjectAdded(new ValizaObject(name, volume));
    }

    // Метод для виведення інформації про валізу
    public void DisplayValizaInfo()
    {
        Console.WriteLine($"Колір: {color}");
        Console.WriteLine($"Фірма: {brand}");
        Console.WriteLine($"Вага: {weight} кг");
        Console.WriteLine($"Об'єм: {volume}");

        Console.WriteLine("Вміст валізи:");
        foreach (var item in contents)
        {
            ValizaObject valizaObject = (ValizaObject)item;
            Console.WriteLine($"- {valizaObject.Name} ({valizaObject.Volume} litres)");
        }
    }

    // Внутрішній метод для обчислення загального обсягу валізи
    private double TotalVolume()
    {
        if (contents.Length == 0)
        {
            return 0; // Повертаємо 0, якщо масив пустий
        }

        double totalVolume = 0;
        foreach (var item in contents)
        {
            ValizaObject valizaObject = (ValizaObject)item;
            totalVolume += valizaObject.Volume;
        }
        return totalVolume;
    }

    // Метод, який викликає подію після додавання об'єкту до валізи
    protected virtual void OnObjectAdded(ValizaObject valizaObject)
    {
        ObjectAdded?.Invoke(this, new ObjectAddedEventArgs(valizaObject));
    }

    // Внутрішній клас для представлення об'єктів валізи
    private class ValizaObject
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public ValizaObject(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }

    // Клас для аргументів події
    public class ObjectAddedEventArgs : EventArgs
    {
        public ValizaObject AddedObject { get; }

        public ObjectAddedEventArgs(ValizaObject addedObject)
        {
            AddedObject = addedObject;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення валізи
        Valiza myValiza = new Valiza("Біла", "Noter", 2.5, 50);

        // Підписка на подію додавання об'єкту
        myValiza.ObjectAdded += HandleObjectAdded;

        // Додавання об'єктів до валізи
        try
        {
            myValiza.AddObject("Планшет", 3);
            myValiza.AddObject("Одяг", 10);
            myValiza.AddObject("Косметика", 5);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        // Виведення інформації про валізу
        Console.WriteLine("\nBag Information:");
        myValiza.DisplayValizaInfo();
    }

    // Обробник події додавання об'єкту до валізи
    public static void HandleObjectAdded(object sender, Valiza.ObjectAddedEventArgs e)
    {
        Console.WriteLine($"Added object: {e.AddedObject}");
    }
}
