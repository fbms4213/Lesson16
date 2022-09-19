namespace Lesson16;

#nullable disable

// C++

class Car : IDisposable
{
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public DateOnly Year { get; set; }


    public Car()
    {
        Console.WriteLine("Constructor");
        Console.WriteLine("Gen: " + GC.GetGeneration(this));
    }


    // ~Car()
    // {
    //     Console.WriteLine("Finalizer: " + Id);
    //     Console.WriteLine("Gen: " + GC.GetGeneration(this));
    // }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        Console.WriteLine("Dispose: " + Id);
        Console.WriteLine("Gen: " + GC.GetGeneration(this));
    }
}


class Program
{
    static void DoSomething()
    {
        for (int i = 0; i < 2; i++)
        {
            using Car c = new Car() { Id = i };
        }
    }


    static void Main()
    {
        int x = 10;

        // using Car c = new Car() { Id = 2 };

        using FileStream fs = new FileStream("myFile.txt", FileMode.Create);
        using StreamWriter sw = new StreamWriter(fs);




        // IDisposable vs Finalizer




        DoSomething();



        GC.Collect();
        GC.WaitForPendingFinalizers();
    }
}