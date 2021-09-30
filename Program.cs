using System;
using System.Timers;

namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This class can be seen as a kind of 'backbone' or 'cornerstone' to the rest of the program.
    /// Its layout is relatively succinct. It consists almost exclusively of statements which invoke
    /// key methods in other classes. A quick look over this class will give a developer a general
    /// idea of how this program functions as a whole.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /* Within 'Main', a method is invoked which sets up much of the framework of the rest of the program
             * (See 'Data.Initialise' for more on this).
             * Then, a timer is started which resets 2.2 seconds. Each time it elapses, 'RunProgramLoop' is invoked
             * (see below).
             * Finally, Console.ReadLine is used to allow the user to terminate the program when they wish.
             */

            Data.Initialise();

            Timer timer = new Timer();
            timer.Interval = 2200;
            timer.AutoReset = true;
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            /* These methods are called every 2.2 seconds. Each one either relates to clearing or
             * re-drawing the display on the console, with the exception of the last one,
             * which assigns a vehicle to a pump.
             */
            Console.Clear();
            Display.DrawVehicles();
            Console.WriteLine(); 
            Console.WriteLine();
            Display.DrawPumps();
            Display.DrawCounters();
            Display.DrawTransactions();
            Data.AssignVehicleToPump();
        }
}
}
