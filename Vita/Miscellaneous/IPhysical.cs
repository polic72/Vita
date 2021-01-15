using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vita.Miscellaneous;
using Stonis;

namespace Vita.Miscellaneous
{
    public interface IPhysical
    {
        /// <summary>
        /// The position of the physical this tick.
        /// </summary>
        /// <returns>The position of the physical this tick.</returns>
        XYZ GetPosition();


        /// <summary>
        /// The velocity of the physical this tick.
        /// </summary>
        /// <returns>The velocity of the physical this tick.</returns>
        XYZ GetVelocity();


        /// <summary>
        /// The size of the physical.
        /// </summary>
        /// <returns>The size of the physical.</returns>
        double GetSize();


        /// <summary>
        /// Adds velocity to the physical's current velocity.
        /// </summary>
        /// <param name="velocity">The velocity to add.</param>
        //void AddVelocity(XYZ velocity);
        //TODO this when collisions are done.


        /// <summary>
        /// What the physical does this tick.
        /// </summary>
        void OnTick();
    }
}
