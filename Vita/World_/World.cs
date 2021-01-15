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

        protected Queue<IPhysical> addition_queue;
        protected Queue<IPhysical> destruction_queue;


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
            addition_queue = new Queue<IPhysical>();
            destruction_queue = new Queue<IPhysical>();
        }


        /// <summary>
        /// Adds the given physical to the world.
        /// </summary>
        /// <param name="physical">The physical to add.</param>
        public void AddPhysical(IPhysical physical)
        {
            addition_queue.Enqueue(physical);
        }


        /// <summary>
        /// Destroys the given physical from the world.
        /// </summary>
        /// <param name="physical">The physical to destroy.</param>
        public void DestroyPhysical(IPhysical physical)
        {
            destruction_queue.Enqueue(physical);
        }


        /// <summary>
        /// Tells whether or not the given point is out of the bounds of this world.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <returns>True if out of bounds. False otherwise.</returns>
        public bool OutOfBounds(XYZ point)
        {
            if ((point.X > WorldSize_X || point.X < -WorldSize_X)
                || (point.Y > WorldSize_Y || point.Y < -WorldSize_Y)
                || (point.Z > WorldSize_Z || point.Z < -WorldSize_Z))
            {
                return true;
            }

            return false;
        }


        #region Get Physicals in Area

        /// <summary>
        /// Gets all of the physicals (excluding the given) in the given spherical area. If any part of a physical clips the area, it will be returned.
        /// </summary>
        /// <param name="center">The center of the sphere to check.</param>
        /// <param name="radius">The radius of the sphere to check.</param>
        /// <param name="physicalsToIgnore">The physicals to exclude from this check.</param>
        /// <returns>The physicals in this area.</returns>
        /// <exception cref="System.ArgumentException">When the center is out of bounds or the radius is <= 0.</exception>
        public IEnumerable<IPhysical> GetPhysicalsInAreaExcluding_Nice(XYZ center, double radius, IEnumerable<IPhysical> physicalsToIgnore)
        {
            if (OutOfBounds(center))
            {
                throw new ArgumentException("The center is out of bounds.", "center");
            }

            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be a positive non-zero number.", "radius");
            }


            LinkedList<IPhysical> found = new LinkedList<IPhysical>();

            foreach (IPhysical physical in physicals)
            {
                if (physicalsToIgnore.Contains(physical))
                {
                    continue;
                }


                if (center.DistanceTo(physical.GetPosition()) <= (radius + physical.GetSize()))
                {
                    found.AddLast(physical);
                }
            }

            return found;
        }


        /// <summary>
        /// Gets all of the physicals in the given spherical area. If any part of a physical clips the area, it will be returned.
        /// </summary>
        /// <param name="center">The center of the sphere to check.</param>
        /// <param name="radius">The radius of the sphere to check.</param>
        /// <returns>The physicals in this area.</returns>
        /// <exception cref="System.ArgumentException">When the center is out of bounds or the radius is <= 0.</exception>
        public IEnumerable<IPhysical> GetPhysicalsInArea_Nice(XYZ center, double radius)
        {
            return GetPhysicalsInAreaExcluding_Nice(center, radius, new IPhysical[0]);
        }


        /// <summary>
        /// Gets all of the physicals (excluding the given) in the given spherical area. A physical must be entirely enveloped in the area to be returned.
        /// </summary>
        /// <param name="center">The center of the sphere to check.</param>
        /// <param name="radius">The radius of the sphere to check.</param>
        /// <param name="physicalsToIgnore">The physicals to exclude from this check.</param>
        /// <returns>The physicals in this area.</returns>
        /// <exception cref="System.ArgumentException">When the center is out of bounds or the radius is <= 0.</exception>
        public IEnumerable<IPhysical> GetPhysicalsInAreaExcluding_Mean(XYZ center, double radius, IEnumerable<IPhysical> physicalsToIgnore)
        {
            if (OutOfBounds(center))
            {
                throw new ArgumentException("The center is out of bounds.", "center");
            }

            if (radius <= 0)
            {
                throw new ArgumentException("The radius must be a positive non-zero number.", "radius");
            }


            LinkedList<IPhysical> found = new LinkedList<IPhysical>();

            foreach (IPhysical physical in physicals)
            {
                if (physicalsToIgnore.Contains(physical))
                {
                    continue;
                }


                if (center.DistanceTo(physical.GetPosition()) <= (radius - physical.GetSize()))
                {
                    found.AddLast(physical);
                }
            }

            return found;
        }


        /// <summary>
        /// Gets all of the physicals in the given spherical area. A physical must be entirely enveloped in the area to be returned.
        /// </summary>
        /// <param name="center">The center of the sphere to check.</param>
        /// <param name="radius">The radius of the sphere to check.</param>
        /// <returns>The physicals in this area.</returns>
        /// <exception cref="System.ArgumentException">When the center is out of bounds or the radius is <= 0.</exception>
        public IEnumerable<IPhysical> GetPhysicalsInArea_Mean(XYZ center, double radius)
        {
            return GetPhysicalsInAreaExcluding_Mean(center, radius, new IPhysical[0]);
        }

        #endregion Get Physicals in Area


        /// <summary>
        /// Simulates a tick.
        /// </summary>
        public void SimulateTick()
        {
            while (destruction_queue.Count > 0)
            {
                physicals.Remove(destruction_queue.Dequeue());
            }

            while (addition_queue.Count > 0)
            {
                physicals.Add(addition_queue.Dequeue());
            }


            foreach (IPhysical physical in physicals)
            {
                physical.OnTick();
            }
        }
    }
}
