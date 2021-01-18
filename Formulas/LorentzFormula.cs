using System;

namespace RelativityFormulas.Formulas
{
    public static class LorentzFormula
    {
        public static double VelocityAsFractionOfSpeedOfLight_Beta(double velocityInMetersPerSecond)
        {
            return velocityInMetersPerSecond / Constants.SPEED_OF_LIGHT_SQUARED_ms;
        }

        /// <summary>
        /// returns the fraction of the velocity divided by the speed of light
        /// </summary>
        /// <param name="velocityInMetersPerSecond"></param>
        /// <returns></returns>
        public static double VelocitySquaredAsFractionOfSpeedOfLightSquared_BetaSquared(double velocityInMetersPerSecond)
        {
            return Math.Pow(velocityInMetersPerSecond, 2) / Constants.SPEED_OF_LIGHT_SQUARED_ms;
        }

        /// <summary>
        /// The closer Velocity is to the speed of light, the smaller this will become
        /// </summary>
        /// <param name="velocityInMetersPerSecond"></param>
        /// <returns></returns>
        public static double DecreaseDueToVelocity_LorentzDenominator_Gamma(double velocityInMetersPerSecond)
        {
            var velocityAsFractionOfSpeedOfLight_Beta = VelocitySquaredAsFractionOfSpeedOfLightSquared_BetaSquared(velocityInMetersPerSecond);

            return Math.Sqrt(1 - velocityAsFractionOfSpeedOfLight_Beta);
        }


        /// <summary>
        /// The closer Velocity is to the speed of light, the larger this will become
        /// </summary>
        /// <param name="velocityInMetersPerSecond"></param>
        /// <returns></returns>
        public static double IncreaseDueToVelocity_LorentzFactor_Gamma(double velocityInMetersPerSecond)
        {
            return 1 / DecreaseDueToVelocity_LorentzDenominator_Gamma(velocityInMetersPerSecond);
        }
    }
}
