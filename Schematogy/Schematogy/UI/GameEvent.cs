using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Schematogy.UI
{
    //a list of all the event types there can exist.
    public enum EventType
    {
        MouseEvent,
        MouseMotionEvent,
        KeyEvent
    };
    public abstract class GameEvent
    {
        /// <summary>
        /// type of event.
        /// </summary>
        /// <remarks>
        /// BTW, dont' use .GetType(), because that's crazy C# reflection stuff.
        /// </remarks>
        protected EventType eType;
        public EventType Type
        {
            get { return eType; }
        }

        public GameEvent(EventType type)
        {
            this.eType = type;
        }
    }
    public enum MouseButton { LEFT_BUTTON, RIGHT_BUTTON, MIDDLE_BUTTON };
    /// <summary>
    /// describes an mouse event, because xna only gives me states, but i want to have handlers.
    /// </summary>
    public class MouseEvent : GameEvent
    {
        //first declare the privates, then properties, because

        //if not Pressed, then obviously, it's released.
        private ButtonState pressed;
        private int mousex;
        private int mousey;
        private MouseButton button;

        public ButtonState Pressed { get { return pressed; } }
        public int X { get { return mousex; } }
        public int Y { get { return mousey; } }
        public MouseButton Button { get { return button; } }

        public MouseEvent(ButtonState pressed, int mousex, int mousey, MouseButton button)
            : base(EventType.MouseEvent)
        {
            this.pressed = pressed;
            this.mousex = mousex;
            this.mousey = mousey;
            this.button = button;
        }
    }

    public class MouseMotionEvent : GameEvent
    {
        private int mousex;
        private int mousey;
        private int scroll;
        private int dx;
        private int dy;
        private int dScroll;

        public int X { get { return mousex; } }
        public int Y { get { return mousey; } }
        public int Scroll { get { return scroll; } }
        public int DX { get { return dx; } }
        public int DY { get { return dy; } }
        public int DScroll { get { return dScroll; } }
        public MouseMotionEvent(int X, int Y, int scroll, int DX, int DY, int dScroll)
            : base(EventType.MouseMotionEvent)
        {
            this.mousex = X;
            this.mousey = Y;
            this.scroll = scroll;
            this.dx = DX;
            this.dy = DY;
            this.dScroll = dScroll;
        }
    }

    public class KeyboardEvent : GameEvent
    {
        private ButtonState pressed;
        private Keys key;

        public ButtonState Pressed
        {
            get { return pressed; }
        }
        public Keys Key
        {
            get { return key; }
        }

        public KeyboardEvent(ButtonState pressed, Keys key)
            : base(EventType.KeyEvent)
        {
            this.pressed = pressed;
            this.key = key;
        }
    }
}
