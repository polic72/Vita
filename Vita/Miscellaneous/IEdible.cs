using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vita.Miscellaneous
{
    public interface IEdible : IPhysical
    {
        bool IsEaten();

        void MarkAsEaten();

        int GetEnergyValue();
    }
}
