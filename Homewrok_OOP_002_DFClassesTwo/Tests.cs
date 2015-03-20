
namespace HomeworkOOP_DefiningClassesTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Homewrok_OOP_002_DFClassesTwo;
    using Homewrok_OOP_002_DFClassesTwo.Generic;
    using Homewrok_OOP_002_DFClassesTwo.Matrix;

    [Version(VersionAttribute.Type.Class, "Beta Version", "ver.0.97")] // version attrributes - MUST be within namespce and the class/struct/intergfacce

    class Test
    {

        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('=', 50));
            Console.Write(new string('=', 20)); Console.Write("TASK 1-4 tests"); Console.WriteLine(new string('=', 16));
            Console.WriteLine(new string('=', 50));

            #region CONSOLE TEST FOR TASK 1-4
            Point3D testPoint = new Point3D(1, 2, 1); // new instance of struck OPoint3D and printin it task1
            string testPrint = testPoint.ToString();
            Console.WriteLine("Last point coordinates :");
            Console.WriteLine(testPrint);

            string testTwo = Point3D.StartPoint.ToString(); //calling the readonly start postition zero point from Point3D and using overrided toString
            Console.WriteLine("Start point coordinates :");
            Console.WriteLine(testTwo);

            Point3D pointOne = new Point3D(1, 2, 3); //testing task 3
            Point3D pointTwo = new Point3D(3, 2, 0);
            double distanceTest = DistanceCalculator.Calculator3DPoints(pointOne, pointTwo);
            Console.WriteLine("The distance within point [{0}] and point[{1}] is : {2:F2}", pointOne.ToString(), pointTwo.ToString(), distanceTest);

            //task 4
            Path pathTest = new Path();
            pathTest.AddPoint(pointOne); //adding some points
            pathTest.AddPoint(pointTwo);
            Console.WriteLine(pathTest.ToString()); // notice that hthis overrider ToString comes from Path class not like the one above....
            pathTest.AddPoint(new Point3D(4, 5, 6));
            Console.WriteLine(pathTest.ToString());
            pathTest.RemovePoint(pointOne); // removing a point from the sequence
            pathTest.RemovePoint(pathTest[0]); // REMOVING by the manual index!
            Console.WriteLine(pathTest.ToString());

            List<Point3D> pathTestTwo = new List<Point3D>();
            pathTestTwo.Add(new Point3D(22, 25, 28));
            pathTestTwo.Add(new Point3D(33, 36, 37));
            pathTestTwo.Add(new Point3D(44, 45, 49));
            Console.WriteLine(pathTestTwo.Count);
            pathTest.AddRangePoints(pathTestTwo); // add range via List
            Console.WriteLine(pathTest.ToString()); // printing the collection with the added range
            Console.WriteLine();
            //end task 4

            //task 4 - save and load to/from external file (using txt)
            Console.WriteLine("Saving the pathTest in the main solution folder");
            PathStorage.SavePathTXT(pathTest, "../3DSpaceDots_TEXT_TEST"); // saving the dots to the main directpry of the Solution
            // PathStorage.SavePathPDF(pathTest, "../3DSpaceDots_TEXT_TEST"); //to PDF
            // PathStorage.SavePathDOC(pathTest, "../3DSpaceDots_TEXT_TEST"); // to DOC
            Console.WriteLine("SAVE Succesful!!"); Console.WriteLine();

            Console.WriteLine("Loading from file into new Path collection");
            Path loadTestPath = PathStorage.LoadPath("../../3DSpaceDots_TEXT_TEST.txt");
            Console.WriteLine(loadTestPath.ToString());
            #endregion

            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(new string('=', 50));
            Console.Write(new string('=', 20)); Console.Write("TASK 5-7 tests"); Console.WriteLine(new string('=', 16));
            Console.WriteLine(new string('=', 50));

            #region Console Test TASKS 5-7
            //test task 5
            GenericList<int> testGeneric = new GenericList<int>();
            testGeneric.Add(3);
            testGeneric.Add(5);
            testGeneric.Add(99);
            testGeneric.Add(12);
            Console.WriteLine("ADD four elements (3 5 99 12)");
            Console.WriteLine(testGeneric.ToString());

            testGeneric.RemoveAt(2);
            Console.WriteLine("Remove At index [2] ");
            Console.WriteLine(testGeneric.ToString());

            Console.WriteLine("Index of [12]");
            Console.WriteLine(testGeneric.IndexOf(12));

            testGeneric.InserAt(1, 77);
            Console.WriteLine("Insert integer[77] at index1]");
            Console.WriteLine(testGeneric.ToString());

            Console.WriteLine("Is element [77] present in the collection? ");
            Console.WriteLine(testGeneric.FindElement(77));

            Console.WriteLine();
            Console.WriteLine("Returning the Minimal element");
            Console.WriteLine(testGeneric.Min());
            Console.WriteLine("Volumeto to the MAX");
            Console.WriteLine(testGeneric.Max());
            #endregion

            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(new string('=', 50));
            Console.Write(new string('=', 20)); Console.Write("TASK 8-11 tests"); Console.WriteLine(new string('=', 16));
            Console.WriteLine(new string('=', 50));

            #region Test TASKS 8-10
            Matrix<int> testMatrix = new Matrix<int>(2, 2);
            testMatrix[0, 0] = 2;
            testMatrix[0, 1] = 1;


            testMatrix[1, 0] = 3;
            testMatrix[1, 1] = 4;


            Console.WriteLine("Sample matrix");
            Console.WriteLine(testMatrix.ToString());

            Console.WriteLine("Testing indexing call");
            Console.WriteLine("At postition [1,1] in the matrix we have value : {0}", testMatrix[1, 1]); //test indexing

            Matrix<int> newMatrix = new Matrix<int>(2, 2);
            newMatrix[0, 0] = 5;
            newMatrix[0, 1] = 2;


            newMatrix[1, 0] = 1;
            newMatrix[1, 1] = 4;

            Console.WriteLine("Printgin new matrix (which we will later ad to the old one)");
            Console.WriteLine(newMatrix.ToString());

            testMatrix = testMatrix + newMatrix;
            Console.WriteLine("ADDING the Two Matrixes");
            Console.WriteLine(testMatrix.ToString());

            testMatrix = testMatrix - newMatrix;
            Console.WriteLine("Now SUBSTRACTING two matrixes (from the new result substract the second matrix to return the first)");
            Console.WriteLine(testMatrix.ToString());

            testMatrix = testMatrix * newMatrix;
            Console.WriteLine("Now testing MULTIPLY operator");
            Console.WriteLine(testMatrix.ToString());


            Console.WriteLine("And finally testing the TRUE?FALSE (for zero-based elements)");
            if (testMatrix) // testing the true/false overrided operators
            {
                Console.WriteLine("No zero-based elements in matrix \n{0}", testMatrix.ToString());
            }
            else
            {
                Console.WriteLine("The matrix \n{0} \ncontains elements with value 0", testMatrix.ToString());
            }

            testMatrix[1, 1] = 0; Console.WriteLine("Changeing an element to 0 and test again");
            if (testMatrix) // testing the true/false overrided operators
            {
                Console.WriteLine("No zero-based elements in matrix \n{0}", testMatrix.ToString());
            }
            else
            {
                Console.WriteLine("The matrix \n{0}\ndo contains elements with value 0", testMatrix.ToString());
            }
            #endregion

            Console.ResetColor();
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new string('=', 50));
            Console.Write(new string('=', 20)); Console.Write("TASK 11 test"); Console.WriteLine(new string('=', 18));
            Console.WriteLine(new string('=', 50));

            Type type = typeof(Test);
            object[] attr = type.GetCustomAttributes(false);
            foreach (VersionAttribute item in attr)
            {
                Console.WriteLine(item.TypeEnum);
                Console.WriteLine(item.Version);
                Console.WriteLine(item.Name);
            }
        }
    }
}
