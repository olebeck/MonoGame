using System;
using System.Threading.Tasks;

using Sce.PlayStation.Core.Environment;

namespace Microsoft.Xna.Framework.Input
{
    public static partial class KeyboardInput
    {
        static private TextInputDialog _dialog;

        private static Task<string> PlatformShow(string title, string description, string defaultText, bool usePasswordMode)
        {
            Threading.EnsureUIThread();
            _dialog = new TextInputDialog();
            _dialog.Open();
        }

        private static void PlatformCancel(string result)
        {
            Threading.EnsureUIThread();
            _dialog.Abort();
        }
    }
}
