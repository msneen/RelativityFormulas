namespace RelativityFormulas.Converters
{
    public static class MetricStandardConverter
    {
        public static double ConvertKgToLb(double weightInKg)
        {
            return weightInKg * 2.20462;
        }

        public static double ConvertNToLb(double weightInN)
        {
            return weightInN * 0.224809;
        }

        public static double ConvertLbToKg(double weightInLb)
        {
            return weightInLb * .453592;
        }
    }
}
