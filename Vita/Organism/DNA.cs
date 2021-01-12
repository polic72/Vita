using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Vita.Organism
{
    [Serializable]
    public class DNA : ISerializable
    {
        public double Size { get; }

        public double Speed { get; }

        string test;


        public DNA(string test)
        {
            this.test = test;
        }


        public DNA(SerializationInfo info, StreamingContext context)
        {
            test = (string)info.GetString("test");
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("test", test);
        }
    }
}
