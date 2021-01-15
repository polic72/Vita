using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;

using Stonis;
using Vita.World_;
using Vita.Organism_;

namespace Vita
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string[] syllables = Properties.Resources.Syllables.Split('\r', '\n').Where(x => x != "").ToArray();

            Name.Init(syllables);


            World world = new World(100, 100, 100);
            Random DNA_random = new Random();

            Random pos_random = new Random();
            
            for (int i = 0; i < 10; ++i)
            {
                double x = pos_random.NextDouble() * (world.WorldSize_X - -world.WorldSize_X) + -world.WorldSize_X;
                double y = pos_random.NextDouble() * (world.WorldSize_Y - -world.WorldSize_Y) + -world.WorldSize_Y;
                double z = pos_random.NextDouble() * (world.WorldSize_Z - -world.WorldSize_Z) + -world.WorldSize_Z;

                world.AddPhysical(new Organism(world, new Name(), new DNA(DNA_random), new XYZ(x, y, z), new XYZ(x, y, z).Normalize()));
            }


            while (true)
            {
                world.SimulateTick();

                Console.WriteLine();
                Console.ReadKey(true);

                Console.Clear();
            }
        }
    }
}
