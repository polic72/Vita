using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stonis;

using Vita.Miscellaneous;


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

        #endregion Properties


        protected XYZ position;

        protected XYZ velocity;


        #region Constructors

        /// <summary>
        /// Constructs an organism with the given Name, DNA, position, and velocity.
        /// </summary>
        /// <param name="name">The name of the organism.</param>
        /// <param name="dna">The DNA of the organism.</param>
        /// <param name="position">The position of the organism.</param>
        /// <param name="velocity">The velocity of the organism.</param>
        public Organism(Name name, DNA dna, XYZ position, XYZ velocity)
        {
            Name = name;
            DNA = dna;

            this.position = position;
            this.velocity = velocity;
        }

        /// <summary>
        /// Constructs an organism with the given Name, and DNA. Zero position and velocity.
        /// </summary>
        /// <param name="name">The name of the organism.</param>
        /// <param name="dna">The DNA of the organism.</param>
        public Organism(Name name, DNA dna) : this(name, dna, XYZ.Zero, XYZ.Zero) { }

        #endregion Constructors


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
        /// What the organism does this tick.
        /// </summary>
        public void OnTick()
        {
            position += velocity;

            Console.WriteLine(Name + ": " + position);
        }
    }
}
