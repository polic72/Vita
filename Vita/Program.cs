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

            Organism o1 = new Organism(world, new Name(), new DNA(DNA_random), XYZ.Zero, XYZ.BasisX);
            Organism o2 = new Organism(world, new Name(), new DNA(DNA_random), XYZ.Zero, XYZ.BasisY);

            Corpse corpse = new Corpse(world, new XYZ(4, 0, 0), 1);

            world.AddPhysical(o1);
            world.AddPhysical(o2);

            world.AddPhysical(corpse);

            for (int i = 0; i < 30; ++i)
            {
                world.SimulateTick();

                Console.WriteLine();
                Console.ReadKey(true);
            }
        }
    }
}
