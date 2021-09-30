using System;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This is a child class which inherits from 'Vehicle'. Within it is a constructor which assigns
    /// various values to properties defined in its parent class. Some things to note about this class are:
    /// - that its fuel type is assigned by invoking a method in 'Data', which accepts the type of vehicle
    /// as a string as an argument to determine which fuel is appropriate for this type of vehicle.
    /// - that its tank capacity is a hardcoded integer that differs from both 'Car' and 'HGV'.
    /// - that its original fuel level is defined through the use of the 'GetRandom' method in 'Data'
    /// (See Data.cs for more on that)
    /// </summary>
    /// 
    public class Van : Vehicle
    {
        public Van()
        {
            fuelType = Data.ChooseFuelType("Van");
            vehicleType = "Van     ";
            carID = nextCarID++;
            tankCapacity = 80;
            originalFuelLevel = Data.rnd.Next(0, Convert.ToInt32(tankCapacity * 0.25));
            fuelTime = ((tankCapacity - originalFuelLevel) / Pump.fuelingRate) * 1000;
        }
    }
}
