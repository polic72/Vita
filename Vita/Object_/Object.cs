using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vita.Graphics;
using Vita.Miscellaneous;

using Stonis;

namespace Vita.Object_
{
    public class Object : IDisplayable
    {
        public XYZ position;

        public XYZ GetPosition()
        {
            return position;
        }

        public XYZ GetVelocity()
        {
            return XYZ.Zero;
        }

        public Object(XYZ position)
        {
            this.position = position;
        }
    }
}
