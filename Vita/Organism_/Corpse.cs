using Stonis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vita.Miscellaneous;
using Vita.World_;


namespace Vita.Organism_
{
    public class Corpse : IEdible
    {
        public const double SIZE_MULTIPLIER = 5000;


        #region Properties

        /// <summary>
        /// The world that this corpse belongs to.
        /// </summary>
        public World World { get; }

        #endregion Properties


        protected XYZ position;

        protected double size;

        protected bool eaten;
        protected int energyvalue;


        /// <summary>
        /// Constructs a corpse with the given world and size (of the organism it came from).
        /// </summary>
        /// <param name="world">The world to put the corpse in.</param>
        /// <param name="position">The position the corpse is at.</param>
        /// <param name="size"></param>
        public Corpse(World world, XYZ position, double size)
        {
            World = world;

            this.position = position;
            this.size = size;

            eaten = false;

            energyvalue = (int)(size * SIZE_MULTIPLIER) / 2;
        }


        /// <summary>
        /// Marks this corpse as eaten. Nothing else can eat an eaten corpse.
        /// </summary>
        public void MarkAsEaten()
        {
            eaten = true;
        }


        /// <summary>
        /// Whether or not this corpse is eaten.
        /// </summary>
        /// <returns>Whether or not this corpse is eaten.</returns>
        public bool IsEaten()
        {
            return eaten;
        }


        /// <summary>
        /// Gets how valuable this pellet is.
        /// </summary>
        /// <returns>Gets how valuable this pellet is.</returns>
        public int GetEnergyValue()
        {
            return energyvalue;
        }


        /// <summary>
        /// The position of the corpse this tick.
        /// </summary>
        /// <returns>The position of the corpse this tick.</returns>
        public XYZ GetPosition()
        {
            return position;
        }


        /// <summary>
        /// The velocity of the corpse this tick.
        /// </summary>
        /// <returns>The velocity of the corpse this tick.</returns>
        public XYZ GetVelocity()
        {
            return XYZ.Zero;
        }


        /// <summary>
        /// The size of the corpse.
        /// </summary>
        /// <returns>The size of the corpse.</returns>
        public double GetSize()
        {
            return size;
        }


        /// <summary>
        /// What the corpse does this tick.
        /// </summary>
        public void OnTick()
        {
            //A whole lot of nothing at the moment.
            Console.WriteLine("Corpse: " + position + " - " + energyvalue);
        }
    }
}
