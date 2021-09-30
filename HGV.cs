using System;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This is a child class which inherits from 'Vehicle'. Within it is a constructor which assigns
    /// various values to properties defined in its parent class. Some things to note about this class are:
    /// - that its fuel type is hardcoded as being 'Diesel'. HGVs only run on diesel, and therefore
    /// there is no need to randomise the value assigned to 'fuelType'.
    /// - that its tank capacity is a hardcoded integer that differs from both 'Car' and 'Van'.
    /// - that its original fuel level is defined through the use of the 'GetRandom' method in 'Data'
    /// (See Data.cs for more on that)
    /// </summary>
    /// 
    public class HGV : Vehicle
    {
        public HGV()
        {
            fuelType = "Diesel  ";
            vehicleType = "HGV     ";
            carID = nextCarID++;
            tankCapacity = 150;
            originalFuelLevel = Data.rnd.Next(0, Convert.ToInt32(tankCapacity * 0.25));
            fuelTime = ((tankCapacity - originalFuelLevel) / Pump.fuelingRate) * 1000;
        }
    }
}
