using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stonis;


namespace Vita.Organism
{
    public class Organism
    {
        public static readonly double MIN_SIZE = .1;
        public static readonly double MAX_SIZE = 10;


        #region Properties

        public Name Name { get; }

        public DNA DNA { get; }

        #endregion Properties


        public Organism(Name name)
        {
            this.Name = name;
        }
    }
}
