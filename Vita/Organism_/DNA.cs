using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Vita.Organism_
{
    /// <summary>
    /// The DNA of an organism.
    /// </summary>
    [Serializable]
    public class DNA : ISerializable
    {
        /// <summary>
        /// The size of the organism.
        /// </summary>
        public double Size { get; }

        /// <summary>
        /// The speed of the organism.
        /// </summary>
        public double Speed { get; }

        protected Random random;


        #region Constructors

        /// <summary>
        /// Constructs a DNA object with random size and speed.
        /// </summary>
        /// <param name="seed">The seed for the randomness.</param>
        public DNA(int seed)
        {
            random = new Random(seed);

            Size = random.NextDouble() * (Organism.MAX_SIZE - Organism.MIN_SIZE) + Organism.MIN_SIZE;

            Speed = random.NextDouble();    //Min is 0 for plants/filter-feeders. Max is ~1 for testing.
        }

        /// <summary>
        /// Constructs a DNA object with random size and speed. Random seed.
        /// </summary>
        public DNA() : this(new Random().Next()) { }


        /// <summary>
        /// Constructs a DNA object based on its serialized form.
        /// </summary>
        /// <param name="info">The serialization of the object.</param>
        /// <param name="context">The context of the serialization.</param>
        public DNA(SerializationInfo info, StreamingContext context)
        {
            Size = info.GetDouble("size");
            Speed = info.GetDouble("speed");
        }

        #endregion Constructors


        /// <summary>
        /// Serializes the DNA.
        /// </summary>
        /// <param name="info">The object to serialize in to.</param>
        /// <param name="context">The context of the serialization.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("size", Size);
            info.AddValue("speed", Speed);
        }
    }
}
