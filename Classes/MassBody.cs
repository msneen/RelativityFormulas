namespace RelativityFormulas.Classes
{
    public class MassBody
    {
        public double Mass { get; set; }
        public double Radius { get; set; }

        //Velocity, or InitialVelocity if calculating acceleration
        public double Velocity { get; set; }

        public double Acceleration { get; set; }

        public double WeightForce { get; set; }

        public double TimeDilation { get; set; }

        public MassBody Copy()
        {
            return (MassBody) this.MemberwiseClone();
        }
    }
}
