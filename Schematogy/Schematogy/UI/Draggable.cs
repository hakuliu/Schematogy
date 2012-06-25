using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Schematogy.UI
{
    interface Draggable
    {
        /// <summary>
        /// the bounds starting at the 0,0 of the moving bounds that the implemenetor uses.
        /// </summary>
        Rectangle MovableBounds
        {
            get;
        }
        /// <summary>
        /// the actual rectangle that specifies the bounds of the window while it's moving.
        /// </summary>
        Rectangle MovingBounds
        {
            set;
        }

        bool Moving
        {
            get;
            set;
        }

        void handleDraggableMouseMotionEvent(MouseMotionEvent e);
        void handleDraggableMouseEvent(MouseEvent e);
        void setupListeners();
    }
}
