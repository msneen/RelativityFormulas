using System;

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

            return (RelativityFormulas.Constants.GRAVITATIONAL_CONSTANT_nm2kg2 * mass) / distanceBetweenCentersSquared;
        }

        /// <summary>
        /// This calculates the downward force(Weight that you feel) due to Acceleration due to "pushing forward" in your own time gradient
        /// Where? At the Center of Mass?
        /// </summary>
        /// <param name="celestialBody">This is the "inertial mass"</param>
        /// <param name="accelerationMetersPerSecondSquared"></param>
        /// <returns></returns>
        public static double WeightForceDueToAcceleration(CelestialBody celestialBody, double accelerationMetersPerSecondSquared, double initialVelocity_ms = 0)
        {
            var lorentzFactor = LorentzFormula.LorentzFactor(initialVelocity_ms);//at low speeds, this is 1, at close to C, this approaches infinity

            //This insinuates that as you get closer to C, you can't accelerate very fast or you'll get crushed
            return celestialBody.Mass * lorentzFactor * accelerationMetersPerSecondSquared; 
        }

        /// <summary>
        /// This calculates the momentum that you have from a constant speed. you won't feel "weight" unless you are in another time gradient
        /// </summary>
        /// <param name="celestialBody"></param>
        /// <param name="velocity_ms"></param>
        /// <returns></returns>
        public static double MomentumForceDueToVelocity(CelestialBody celestialBody, double velocity_ms)
        {
            var lorentzFactor = LorentzFormula.LorentzFactor(velocity_ms);//at low speeds, this is 1, at close to C, this approaches infinity
            return celestialBody.Mass * lorentzFactor * velocity_ms;
        }

        public static double TotalEnergyOfMovingMass(CelestialBody celestialBody, double velocity_ms)
        {
            var massComponent = (celestialBody.Mass * celestialBody.Mass) * Constants.SPEED_OF_LIGHT_SQUARED_ms;

            var momentum = MomentumForceDueToVelocity(celestialBody, velocity_ms);
            var momentumComponent = (momentum * momentum) * Constants.SPEED_OF_LIGHT_SQUARED_ms;

            return Math.Sqrt(massComponent + momentumComponent);
        }
    }
}
