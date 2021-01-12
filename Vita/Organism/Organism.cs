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
