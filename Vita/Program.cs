using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

using Stonis;
using Vita.Miscellaneous;
using Vita.Organism;
using Vita.Graphics;

namespace Vita
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            XYZ v = new XYZ(1, 2, 3);
            XYZ u = new XYZ(0, 5, 8);
            XYZ fuck = new XYZ(1, 2, 3);
            XYZ you = new XYZ(0, 5, 8).Negate();

            Console.WriteLine(v.DistanceTo(u));

            Console.WriteLine(v.GetHashCode());
            Console.WriteLine(u.GetHashCode());

            Console.WriteLine(v.ParallelWith(u) + " " + u.ParallelWith(you));


            XYZ a = new XYZ(3, 7, 0);
            XYZ b = new XYZ(2, 1, 0);

            Console.WriteLine(a.AngleOnPlaneTo(b, XYZ.BasisY));
            Console.WriteLine(a.AngleTo(b));


            IFormatter formatter = new BinaryFormatter();

            FileStream fileStream = new FileStream(
                @"C:\Users\stonisg\source\repos\Vita\Vita\bin\x64\Debug\oh.txt", FileMode.Create);

            DNA dna = new DNA("a");

            formatter.Serialize(fileStream, dna);

            //formatter.Deserialize();


            Console.ReadKey();


            World_.World world = new World_.World(0, 0, 0);

            Console.ReadKey();
        }
    }
}
