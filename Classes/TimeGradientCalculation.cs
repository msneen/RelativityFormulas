using System.Collections.Generic;

namespace RelativityFormulas.Classes
{
    public class TimeGradientCalculation
    {
        public MassBody MassBodyBeingCalculated { get; set; }
        public MassBody MassBodyInProximity { get; set; }

        public double NumberOfProximityRadiiToCalculate { get; set; }

        public List<TimeGradientRadiusCalculation> TimeGradientRadiusCalculations { get; set; } = new List<TimeGradientRadiusCalculation>();
    }

    public class TimeGradientRadiusCalculation
    {
        public int RadiusFromCenter { get; set; }
        public double WeightForceAtRadius { get; set; }

        public double TimeDilationAtRadius { get; set; }
    }
}
