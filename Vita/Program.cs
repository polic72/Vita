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


            World world = new World(1000, 1000, 1000);
            Random DNA_random = new Random();

            Random pos_random = new Random();
            
            for (int i = 0; i < 1; ++i)
            {
                world.AddPhysical(new Organism(world, new Name(), new DNA(DNA_random), pos_random.NextCoordinate(-world.WorldSize_X, world.WorldSize_X), 
                    pos_random.NextVector(), pos_random));
            }


            while (true)
            {
                world.SimulateTick();

                Console.WriteLine();
                Console.ReadKey(true);

                if (world.GetPhysicalsInArea_Nice(XYZ.Zero, 2 * world.WorldSize_X).Where(x => x is Organism).Count() == 0)
                {
                    break;
                }

                Console.Clear();
            }
        }
    }
}
