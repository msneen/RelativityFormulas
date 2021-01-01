namespace RelativityFormulas.Classes
{
    public class SpaceTimeFormula
    {
        /// <summary>
        /// This calculates the downward force due to Gravity / Time Gradient
        /// This does not currently contain the lorentzFactor to account for any velocity or acceleration
        /// </summary>
        /// <param name="celestialBody1"></param>
        /// <param name="celestialBody2"></param>
        /// <param name="additionalDistanceBeyondRadii"></param>
        /// <returns></returns>
        public static double WeightForceDueToMass(CelestialBody celestialBody1, CelestialBody celestialBody2, double additionalDistanceBeyondRadii)
        {
            var distanceBetweenCenters = celestialBody1.Radius + celestialBody2.Radius + additionalDistanceBeyondRadii;
            var mass = celestialBody1.Mass * celestialBody2.Mass;
            var distanceBetweenCentersSquared = (distanceBetweenCenters * distanceBetweenCenters);

            var massOverDistance = mass / (distanceBetweenCenters * distanceBetweenCenters);

            return (RelativityFormulas.Constants.GRAVITATIONAL_CONSTANT_nm2kg2 * mass) / distanceBetweenCentersSquared;
        }


    }
}
