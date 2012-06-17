using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Schematogy.Util
{
    /// <summary>
    /// basically, although you can query for input states individually with Mouse.getState(), etc,
    /// it's bad because 1. that will cause the program to query for hardwares multiple times per frame, and
    /// the input might asynchronously change during the duration of a frame, and we'll get inconsistent data.
    /// 
    /// sooo we keep one Input state that gets updated every frame, and we take our inputs from here.
    /// </summary>
    class UserInputCenter
    {
        private static UserInputCenter instance;
        private MouseState cachedMouse;
        private KeyboardState cachedKeyboard;
        private UserInputCenter()
        {
            cachedKeyboard = Keyboard.GetState();
            cachedMouse = Mouse.GetState();
        }
        private static UserInputCenter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInputCenter();
                }
                return instance;
            }
        }
        public static MouseState mouse
        {
            get
            {
                return Instance.cachedMouse;
            }
        }
        public static KeyboardState keyboard
        {
            get
            {
                return Instance.cachedKeyboard;
            }
        }
        /// <summary>
        /// this should only be called once per frame...at the beginning of the frame.
        /// <param name="game">I dont' actually use this parameter, this is just to restrict the caller to someone who knows Game1</param>
        /// </summary>
        public static void Update(Game1 game)
        {
            Instance.cachedKeyboard = Keyboard.GetState();
            Instance.cachedMouse = Mouse.GetState();
        }
    }
}
