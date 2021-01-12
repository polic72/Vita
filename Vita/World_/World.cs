using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Object = Vita.Object_.Object;
using Vita.Miscellaneous;
using Vita.Graphics;
using System.Windows.Shapes;
using System.Windows.Media;

using Stonis;

namespace Vita.World_
{
    public class World
    {
        public int WorldSize_X { get; }
        public int WorldSize_Y { get; }
        public int WorldSize_Z { get; }

        private List<IDisplayable> drawables;

        private Main_Window window;


        public World(int worldSize_X, int worldSize_Y, int worldSize_Z)
        {
            WorldSize_X = worldSize_X;
            WorldSize_Y = worldSize_Y;
            WorldSize_Z = worldSize_Z;

            drawables = new List<IDisplayable>();

            drawables.Add(new Object(new XYZ(5, 15, 0)));
            drawables.Add(new Object(new XYZ(100, 150, 0)));
        }
    }
}
