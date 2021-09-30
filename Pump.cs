using System;
using System.Timers;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This class defines the pump objects and contains methods relevant to certain
    /// aspects of the pumps behaviour.
    /// </summary>

    class Pump
    {
        // Fields are declared which give the pump certain properties.

        public  Vehicle currentVehicle;
        public static double fuelingRate = 1.5;
        public static double costPerLitre;
        public int pumpNumber;
        public PumpState state = PumpState.NotBlocked;


        public Pump(double cpl, int pN) // Reference 3
        {
            // This constructor assigns various values to instances of the pump
            // class when they are instantiated. It accepts 2 arguments.

            costPerLitre = cpl;
            pumpNumber = pN;
        }

        public bool IsAvailable()
        {
            // This method, which returns a boolean, is used to define the pump's availability.

            // Returns true if the pump is not blocked, and there is no vehicle being serviced
            // Otherwise returns false

            if (state != PumpState.Blocked && currentVehicle == null)
            {
                return true;
            }
            return false;
        }

        public void AssignVehicle(Vehicle v)
        {
            // Calls the ReleaseVehicle method after a vehicle's fueling time has elapsed

            currentVehicle = v;

            Timer timer = new Timer
            {
                Interval = v.fuelTime,
                AutoReset = false
            };
            timer.Elapsed += ReleaseVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            /* Calculates information relating to the servicing of a vehicle,
             * including the number of litres and the cost of fuel dispensed.
             *
             * Calls an unblocker method that unblocks any pumps that need to be
             * freed. Updates the counters and records the transaction.
             */

            double unleadedDispensed = 0;
            double dieselDispensed = 0;
            double lpgDispensed = 0;

            double costOfLitresDispensed;

            UpdateCounters();
            RecordTransaction();
            currentVehicle = null;

            LaneManager.Unblocker(pumpNumber);

            void UpdateCounters()
            {
                switch (currentVehicle.fuelType)
                {
                    case "Unleaded":
                        unleadedDispensed = (fuelingRate * currentVehicle.fuelTime) / 1000;
                        break;
                    case "Diesel  ":
                        dieselDispensed = (fuelingRate * currentVehicle.fuelTime) / 1000;
                        break;
                    case "LPG     ":
                        lpgDispensed = (fuelingRate * currentVehicle.fuelTime) / 1000;
                        break;
                }
                costOfLitresDispensed = Math.Round(costPerLitre * (unleadedDispensed + dieselDispensed + lpgDispensed), 2);
                Counter.UpdateCounters(unleadedDispensed, dieselDispensed, lpgDispensed, costOfLitresDispensed);
            }

            void RecordTransaction()
            {
                Transaction t = new Transaction(currentVehicle.vehicleType, currentVehicle.carID, currentVehicle.fuelType, unleadedDispensed + dieselDispensed + lpgDispensed, costOfLitresDispensed, pumpNumber, DateTime.Now);
                Counter.UpdateTransactionList(t);
            }
        }
    }

    enum PumpState // Reference 9
    {
        // Enumerator which gives the pump's state two possible values.

        NotBlocked,
        Blocked
    };
}
