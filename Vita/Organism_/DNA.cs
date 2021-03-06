﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Stonis;


namespace Vita.Organism_
{
    /// <summary>
    /// The DNA of an organism.
    /// </summary>
    [Serializable]
    public class DNA : ISerializable
    {
        public static double MUTATION_RATE = .01;
        public static double MUTATION_MAGNITUDE = .1;


        #region Genes

        /// <summary>
        /// The size of the organism.
        /// </summary>
        public double Size { get; }

        /// <summary>
        /// The speed of the organism.
        /// </summary>
        public double Speed { get; }


        /// <summary>
        /// The rate at which an organism can produce energy from nothing.
        /// </summary>
        public double Photosynthetic { get; }

        #endregion Genes


        protected Random random;


        #region Constructors

        /// <summary>
        /// Constructs a DNA object with random size and speed.
        /// </summary>
        /// <param name="random">The random object to use.</param>
        public DNA(Random random)
        {
            this.random = random;

            Size = random.NextDouble() * (Organism.MAX_SIZE - Organism.MIN_SIZE) + Organism.MIN_SIZE;

            Photosynthetic = Math.Abs(random.NextGaussian(0, 5));   //TODO balance

            //TODO make Gaussian
            Speed = random.NextDouble() * Organism.MAX_SPEED - Photosynthetic;
        }

        /// <summary>
        /// Constructs a DNA object with random size and speed. Random seed.
        /// </summary>
        public DNA() : this(new Random()) { }


        /// <summary>
        /// Constructs a DNA object with the given size and speed.
        /// </summary>
        /// <param name="size">The size to set.</param>
        /// <param name="speed">The speed to set.</param>
        /// <param name="photosynthetic">The photosynthetic to set.</param>
        /// <param name="random">The random object to use for later.</param>
        public DNA(double size, double speed, double photosynthetic, Random random)
        {
            Size = size;
            Speed = speed;
            Photosynthetic = photosynthetic;

            this.random = random;
        }


        /// <summary>
        /// Constructs a DNA object with the given size and speed.
        /// </summary>
        /// <param name="size">The size to set.</param>
        /// <param name="speed">The speed to set.</param>
        /// <param name="photosynthetic">The photosynthetic to set.</param>
        public DNA(double size, double speed, double photosynthetic) : this(size, speed, photosynthetic, new Random()) { }


        /// <summary>
        /// Constructs a DNA object based on its serialized form.
        /// </summary>
        /// <param name="info">The serialization of the object.</param>
        /// <param name="context">The context of the serialization.</param>
        public DNA(SerializationInfo info, StreamingContext context)
        {
            Size = info.GetDouble("size");
            Speed = info.GetDouble("speed");
            Photosynthetic = info.GetDouble("photosynthetic");
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
            info.AddValue("photosynthetic", Photosynthetic);
        }


        /// <summary>
        /// Replicates this DNA. Has a chance to mutate based on the mutation rate and magnitude.
        /// </summary>
        /// <returns>This DNA object if replicated perfectly. Mutated DNA (new object) if mutated.</returns>
        public DNA Replicate()
        {
            bool any_changes = false;

            double new_size = 0;
            if (random.NextDouble() < MUTATION_RATE)
            {
                new_size = random.NextGaussian(Size, MUTATION_MAGNITUDE);

                any_changes = true;
            }

            double new_speed = 0;
            if (random.NextDouble() < MUTATION_RATE)
            {
                new_speed = random.NextGaussian(Speed, MUTATION_MAGNITUDE);

                any_changes = true;
            }

            double new_photosynthetic = 0;
            if (random.NextDouble() < MUTATION_RATE)
            {
                new_photosynthetic = random.NextGaussian(Photosynthetic, MUTATION_MAGNITUDE);

                any_changes = true;
            }


            if (any_changes)
            {
                return new DNA(new_size, new_speed, new_photosynthetic, random);
            }

            return this;
        }
    }
}
