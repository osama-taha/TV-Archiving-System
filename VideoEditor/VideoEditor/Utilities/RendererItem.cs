using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotDetection.Utilities
{
    public struct RendererItem
    {
        public Type Type;

        public override string ToString()
        {
            return Type.Name;
        }

        public RendererItem(Type type)
        {
            Type = type;
        }
    }
}
