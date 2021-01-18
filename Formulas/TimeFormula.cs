using System;
using System.IO;
using RelativityFormulas.Classes;
using RelativityFormulas.Extensions;

namespace RelativityFormulas.Formulas
{
    public static class TimeFormula
    {

        /// <summary>
        /// Top level method for deterimining Time Gradient an object is "in".
        /// Calculates the time gradient due to proximity to a Mass, as well as to the object's own acceleration
        /// (check this. Could be double calculating based on Acceleration, and then Velocity on the next line)
        /// </summary>
        /// <param name="massBody1"></param>
        /// <param name="massBody2"></param>
        /// <param name="additionalDistanceBeyondRadii"></param>
        /// <returns></returns>
        public static MassBody CalculateTimeDilation(this MassBody massBody1, MassBody massBody2 = null, double additionalDistanceBeyondRadii = 0)
        {
            var massDilation = 1 - ( massBody2 != null ? massBody1.GetTimeDilationFactorDueToMass(massBody2, additionalDistanceBeyondRadii) : 1);
            
            var velocityDilation = 1 - GetTimeDilationFactorDueToVelocity(massBody1.Velocity);

            var returnMassBody = massBody1.Copy();

            returnMassBody.TimeDilation = 1 - massDilation - velocityDilation;
            return returnMassBody;
        }

        /// <summary>
        /// 
        /// T' = T * Sqrt( 1 - (2gR/C_squared))
        /// </summary>
        /// <param name="massBody1">
        ///     .Radius - in Meters
        ///     .Mass - in Kilograms
        ///     .Acceleration - in Meters / Second squared
        /// </param>
        /// <param name="massBody2">
        ///     .Radius - in Meters
        ///     .Mass - in Kilograms
        /// </param>
        /// <param name="additionalDistanceBeyondRadii">in Meters</param>
        /// <returns></returns>
        public static double GetTimeDilationFactorDueToMass(this MassBody massBody1, MassBody massBody2, double additionalDistanceBeyondRadii = 0)
        {
            var unDilatedTime = 1;//I know this is unnecessary, but it makes it easier to relate the formula back to relativity formulas
            var velocityMetersPerSecondSquared = massBody1.CalculateWeightForce(massBody2, additionalDistanceBeyondRadii).WeightForce;//This needs to be the velocity at that point in space, or on the surface.



            //This is actually the Lorentz Factor/Gamma, with the "2 * radius" multiplied in.  Why? Why (2 * radius)?
            //See LorentzFormula.cs line 17-43 ish

            //var radius = massBody1.Radius + massBody2.Radius + additionalDistanceBeyondRadii;
            //var dilatedTime = unDilatedTime * Math.Sqrt(1 - ((2 * radius * velocityMetersPerSecondSquared) / Constants.SPEED_OF_LIGHT_SQUARED_ms));
            //Mws: this was wrong above. Should be
            var dilatedTime = unDilatedTime * Math.Sqrt(1 - ((2 * velocityMetersPerSecondSquared) / Constants.SPEED_OF_LIGHT_SQUARED_ms));

            return dilatedTime;
        }


        /// <summary>
        /// This will return the time dilation factor compared to 1 second.
        /// </summary>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public static double GetTimeDilationFactorDueToVelocity(double velocity)
        {
            //As far as we know, it isn't possible to go the speed
            if (velocity > Constants.SPEED_OF_LIGHT_ms)
            {
               throw new Exception("As far as we know it isn't possible to go the speed of light");
            }

            //only things with 0 Mass like Photons can go the speed of light, and Time stops
            //This won't return the correct answer at speeds really close to C, but good enough for now
            if (velocity.Equals4DigitPrecision(Constants.SPEED_OF_LIGHT_ms)) return 0;

            return 1 / LorentzFormula.IncreaseDueToVelocity_LorentzFactor_Gamma(velocity);
        }



        #region Unused for now
        // public static MassBody GetMassBody_TimeDilationFactorDueToMass(this MassBody massBody1, MassBody massBody2, double additionalDistanceBeyondRadii)
        // {
        //     var unDilatedTime = 1;
        //     var velocityMetersPerSecondSquared = massBody1.CalculateWeightForce(massBody2, additionalDistanceBeyondRadii).WeightForce;//This needs to be the velocity at that point in space, or on the surface.
        //
        //     var radius = massBody1.Radius + massBody2.Radius + additionalDistanceBeyondRadii;
        //
        //     var dilatedTime = unDilatedTime * Math.Sqrt(1 - ((2 * velocityMetersPerSecondSquared * radius) / Constants.SPEED_OF_LIGHT_SQUARED_ms));
        //
        //     var returnMassBody = massBody1.Copy();
        //     returnMassBody.TimeDilation = dilatedTime;
        //     return returnMassBody;
        // }


        // public static MassBody GetMassBody_TimeDilationFactorDueToVelocity(this MassBody massBody1)
        // {
        //     var dilatedTime = GetTimeDilationFactorDueToVelocity(massBody1.Velocity);
        //
        //     var returnMassBody = massBody1.Copy();
        //     returnMassBody.TimeDilation = dilatedTime;
        //     return returnMassBody;
        // }
        //
        //
        // public static double GetTimeDilationFactorDueToVelocity(this MassBody massBody1)
        // {
        //     return GetTimeDilationFactorDueToVelocity(massBody1.Velocity);
        // }
        #endregion
    }
}
