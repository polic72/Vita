﻿using Stonis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vita.Miscellaneous;
using Vita.World_;


namespace Vita.Organism_
{
    public class Corpse : IPhysical
    {
        public const double SIZE_MULTIPLIER = 5000;


        #region Properties

        /// <summary>
        /// The world that this corpse belongs to.
        /// </summary>
        public World World { get; }


        /// <summary>
        /// The energy value this corpse is worth eating.
        /// </summary>
        public int EnergyValue { get; }


        /// <summary>
        /// Whether or not this corpse is eaten.
        /// </summary>
        public bool IsEaten { get; protected set; }

        #endregion Properties


        protected XYZ position;

        protected double size;


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

            EnergyValue = (int)(size * SIZE_MULTIPLIER) / 2;
        }


        /// <summary>
        /// Marks this corpse as eaten. Nothing else can eat an eaten corpse.
        /// </summary>
        public void MarkAsEaten()
        {
            IsEaten = true;
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
            Console.WriteLine("Corpse: " + position + " - " + EnergyValue);
        }
    }
}
