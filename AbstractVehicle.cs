namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This is an abstract class which serves as a parent to three child classes which inherit from it: Car, Van
    /// and HGV. Its fields define properties that are relevant to all classes that inherit from it.
    /// </summary>

    public abstract class Vehicle
    {
        public string fuelType;
        public string vehicleType;
        public static int nextCarID;
        public int carID;
        public double tankCapacity;
        public double originalFuelLevel;
        public double fuelTime;
    }
}
