using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stonis;

using Vita.Miscellaneous;
using Vita.World_;


namespace Vita.Organism_
{
    /// <summary>
    /// An organism.
    /// </summary>
    public class Organism : IPhysical
    {
        public static readonly double MIN_SIZE = .1;
        public static readonly double MAX_SIZE = 10;


        #region Properties

        /// <summary>
        /// The name of the organism.
        /// </summary>
        public Name Name { get; }


        /// <summary>
        /// The DNA object of the organism.
        /// </summary>
        public DNA DNA { get; }


        /// <summary>
        /// The world that this organism belongs to.
        /// </summary>
        public World World { get; }

        #endregion Properties


        #region Internals

        /// <summary>
        /// The position of the organism.
        /// </summary>
        protected XYZ position;

        /// <summary>
        /// The direction the organism is facing.
        /// </summary>
        protected XYZ direction;

        /// <summary>
        /// The velocity of the organism. Must be the same direction as the the velocity.
        /// </summary>
        protected XYZ velocity;


        /// <summary>
        /// The energy of the organism.
        /// </summary>
        protected int energy;


        /// <summary>
        /// The maximum amount of energy this organism can hold. Based on size.
        /// </summary>
        protected readonly int energy_max;

        #endregion Internals


        protected Random random;

        protected XYZ next_pos;


        #region Constructors

        /// <summary>
        /// Constructs an organism with the given Name, DNA, position, and velocity.
        /// </summary>
        /// <param name="world">The world that the organism will inhabit.</param>
        /// <param name="name">The name of the organism.</param>
        /// <param name="dna">The DNA of the organism.</param>
        /// <param name="position">The position of the organism.</param>
        /// <param name="velocity">The velocity of the organism.</param>
        /// <param name="random">The random object to use for this organism.</param>
        public Organism(World world, Name name, DNA dna, XYZ position, XYZ velocity, Random random)
        {
            World = world;
            Name = name;
            DNA = dna;

            this.position = position;
            this.velocity = velocity;

            next_pos = position;

            direction = velocity.Normalize();

            energy_max = (int)Math.Ceiling(DNA.Size * Corpse.SIZE_MULTIPLIER);
            energy = energy_max;

            this.random = random;
        }

        /// <summary>
        /// Constructs an organism with the given Name, and DNA. Zero position and velocity.
        /// </summary>
        /// <param name="world">The world that the organism will inhabit.</param>
        /// <param name="name">The name of the organism.</param>
        /// <param name="dna">The DNA of the organism.</param>
        /// <param name="random">The random object to use for this organism.</param>
        public Organism(World world, Name name, DNA dna, Random random) : this(world, name, dna, XYZ.Zero, XYZ.Zero, random) { }

        #endregion Constructors


        /// <summary>
        /// Eats a corpse if it exists in the world. Adds its potential energy to the energy reserves of the organism.
        /// </summary>
        /// <param name="corpse">The corpse to eat.</param>
        public virtual void Eat(Corpse corpse)
        {
            if (!corpse.IsEaten)
            {
                if (energy + corpse.EnergyValue <= energy_max)
                {
                    corpse.MarkAsEaten();

                    World.DestroyPhysical(corpse);

                    energy += corpse.EnergyValue;
                }
                else
                {
                    corpse.MarkAsEaten();

                    World.DestroyPhysical(corpse);

                    World.AddPhysical(new Corpse(World, corpse.GetPosition(), (corpse.EnergyValue - (energy_max - energy)) / Corpse.SIZE_MULTIPLIER));

                    energy = energy_max;
                }
            }
        }


        /// <summary>
        /// Reproduces this organism into the location specified. This action takes 0% max energy to do. Child starts at 50% energy.
        /// </summary>
        /// <param name="child_location">The location to place the child.</param>
        /// <param name="child_velocity">The initial velocity of the child.</param>
        /// <returns>The cild organism.</returns>
        public virtual Organism Reproduce(XYZ child_location, XYZ child_velocity)
        {
            if (energy >= 5)
            {
                Organism child = new Organism(World, Name, DNA.Replicate(), child_location, child_velocity, random);

                child.energy -= child.energy_max / 2;

                World.AddPhysical(child);

                energy -= (int)(energy_max * .6);

                return child;
            }

            return null;
        }


        /// <summary>
        /// Kills this organism, removing it from the world, and placing a corpse in its place.
        /// </summary>
        /// <returns>The corpse that was created.</returns>
        public virtual Corpse Die()
        {
            World.DestroyPhysical(this);

            Corpse corpse = new Corpse(World, position, DNA.Size);

            World.AddPhysical(corpse);

            return corpse;
        }


        #region IPhysical Implementation

        /// <summary>
        /// The position of the organism this tick.
        /// </summary>
        /// <returns>The position of the organism this tick.</returns>
        public XYZ GetPosition()
        {
            return position;
        }


        /// <summary>
        /// The velocity of the organism this tick.
        /// </summary>
        /// <returns>The velocity of the organism this tick.</returns>
        public XYZ GetVelocity()
        {
            return velocity;
        }


        /// <summary>
        /// The size of the organism.
        /// </summary>
        /// <returns>The size of the organism.</returns>
        public double GetSize()
        {
            return DNA.Size;
        }


        /// <summary>
        /// What the organism does this tick.
        /// </summary>
        public virtual void OnTick()
        {
            Console.WriteLine(Name + ": " + position + " - " + DNA.Size + " - " + energy);


            #region Death Conditions

            if (energy <= 0)
            {
                Die();

                return;
            }

            #endregion Death Conditions


            #region Eat

            //Light:
            energy += (int)DNA.Photosynthetic;


            //Corpses:
            IEnumerable<IPhysical> found = World.GetPhysicalsInAreaExcluding_Nice(position, DNA.Size, new IPhysical[] { this });

            foreach (IPhysical physical in found)
            {
                if (physical is Corpse corpse)
                {
                    Eat(corpse);
                }
            }

            #endregion Eat


            #region Reproduce

            if (energy >= (2.0 * energy_max) / 3.0)
            {
                //Puts baby behind itself 1.25 body-lengths away.
                Reproduce(position + 1.25 * DNA.Size * direction.Negate(), direction.Negate());
            }

            #endregion Reproduce


            #region Move

            next_pos += direction.Project(velocity);

            if (World.OutOfBounds(next_pos))    //Illegal movements are cancelled.
            {
                return;
            }

            position = next_pos;


            energy -= (int)Math.Ceiling(velocity.GetLength());  //No free movement for you.

            double angle = direction.AngleTo(velocity);
            energy -= (int)Math.Ceiling(double.IsNaN(angle) ? 1 : angle);  //No free rotation for you.
            direction = velocity.Normalize();

            velocity = random.NextVector() * DNA.Speed;

            #endregion Move
        }

        #endregion IPhysical Implementation
    }
}
