namespace HomeworkOOP_DefiningClassesTwo
{
    using System;
    using System.IO;
    using System.Linq;

    public static class PathStorage // static class with static methods to save and load paths from a text file
    {
        #region SaveOptions
        public static void SavePathTXT(Path path, string fileName)
        {
            using (StreamWriter writer = new StreamWriter("..//" + fileName + ".txt")) // by default this will lead to the bin folder
            {
                for (int i = 0; i < path.SequencePoints.Count; i++)
                {
                    writer.WriteLine(path.SequencePoints[i]);
                }
            }
        }
        public static void SavePathDOC(Path path, string fileName)
        {
            using (StreamWriter writer = new StreamWriter("..//" + fileName + ".doc")) // by default this will lead to the bin folder
            {
                for (int i = 0; i < path.SequencePoints.Count; i++)
                {
                    writer.WriteLine(path.SequencePoints[i]);
                }
            }
        }
        public static void SavePathPDF(Path path, string fileName)
        {
            using (StreamWriter writer = new StreamWriter("..//" + fileName + ".pdf")) // by default this will lead to the bin folder
            {
                for (int i = 0; i < path.SequencePoints.Count; i++)
                {
                    writer.WriteLine(path.SequencePoints[i]);
                }
            }
        }
        #endregion

        public static Path LoadPath(string fileDestination)
        {
            Path loadedPath = new Path();

            using (StreamReader reader = new StreamReader(fileDestination))
            {
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();

                    double[] coordinates = line.Trim('[').Trim(']')
                        .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => double.Parse(x))
                        .ToArray();

                    Point3D nextPoint = new Point3D(coordinates[0], coordinates[1], coordinates[2]);
                    loadedPath.AddPoint(nextPoint);
                }
            }

            return loadedPath;
        }
    }
}
