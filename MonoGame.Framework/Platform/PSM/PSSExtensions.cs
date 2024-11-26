using System;

using PssVector4 = Sce.PlayStation.Core.Vector4;
using PSSImageRect = Sce.PlayStation.Core.Imaging.ImageRect;

namespace Microsoft.Xna.Framework
{
    public static class PSSExtensions
    {
        public static PssVector4 ToPssVector4(this Vector4 v)
        {
            return new PssVector4(v.X, v.Y, v.Z, v.W);
        }

        public static PSSImageRect ToPSSImageRect(this Rectangle v)
        {
            return new PSSImageRect(v.X, v.Y, v.Width, v.Height);
        }
    }
}

