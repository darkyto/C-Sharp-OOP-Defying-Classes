namespace HomeworkOOP_DefiningClassesTwo
{
    using System;
    using System.Collections.Generic;

    public class Path // TASK 4  :  Create a class Path to hold a sequence of points in the 3D space.
    {
        #region field
        private List<Point3D> sequencePoints;
        #endregion

        #region constructor
        public Path()
        {
            this.sequencePoints = new List<Point3D>();
        }
        #endregion

        #region properties
        public List<Point3D> SequencePoints
        {
            get { return this.sequencePoints; }
            private set { this.sequencePoints = value; }
        }

        public Point3D this[int index]
        {
            get { return this.SequencePoints[index]; }
            set { this.SequencePoints[index] = value; }
        }

        public int Count 
        { 
            get
            {
                return this.sequencePoints.Count;
            }
        }
        #endregion

        #region methods

        public void AddPoint(Point3D point)
        {
            this.sequencePoints.Add(point);
        }
        public void AddRangePoints(ICollection<Point3D> points) // this will allow to enter multiply pooints via any ICollectible(List array ect.)
        {
            this.sequencePoints.AddRange(points);
        }
        public void RemovePoint(Point3D point)
        {
            this.sequencePoints.Remove(point);
        }
        public void ClearAllPoints()
        {
            this.sequencePoints.Clear();
        }
        public override string ToString()
        {
            return string.Join(" >>> ",  this.sequencePoints);
        }

        #endregion
    }
}
