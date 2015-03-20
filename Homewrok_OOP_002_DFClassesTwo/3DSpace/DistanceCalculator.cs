namespace HomeworkOOP_DefiningClassesTwo
{
    using System;

    public static class DistanceCalculator
    {
        // static lcass with static method for distance calculating
        /*
        d = \sqrt{(x_1 - x_2)^2 + (y_1 - y_2)^2 + (z_1 - z_2)^2 }\,
        */
        public static double Calculator3DPoints(Point3D pointOne, Point3D pointTwo)
        {
            double diffX, diffY, diffZ;
            double distance;

            diffX = pointOne.X - pointTwo.X;
            diffY = pointOne.Y - pointTwo.Y;
            diffZ = pointOne.Z - pointTwo.Z;

            distance = Math.Sqrt(Math.Pow(diffX, 2) + Math.Pow(diffY, 2) + Math.Pow(diffZ, 2));

            return distance;
        }
   
    }
}
