namespace HomeworkOOP_DefiningClassesTwo
{
    using System;

    public struct Point3D
    {
        #region fields
        private static readonly Point3D O; ////task 2 (Add a private static read-only field to hold the start of the coordinate system – the point O{0, 0, 0}.)

        private double x; //task 1
        private double y;
        private double z;

        #endregion

        #region constructors

        public Point3D(double x, double y, double z)
            : this() //task 1
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        #endregion

        #region properties

        public static Point3D StartPoint //task 2
        {
            get { return Point3D.O; }
        }

        public double X //task 1
        {
            get { return x; }
            private set { x = value; }
        }

        public double Y //task 1
        {
            get { return y; }
            private set { y = value; }
        }

        public double Z //task 1
        {
            get { return z; }
            private set { z = value; }
        }

        static Point3D() //task 2   static property to return the point O.
        {
            O = new Point3D(0, 0, 0);
        }

        #endregion

        #region methods

        public override string ToString()
        {
            return string.Format("[ {0}, {1}, {2} ]", this.X, this.Y, this.Z);
        }

        #endregion
    }
}
