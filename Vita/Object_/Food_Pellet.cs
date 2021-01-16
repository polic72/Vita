using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stonis;
using Vita.Miscellaneous;
using Vita.Organism_;
using Vita.World_;

namespace Vita.Object_
{
    public class Food_Pellet : IEdible
    {
        /// <summary>
        /// The world that this organism belongs to.
        /// </summary>
        public World World { get; }


        protected XYZ position;

        protected double size;

        protected bool eaten;
        protected int energyvalue;


        /// <summary>
        /// Constructs a food pellet at the given position in the given world. 
        /// </summary>
        /// <param name="world">The world the pellet is in.</param>
        /// <param name="position">Where the pellet is.</param>
        /// <param name="size">The size of the pellet.</param>
        public Food_Pellet(World world, XYZ position, double size)
        {
            World = world;

            this.position = position;
            this.size = size;

            eaten = false;

            energyvalue = (int)(size * Corpse.SIZE_MULTIPLIER) / 4;
        }


        /// <summary>
        /// Marks this pellet as eaten. Nothing else can eat an eaten pellet.
        /// </summary>
        public void MarkAsEaten()
        {
            eaten = true;
        }


        /// <summary>
        /// Whether or not this pellet is eaten.
        /// </summary>
        /// <returns>Whether or not this pellet is eaten.</returns>
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
        /// The position of the pellet this tick.
        /// </summary>
        /// <returns>The position of the pellet this tick.</returns>
        public XYZ GetPosition()
        {
            return position;
        }


        /// <summary>
        /// The size of the pellet.
        /// </summary>
        /// <returns>The size of the pellet.</returns>
        public double GetSize()
        {
            return size;
        }


        /// <summary>
        /// The velocity of the pellet this tick.
        /// </summary>
        /// <returns>The velocity of the pellet this tick.</returns>
        public XYZ GetVelocity()
        {
            return XYZ.Zero;    //TODO change when things can be pushed.
        }


        public void OnTick()
        {
            //Nothing.
        }
    }
}
