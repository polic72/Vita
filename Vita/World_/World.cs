using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Object = Vita.Object_.Object;
using Vita.Miscellaneous;
using System.Windows.Shapes;
using System.Windows.Media;

using Stonis;

namespace Vita.World_
{
    /// <summary>
    /// A world that is simulated.
    /// </summary>
    public class World
    {
        public int WorldSize_X { get; }
        public int WorldSize_Y { get; }
        public int WorldSize_Z { get; }

        protected HashSet<IPhysical> physicals;


        /// <summary>
        /// Constructs a world with the given physical limits.
        /// </summary>
        /// <param name="worldSize_X">The X limit of the world.</param>
        /// <param name="worldSize_Y">The Y limit of the world.</param>
        /// <param name="worldSize_Z">The Z limit of the world.</param>
        public World(int worldSize_X, int worldSize_Y, int worldSize_Z)
        {
            WorldSize_X = worldSize_X;
            WorldSize_Y = worldSize_Y;
            WorldSize_Z = worldSize_Z;

            physicals = new HashSet<IPhysical>();
        }


        /// <summary>
        /// Adds the given physical to the world.
        /// </summary>
        /// <param name="physical">The physical to add.</param>
        public void AddPhysical(IPhysical physical)
        {
            physicals.Add(physical);
        }


        /// <summary>
        /// Simulates a tick.
        /// </summary>
        public void SimulateTick()
        {
            foreach (IPhysical physical in physicals)
            {
                physical.OnTick();
            }
        }
    }
}
