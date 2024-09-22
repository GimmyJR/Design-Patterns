using static BuidlerDesignPattern.Program;

namespace BuidlerDesignPattern
{
    internal class Program
    {
        //before
        //public class Computer
        //{
        //    public string Processor { get; set; }
        //    public int RAM { get; set; }
        //    public string StorageType { get; set; } // SSD or HDD
        //    public bool HasGraphicsCard { get; set; }
        //    public bool HasBluetooth { get; set; }

        //    // Constructor with all parameters
        //    public Computer(string processor, int ram, string storageType, bool hasGraphicsCard, bool hasBluetooth)
        //    {
        //        Processor = processor;
        //        RAM = ram;
        //        StorageType = storageType;
        //        HasGraphicsCard = hasGraphicsCard;
        //        HasBluetooth = hasBluetooth;
        //    }

        //    public override string ToString()
        //    {
        //        return $"Computer with {Processor} processor, {RAM}GB RAM, {StorageType} storage, " +
        //               $"Graphics Card: {HasGraphicsCard}, Bluetooth: {HasBluetooth}";
        //    }
        //    static void Main(string[] args)
        //    {
        //        Computer gamingPC = new Computer("Intel i9", 32, "SSD", true, true);
        //        Console.WriteLine(gamingPC.ToString());

        //        // Creating a budget computer with basic components
        //        Computer budgetPC = new Computer("Intel i3", 8, "HDD", false, false);
        //        Console.WriteLine(budgetPC.ToString());
        //    }
        //}




        //after

        public class Computer
        {
            public string Processor { get; set; }
            public int RAM { get; set; }
            public string StorageType { get; set; } // SSD or HDD
            public bool HasGraphicsCard { get; set; }
            public bool HasBluetooth { get; set; }

            public override string ToString()
            {
                return $"Computer with {Processor} processor, {RAM}GB RAM, {StorageType} storage, " +
                       $"Graphics Card: {HasGraphicsCard}, Bluetooth: {HasBluetooth}";
            }
        }

        public interface IComputerBuilder
        {
            void SetProcessor(string processor);
            void SetRam(int ram);
            void SetStorageType(string storageType);
            void HasGraphicsCard(bool hasGraphicsCard);
            void HasBluetooth(bool hasBluetooth);
            Computer GetComputer();
        }

        public class ConcreteComputerBuilder : IComputerBuilder
        {
            private Computer _computer = new Computer();
            public void HasBluetooth(bool hasBluetooth)
            {
                _computer.HasBluetooth = hasBluetooth;
            }

            public void HasGraphicsCard(bool hasGraphicsCard)
            {
                _computer.HasGraphicsCard = hasGraphicsCard;
            }

            public void SetProcessor(string processor)
            {
                _computer.Processor = processor;
            }

            public void SetRam(int ram)
            {
                _computer.RAM = ram;
            }

            public void SetStorageType(string storageType)
            {
                _computer.StorageType = storageType;
            }

            Computer IComputerBuilder.GetComputer()
            {
                return _computer;
            }
        }
        public class ComputerDirector
        {
            private IComputerBuilder computerBuilder;

            public ComputerDirector(IComputerBuilder computerBuilder)
            {
                this.computerBuilder = computerBuilder;
            }
            public void BuildGamingPc() 
            {
                computerBuilder.SetProcessor("Intel i9");
                computerBuilder.SetRam(32);
                computerBuilder.SetStorageType("SSD");
                computerBuilder.HasGraphicsCard(true);
                computerBuilder.HasBluetooth(true);
            }
            public void BuildBudgetPc() 
            {
                computerBuilder.SetProcessor("Intel i3");
                computerBuilder.SetRam(8);
                computerBuilder.SetStorageType("HDD");
                computerBuilder.HasGraphicsCard(false);
                computerBuilder.HasBluetooth(false);
            }
        }
        static void Main(string[] args)
        {
            IComputerBuilder computerBuilder = new ConcreteComputerBuilder();
            ComputerDirector computerDirector = new ComputerDirector(computerBuilder);
            computerDirector.BuildGamingPc(); 
            Console.WriteLine(computerBuilder.GetComputer());
            computerDirector.BuildBudgetPc();
            Console.WriteLine(computerBuilder.GetComputer());
        }


    }
}
