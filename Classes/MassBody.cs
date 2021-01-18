namespace RelativityFormulas.Classes
{
    public class MassBody
    {
        //Mass, Velocity, and TimeDilation have a direct impact on each other

        /// <summary>
        /// Kilograms. 
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Meters from Center
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// Meters/Second.
        /// Velocity, or InitialVelocity if calculating acceleration
        /// </summary>
        public double Velocity { get; set; }

        /// <summary>
        /// This is the Time Dilation.  0 means time has stopped, 1 means time is objectively at 100%, whatever that means.
        /// This only takes local gravity and acceleration into account.  Theoretically, every particle of matter in the universe has an effect on this
        /// ******************
        /// </summary>
        public double TimeDilation { get; set; }





        //Mass, Acceleration and Weight(felt weight) have a direct impact on each other
        public double Acceleration { get; set; }

        //This is calculated by Weight formulas

        /// <summary>
        /// This is Newtons of Weight "felt" due to Time Gradient / Gravity
        /// This only takes local gravity and acceleration into account.  Theoretically, every particle of matter in the universe has an effect on this
        /// *************
        /// </summary>
        public double WeightForce { get; set; }



        public MassBody Copy()
        {
            return (MassBody) this.MemberwiseClone();
        }
    }
}
