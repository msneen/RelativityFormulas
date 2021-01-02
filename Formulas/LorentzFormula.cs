using System;

namespace RelativityFormulas.Formulas
{
    public class LorentzFormula
    {
        public static double LorentzDenominator(double velocityinMetersPerSecond)
        {
            return Math.Sqrt(1 - (Math.Pow(velocityinMetersPerSecond, 2) / Constants.SPEED_OF_LIGHT_SQUARED_ms));
        }

        public static double LorentzFactor(double velocityinMetersPerSecond)
        {
            return 1 / LorentzDenominator(velocityinMetersPerSecond);
        }
    }
}
