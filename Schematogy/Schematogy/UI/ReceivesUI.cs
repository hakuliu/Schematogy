using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Schematogy.UI
{
    interface ReceivesUI
    {
        void ReceiveUI(KeyboardState keyState, MouseState mouseState);
    }
}
