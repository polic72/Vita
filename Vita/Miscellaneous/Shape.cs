using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Stonis;

namespace Vita.Miscellaneous
{
    public abstract class Shape
    {
        protected XYZ origin;
        public XYZ Origin
        {
            get
            {
                return origin;
            }
        }

        protected readonly double volume;
        public double Volume
        {
            get
            {
                return volume;
            }
        }


        public Shape()
        {
            
        }
    }
}
