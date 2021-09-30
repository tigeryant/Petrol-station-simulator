using System;
using System.Collections.Generic;
using System.Timers;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This is where most of the workings of the program take place. Various primary and auxilary methods are implemented
    /// relating to initialisation, randomisation and vehicle creation and removal. Lists are also instantiated.
    /// </summary>

    class Data
    {
        // 3 lists, a timer and a random are instantiated.

        private static Timer timer;
        public static List<Vehicle> vehicles; // Reference 2
        public static List<Pump> pumps;
        public static List<Transaction> transactions;

        public static readonly Random rnd = new Random();

        public static void Initialise() {
            // Calls initialisation methods

            InitialisePumps();
            InitialiseVehicles();
            InitialiseTransactionList();
        }

        private static void InitialiseVehicles()
        {
            // Creates a list of vehicles.
            // Calls the create vehicle method every time an interval of random length elapses.

            vehicles = new List<Vehicle>();

            // https://msdn.microsoft.com/en-us/library/system.timers.timer(v=vs.71).aspx
            timer = new Timer();
            timer.Interval = rnd.Next(1500, 2201);
            timer.AutoReset = true;
            timer.Elapsed += CreateVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        private static int GetRandom(int min, int max)
        {
            // Returns a random integer within two given bounds.

            int randomInt = rnd.Next(min, max);
            return randomInt;
        }

        private static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            // Creates a random type of vehicle if the queue length is short enough.
            // A timer then begins. If it elapses, the vehicle is removed from the
            // vehicles list (removed from the forecourt).

            if (vehicles.Count < 5)
            {
                Car c = new Car();
                Van v = new Van();
                HGV h = new HGV();

                int vehicleTypeNumber = rnd.Next(0, 3);

                switch (vehicleTypeNumber)
                {
                    case 0:
                        vehicles.Add(c);
                        StartWaitingTimer();
                        break;
                    case 1:
                        vehicles.Add(v);
                        StartWaitingTimer();
                        break;
                    case 2:
                        vehicles.Add(h);
                        StartWaitingTimer();
                        break;
                }

                void StartWaitingTimer()
                {
                    if (vehicles.Count > 4)
                    {
                        timer = new Timer
                        {
                            Interval = rnd.Next(1000, 2000),
                            AutoReset = false
                        };
                        timer.Elapsed += LeaveForecourt;
                        timer.Enabled = true;
                        timer.Start();
                    }

                    else
                    {
                        timer = new Timer
                        {
                            Interval = 1500,
                            AutoReset = false
                        };
                        timer.Elapsed += LeaveForecourt;
                        timer.Enabled = true;
                        timer.Start();
                    }
                }

                void LeaveForecourt(object sender2, ElapsedEventArgs e2)
                {
                    switch (vehicleTypeNumber)
                    {
                        case 0:
                            vehicles.Remove(c);
                            break;
                        case 1:
                            vehicles.Remove(v);
                            break;
                        case 2:
                            vehicles.Remove(h);
                            break;
                    }

                    Counter.vehiclesLeftUnfueled++;
                }
            }

            else
            {
                return;
            }
        }

        public static string ChooseFuelType(string inVehicleType)
        {
            // Depending on the type of vehicle created, a 'fuelType' string is returned.

            string vehicleType = inVehicleType;
            int fuelTypeNumber = 0;
            string fuelType = "";


            if (vehicleType == "Car")
            {
                fuelTypeNumber = rnd.Next(0, 3);
            }

            else if (vehicleType == "Van")
            {
                fuelTypeNumber = rnd.Next(0, 2);
            }

            switch (fuelTypeNumber)
            {
                case 0:
                    fuelType = "LPG     ";
                    break;
                case 1:
                    fuelType = "Diesel  ";
                    break;
                case 2:
                    fuelType = "Unleaded";
                    break;
            }

            return fuelType;
        }

        private static void InitialisePumps()
        {
            // Creates a list of pumps and sends arguments to their constructors.

            pumps = new List<Pump>();

            Pump p;

            for (int i = 0; i < 9; i++)
            {
                p = new Pump(10, i);
                pumps.Add(p);
            }
        }

        private static void InitialiseTransactionList()
        {
            // Creates a new list of transactions

            transactions = new List<Transaction>();
        }

        public static void AssignVehicleToPump() 

        {
            // If the queue is not empty, iterates through the pumps in a certain order (hardcoded),
            // then checks the availability of that pump, calls a method that blocks any pumps
            // which might be further right in the lane, and then assigns the vehicle to a particular pump.

            Vehicle v;
            Pump p;

            if (vehicles.Count != 0)
            { 
                int[] pumpPositions = { 8, 5, 2, 7, 4, 1, 6, 3, 0 };
                foreach (var pumpPosition in pumpPositions)
                {
                    p = pumps[pumpPosition];
                    
                        if (p.IsAvailable())
                        {

                        LaneManager.Blocker(pumpPosition);

                        v = vehicles[0]; // get first vehicle
                            vehicles.RemoveAt(0); // remove vehicles from queue
                            p.AssignVehicle(v); // assign it to the pump
                        }
                        else
                        {
                            continue;
                        }
                }
            }
            return;
        }
    }
}
