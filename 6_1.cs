using System;

namespace ConsoleApp11
{
    class Train
    {
        public string DestinationStation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int NumberOfStops { get; set; }

        public virtual double CalculateAverageInterval()
        {
            TimeSpan totalInterval = ArrivalTime - DepartureTime;
            return totalInterval.TotalHours / NumberOfStops;
        }

        public override int GetHashCode()
        {
            // Генеруємо хеш на основі всіх властивостей об'єкту
            return DestinationStation.GetHashCode() ^ DepartureTime.GetHashCode() ^ ArrivalTime.GetHashCode() ^ NumberOfStops.GetHashCode();
        }
    }

    class Express : Train
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nMax Speed: {MaxSpeed}\nDestination: {DestinationStation}\nDeparture: {DepartureTime}\nArrival: {ArrivalTime}\nStops: {NumberOfStops}";
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;

            Express other = (Express)obj;
            return Name == other.Name && MaxSpeed == other.MaxSpeed;
        }

        public override int GetHashCode()
        {
            // Генеруємо хеш на основі всіх властивостей об'єкту, включаючи базовий хеш
            return base.GetHashCode() ^ Name.GetHashCode() ^ MaxSpeed.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Train[] trains = new Train[2];

            trains[0] = new Train
            {
                DestinationStation = "Station A",
                DepartureTime = new DateTime(2024, 5, 22, 8, 0, 0),
                ArrivalTime = new DateTime(2024, 5, 22, 10, 0, 0),
                NumberOfStops = 5
            };

            trains[1] = new Express
            {
                DestinationStation = "Station B",
                DepartureTime = new DateTime(2024, 5, 22, 9, 0, 0),
                ArrivalTime = new DateTime(2024, 5, 22, 11, 0, 0),
                NumberOfStops = 3,
                Name = "Express 1",
                MaxSpeed = 200
            };

            Console.WriteLine("Train Info:");
            foreach (Train train in trains)
            {
                Console.WriteLine(train);
                Console.WriteLine();
            }
        }
    }
}
