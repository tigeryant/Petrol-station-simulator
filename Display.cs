using System;
namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This is a static class. Objects based on static classes can never be instantiated.
    /// The program will never create a new 'Display'.
    /// Instead, it contains methods which are invoked from outside the class.
    ///
    /// The methods of this particular class serve the purpose of displaying to the user
    /// information regarding the workings of the petrol station.
    /// 'Graphics.cs' would also be an appropriate name for this class
    /// as it is used to show information graphically based on various inputs.
    /// </summary>

    public static class Display
    {
		public static void DrawVehicles()
		{
            // This method displays the queue of vehicles.
            // Each vehicle in the queue is displayed, along with its fuel type.

            Vehicle v;

			Console.WriteLine("Vehicles Queue:");

			for (int i = 0; i < Data.vehicles.Count; i++)
			{
				v = Data.vehicles[i];
				Console.Write("#{0} Fuel Type: {1} | ", v.carID, v.fuelType);
			}
		}

		public static void DrawPumps()
		{
            /* This method displays all the pumps in their various positions.
             * Their 'state' (free, busy or blocked) is also displayed.
             */

			Pump p;

			Console.WriteLine("Pumps Status:");

			for (int i = 0; i < 9; i++)
			{
				p = Data.pumps[i];

				Console.Write("#{0} ", i + 1);

                
                if (p.IsAvailable()) { Console.Write("FREE   "); }

                else if ((p.state == PumpState.Blocked) && (p.currentVehicle == null))
                {
                    Console.Write("BLOCKED");
                }

                else if (p.currentVehicle != null)
                {
                    Console.Write("BUSY   ");
                }
				Console.Write(" | ");

                // modulus -> remainder of a division operation
                // 0 % 3 => 0 (0 / 3 = 0 R=0)
                // 1 % 3 => 1 (1 / 3 = 0 R=1)
                // 2 % 3 => 2 (2 / 3 = 0 R=2)
                // 3 % 3 => 0 (3 / 3 = 1 R=0)
                // 4 % 3 => 1 (4 / 3 = 1 R=1)
                // 5 % 3 => 2 (5 / 3 = 1 R=2)
                // 6 % 3 => 0 (6 / 3 = 2 R=0)
                // ...
				if (i % 3 == 2) { Console.WriteLine(); }
			}
		}

        public static void DrawCounters()
        {
            // This method displays counters 1-5 in the specification.

            Console.WriteLine("\nCounters:\n");
            Console.WriteLine("Total litres dispensed: " + Counter.totalLitresDispensed + "L");
            Console.WriteLine("Unleaded litres dispensed: " + Counter.totalUnleadedDispensed + "L");
            Console.WriteLine("Diesel litres dispensed: " + Counter.totalDieselDispensed + "L");
            Console.WriteLine("LPG litres dispensed: " + Counter.totalLPGDispensed + "L");
            Console.WriteLine("Cost of total litres dispensed (In pounds, 10/litre): " + Counter.totalLitresCost);
            Console.WriteLine("1% commission (In pounds): " + Counter.onePercentCommission);
            Console.WriteLine("Number of vehicles serviced: " + Counter.numberOfVehiclesServiced);
            Console.WriteLine("Vehicles left without being fueled: " + Counter.vehiclesLeftUnfueled);
        }

        public static void DrawTransactions()
        {
            // This method displays each of the transactions that occurs when a vehicle is serviced.

            Console.WriteLine("\nTransactions:\n");
            Console.WriteLine("Vehicle Type\tVehicle ID\tFuel Type\tLitres Dispensed\tTransaction value (In pounds)\tPump number\tTime of transaction");

            for (int index = Data.transactions.Count-1; index >= 0; index--)
            {
                Console.Write("{0}\n", Data.transactions[index]);
            }
        }
    }
}
