namespace IdleMiner
{

    public class Resource
    {
        public string? Location { get; set; }
        public bool IsValuable { get; set; }
        public int Id { get; set; }
        public static int ResourceId { get; set; } = 1;
        public Miner[]? Miners { get; set; }
        public int MinerCount { get; set; } = 0;

        public Resource()
        {
            Id = ResourceId++;
        }

        public void AddMiner(Miner miner)
        {
            Miner[] temp = new Miner[++MinerCount];
            if(Miners != null)
            {
                Miners.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = miner;
            Miners = temp;
        }

        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine("=============Resource=============");
            Console.WriteLine($"ID : {Id}");
            Console.WriteLine($"Location : {Location}");
            Console.WriteLine($"Is valuable : {(IsValuable ? "Yes" : "No")}");
            Console.WriteLine($"Total Income : {getTotalIncome()}");
        }

        private decimal getTotalIncome()
        {
            decimal total = 0;
            foreach (var item in Miners)
            {
                total += item.Income;
            }
            return total;
        }

        public void ShowMiners()
        {
            if (Miners != null)
            {
                foreach (var miner in Miners)
                {
                    miner.Show();
                    Console.WriteLine();
                }
            }
        }

    }

    public class Manager
    {
        public string? Name { get; set; }
        public int Energy { get; set; } = 100;
        public decimal IncomePercent { get; set; }
        public decimal EnergyPercent { get; set; }
    }

    public class Miner
    {
        public string? Name { get; set; }
        public double Salary { get; set; }
        public int Energy { get; set; } = 100;
        public decimal Income { get; set; }
        public Manager? Manager { get; set; } = null;

        public void DrinkRedbull()
        {
            Energy += 50;
        }

        public void Work()
        {
            if(Energy > 0)
            {
                Energy -= 5;
                Income += 5;
                if(Manager != null)
                {
                    if(Manager.Energy > 0)
                    {
                        Energy += (int)(Manager.EnergyPercent) * 5;
                        Manager.Energy -= 5;
                        Income += Manager.IncomePercent * 5;
                    }
                    else
                    {
                        Manager.Energy = 0;
                    }
                }
            }
        }

        public void Show()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Fullname {Name}");
            Console.WriteLine($"Salary {Salary}");
            Console.WriteLine($"Energy {Energy}");
            Console.WriteLine($"Manager Energy {Manager?.Energy}");
            Console.WriteLine($"Income {Income} usd");
            Console.ResetColor();
        }

    }

    class Controller
    {
        public static void Start()
        {
            Resource resource = new Resource
            {
                IsValuable = true,
                Location = "Moscow",
            };
            Miner m1 = new Miner
            {
                Name = "Mike",
                Salary = 1200
            };

            Manager manager = new Manager {
                Energy = 50,
                EnergyPercent = 10,
                IncomePercent = 10,
                Name = "Abdullah :-)"
            };

            Miner m2 = new Miner
            {
                Name = "John",
                Salary = 1300
            };

            m2.Manager = manager;

            resource.AddMiner(m1);
            resource.AddMiner(m2);
            do
            {
                resource.Show();
                resource.ShowMiners();
                m1.Work();
                m2.Work();
                Thread.Sleep(200);
                Console.Clear();
            } while (m1.Energy != 0 || m2.Energy != 0);
            resource.Show();
            resource.ShowMiners();

        }
    }

    public class Program
    {
        static void Main(string[] args){
            Controller.Start();
        }
    }
}