using System;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This class can be regarded as a framework for the transactions that take place each time a vehicle is serviced.
    /// Its fields relate to aspects of a transaction that are recorded.
    /// </summary>

    class Transaction
    {
        public string vehicleType;
        public int vehicleID;
        public string fuelType;
        public double litresThisTransaction;
        public double fuelCost;
        public int pumpNumber;
        public DateTime timeStamp; // Reference 1

        public override string ToString() // References 4 and 5
        {
            /* This method overrides a virtual method 'ToString' found in the 'object' class. 
             * All classes, are, by nature, children of the 'object' class, and, accordingly, any class can override
             * the 'ToString' method. This allows us to change the format in which an object is displayed when we
             * convert it to a string. Here, it is used to display the values of its properties, along with
             * '\t' which spaces them out appropriately.
             */

            return vehicleType + "\t" + (vehicleID + 1) + "\t\t" + fuelType + "\t" + litresThisTransaction + "\t\t\t" + fuelCost + "\t\t\t\t" + (pumpNumber + 1) + "\t\t" + timeStamp;
        }

        public Transaction(string inVehicleType, int inVehicleID, string inFuelType, double inLitresThisTransaction, double inFuelCost, int inPumpNumber, DateTime inTimeStamp)
        {
            /* This is a constructor. It is invoked each time an object based on this class is instantiated.
             * It accepts arguments which relate to a specific transaction and assign these values to the properties
             * listed above. 
             */

            vehicleType = inVehicleType;
            vehicleID = inVehicleID;
            fuelType = inFuelType;
            litresThisTransaction = inLitresThisTransaction;
            fuelCost = inFuelCost;
            pumpNumber = inPumpNumber;
            timeStamp = inTimeStamp;
        }
    }
}
