namespace Assignment_2_PetrolStation
{
    /// <summary>
    /// This class, appropriately titled 'Lane Manager' contains methods that
    /// pertain to the handling of any blocking and unblocking of lanes
    /// that occurs due to a) vehicle assignment and b) vehicle release.
    /// </summary>

    public static class LaneManager
    {
        public static void Blocker(int objectPumpNumber) // blocks appropriate pumps according to object pump position
        {
            /* This method is invoked when a vehicle is assigned to a pump.
             * It accepts one argument: the pump number of the pump that is
             * being assigned to. Based on this, it changes the state of
             * between 0 and 2 other pumps to 'Blocked'.
             *
             * Note: 'Object' and 'subject' are used to refer to
             * the pump doing the blocking and the pumps that are being
             * blocked, respectively.
             */

            Pump subject1;
            Pump subject2;

            int blocked1 = 8;
            int blocked2 = 8;

            switch (objectPumpNumber)
            {
                case 0:
                    blocked1 = 1;
                    blocked2 = 2;
                    break;
                case 1:
                    blocked1 = 2;
                    break;
                case 2:
                    break;
                case 3:
                    blocked1 = 4;
                    blocked2 = 5;
                    break;
                case 4:
                    blocked1 = 5;
                    break;
                case 5:
                    break;
                case 6:
                    blocked1 = 7;
                    blocked2 = 8;
                    break;
                case 7:
                    blocked1 = 8;
                    break;
                case 8:
                    break;
            }

            subject1 = Data.pumps[blocked1];
            subject1.state = PumpState.Blocked;

            subject2 = Data.pumps[blocked2];
            subject2.state = PumpState.Blocked;
        }

        public static void Unblocker(int objectPumpNumber)
        {
            /* This method is invoked when a vehicle leaves a pump.
             * It accepts an argument that defines the pump that is
             * being freed. Based on this, the state of another pump
             * in the lane is checked, and then the appropriate pump
             * is unblocked.
             */

            Pump check1;
            Pump subject1;
            Pump subject2;

            switch (objectPumpNumber)
            {
                case 0:
                    subject1 = Data.pumps[1];
                    subject1.state = PumpState.NotBlocked;

                    check1 = Data.pumps[1];
                    if (check1.currentVehicle == null)
                    {
                        subject2 = Data.pumps[2];
                        subject2.state = PumpState.NotBlocked;
                    }
                    break;
                case 1:
                    check1 = Data.pumps[0];
                    if (check1.currentVehicle == null)
                    {
                        subject1 = Data.pumps[2];
                        subject1.state = PumpState.NotBlocked;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    subject1 = Data.pumps[4];
                    subject1.state = PumpState.NotBlocked;

                    check1 = Data.pumps[4];
                    if (check1.currentVehicle == null)
                    {
                        subject2 = Data.pumps[5];
                        subject2.state = PumpState.NotBlocked;
                    }
                    break;
                case 4:
                    check1 = Data.pumps[3];
                    if (check1.currentVehicle == null)
                    {
                        subject1 = Data.pumps[5];
                        subject1.state = PumpState.NotBlocked;
                    }
                    break;
                case 5:
                    break;
                case 6:
                    subject1 = Data.pumps[7];
                    subject1.state = PumpState.NotBlocked;

                    check1 = Data.pumps[7];
                    if (check1.currentVehicle == null)
                    {
                        subject2 = Data.pumps[8];
                        subject2.state = PumpState.NotBlocked;
                    }
                    break;
                case 7:
                    check1 = Data.pumps[6];
                    if (check1.currentVehicle == null)
                    {
                        subject1 = Data.pumps[8];
                        subject1.state = PumpState.NotBlocked;
                    }
                    break;
                case 8:
                    break;
            }
        }
    }
}
