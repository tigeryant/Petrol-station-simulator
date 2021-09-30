using System;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This class manages counters 1-6 (as detailed in the specification).
    /// </summary>
    class Counter
    {
        // A number of static fields are declared which relate to all the counters.

        public static double totalUnleadedDispensed;
        public static double totalDieselDispensed;
        public static double totalLPGDispensed;
        public static double totalLitresDispensed;
        public static double totalLitresCost;
        public static double onePercentCommission;
        public static int numberOfVehiclesServiced;
        public static int vehiclesLeftUnfueled;

        public static void UpdateCounters(double inUnleadedDispensed, double inDieselDispensed, double inLPGDispensed, double inCostOfLitresDispensed)
        {
            /* This method accepts arguments which detail information relating to each specific transaction that occurs.
             * Compound assignment is used to update the static fields that serve as cumulative totals of the individual
             * transaction values.
             */

            totalUnleadedDispensed += inUnleadedDispensed;
            totalDieselDispensed += inDieselDispensed;
            totalLPGDispensed += inLPGDispensed;
            totalLitresDispensed = totalLitresDispensed + inUnleadedDispensed + inDieselDispensed + inLPGDispensed;
            totalLitresCost += inCostOfLitresDispensed;
            onePercentCommission = Math.Round(totalLitresCost * 0.01, 2); // Reference 7
            numberOfVehiclesServiced++;
        }

        public static void UpdateTransactionList(Transaction transactionData)
        {
            // This method adds transaction data to the list of all transactions

            Data.transactions.Add(transactionData);
        }
    }
}
