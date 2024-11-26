// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Xna.Framework.Graphics {
    partial class GraphicsAdapter
    {
        private static void PlatformInitializeAdapters(out ReadOnlyCollection<GraphicsAdapter> adapters)
        {
            var found = new List<GraphicsAdapter>();
            var adapter = new GraphicsAdapter();
            adapter.DeviceName = "GraphicsAdapter";
            adapter.Description = "GraphicsAdapter";
            found.Add(adapter);
            adapters = new ReadOnlyCollection<GraphicsAdapter>(found);
        }

        private bool PlatformIsProfileSupported(GraphicsProfile graphicsProfile)
        {
            return true;
        }
    }
};


