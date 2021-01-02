using System;
using RelativityFormulas.Classes;

namespace RelativityFormulas.Formulas
{
    public static class WeightFormula
    {
        //If a mass is experiencing Acceleration / Weight Force / Centrifugal Force, etc, it is not centered within the Time Gradient affecting it
        //This is simplified. The acceleration should really be a 3D vector in relationship to the vector between the 2 centers of mass

        public static MassBody CalculateWeightForce(this MassBody massBody1, MassBody massBody2 = null, double additionalDistanceBeyondRadii = 0)
        {
            //Should we overwrite any weightforce already in here?
            var returnMassBody = massBody1.Copy();
            if (massBody2 != null)
            {
                returnMassBody.WeightForce += WeightForceDueToMass(massBody1, massBody2, additionalDistanceBeyondRadii);
            }

            if (massBody1.Acceleration > 0)
            {
                returnMassBody.WeightForce += WeightForceDueToAcceleration(massBody1, massBody1.Acceleration, massBody1.Velocity);
            }

            return returnMassBody;
        }

        /// <summary>
        /// This calculates the downward force due to Gravity / Time Gradient
        /// This does not currently contain the lorentzFactor to account for any velocity or acceleration
        /// </summary>
        /// <param name="massBody1"></param>
        /// <param name="massBody2"></param>
        /// <param name="additionalDistanceBeyondRadii"></param>
        /// <returns></returns>
        public static double WeightForceDueToMass(this MassBody massBody1, MassBody massBody2, double additionalDistanceBeyondRadii = 0)
        {
            var distanceBetweenCenters = massBody1.Radius + massBody2.Radius + additionalDistanceBeyondRadii;
            var mass = massBody1.Mass * massBody2.Mass;
            var distanceBetweenCentersSquared = (distanceBetweenCenters * distanceBetweenCenters);

            return (RelativityFormulas.Constants.GRAVITATIONAL_CONSTANT_nm2kg2 * mass) / distanceBetweenCentersSquared;
        }

        /// <summary>
        /// This calculates the downward force(Weight that you feel) due to Acceleration due to "pushing forward" in your own time gradient
        /// This assumes the massBody is not in any other Time Gradients except for the one produced by acceleration
        /// Where? At the Center of Mass?
        /// </summary>
        /// <param name="massBody">This is the "inertial mass"</param>
        /// <param name="accelerationMetersPerSecondSquared"></param>
        /// <returns></returns>
        public static double WeightForceDueToAcceleration(this MassBody massBody, double accelerationMetersPerSecondSquared = 0, double initialVelocity_ms = 0)
        {
            var lorentzFactor = LorentzFormula.LorentzFactor(initialVelocity_ms);//at low speeds, this is 1, at close to C, this approaches infinity

            //This insinuates that as you get closer to C, you can't accelerate very fast or you'll get crushed
            return massBody.Mass * lorentzFactor * accelerationMetersPerSecondSquared; 
        }

        /// <summary>
        /// This calculates the momentum that you have from a constant speed. you won't feel "weight" unless you are in another time gradient
        /// </summary>
        /// <param name="massBody"></param>
        /// <param name="velocity_ms"></param>
        /// <returns></returns>
        public static double MomentumForceDueToVelocity(this MassBody massBody, double velocity_ms)
        {
            var lorentzFactor = LorentzFormula.LorentzFactor(velocity_ms);//at low speeds, this is 1, at close to C, this approaches infinity
            return massBody.Mass * lorentzFactor * velocity_ms;
        }


        //*********************************************************



        public static double TotalEnergyOfMovingMass(this MassBody massBody, double velocity_ms)
        {
            var massComponent = (massBody.Mass * massBody.Mass) * Constants.SPEED_OF_LIGHT_SQUARED_ms;

            var momentum = MomentumForceDueToVelocity(massBody, velocity_ms);
            var momentumComponent = (momentum * momentum) * Constants.SPEED_OF_LIGHT_SQUARED_ms;

            return Math.Sqrt(massComponent + momentumComponent);
        }
    }
}
