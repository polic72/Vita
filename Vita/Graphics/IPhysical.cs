﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Vita.Miscellaneous;
using Stonis;

namespace Vita.Graphics
{
    public interface IPhysical
    {
        XYZ GetPosition();

        XYZ GetVelocity();
    }
}