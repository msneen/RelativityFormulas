using System;

namespace RelativityFormulas
{
    public static class Constants
    {
        //See calculator at http://hyperphysics.phy-astr.gsu.edu/hbase/Relativ/relmom.html
        public static double GRAVITATIONAL_CONSTANT_nm2kg2 = 6.67 * Math.Pow(10, -11);//6.67 × 10−11 Nm2/kg2
        public static double SPEED_OF_LIGHT_ms = 300000;
        public static double SPEED_OF_LIGHT_SQUARED_ms = SPEED_OF_LIGHT_ms * SPEED_OF_LIGHT_ms;
        public static double PLANKS_CONSTANT = 6.62 * Math.Pow(10, -35);
    }

    public static class ColorConstants
    {
        //RED
        //GREEN
        public static double BLUE_FREQUENCY = 64 * Math.Pow(10, 13);

    }

    public static class CelestialBodyConstants
    {
        public static double EARTH_MASS_kg = 5.972 * Math.Pow(10, 24);
        public static double EARTH_RADIUS_m = 6.371 * Math.Pow(10,6);
    }
}
