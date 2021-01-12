using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stonis;
using Vita.World_;

namespace Vita.Miscellaneous
{
    public static class Helpers
    {
        /// <summary>
        /// Validates that the input point is within the given World's design limits.
        /// </summary>
        /// <param name="world">The world to test.</param>
        /// <returns>True if the input point is within the given World's design limits, false otherwise.</returns>
        /// <remarks>Used to validate input for geometry construction methods.</remarks>
        public static bool IsWithinLengthLimits(this XYZ xyz, World world)
        {
            return (xyz.X <= world.WorldSize_X) && (xyz.Y <= world.WorldSize_Y) && (xyz.Z <= world.WorldSize_Z);
        }
    }
}
